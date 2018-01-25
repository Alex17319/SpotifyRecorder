using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Utils
{
	public class AsyncProcessHelper<TPart, TFull> : AsyncProcessHelper
	{
		private readonly Task _task;
		private readonly Logger _logger;
		public string ProcessName { get; }

		private readonly object _lock;

		public bool InProgress {
			get { lock (_lock) return _inProgress; }
		}
		private bool _inProgress;

		public bool Completed {
			get { lock (_lock) return _completed; }
		}
		private bool _completed;

		public bool Failed {
			get { lock (_lock) return _failed; }
		}
		private bool _failed;

		public ImmutableList<TPart> PartialResults { get; private set; }
		public TFull Result { get; private set; }

		public AsyncProcessHelper(Func<AsyncPartialResultCollector<TPart>, TFull> function, Logger logger, string processName)
		{
			this._lock = new object();

			this._logger = logger;
			this.ProcessName = processName;

			this._task = new Task(() => {
				lock (_lock) {
					try {
						this.Result = function(new AsyncPartialResultCollectorImpl(this));
						_completed = true;
						_inProgress = false;
					} catch (Exception e) {
						_failed = true;
						_inProgress = false;
						_logger?.Invoke(
							$"An error occurred during asynchronous process \"{ProcessName}\":\r\n{e}",
							LogType.Error
						);
					}
				}
			});
		}

		public void RunTaskAsync()
		{
			lock (_lock)
			{
				if (this.Completed) return;
				if (this.InProgress) return;

				this._inProgress = true;
				this._task.Start();
			}
		}

		//Idk, this approach might cause some slight bugs with timing, so I've used a manual bool to track it instead
		//	private static bool TaskIsInProgress(Task task)
		//	{
		//		return task != null && task.Status != TaskStatus.Created && !task.IsCanceled && !task.IsCompleted && !task.IsFaulted;
		//	}

		
		//Having the implementation as a private class like this ensures that
		//other classes can't create AsyncPartialResultCollector's that allow
		//invalid write access to the partial results collection - only the asynchronous
		//task ever has write access (and then only to add new items)
		private class AsyncPartialResultCollectorImpl : AsyncPartialResultCollector<TPart>
		{
			private AsyncProcessHelper<TPart, TFull> _asyncProcessHelper;

			public AsyncPartialResultCollectorImpl(AsyncProcessHelper<TPart, TFull> asyncProcessHelper)
			{
				this._asyncProcessHelper = asyncProcessHelper;
			}

			public override void AddPartialResult(TPart partialResult)
			{
				lock (_asyncProcessHelper._lock)
				{
					_asyncProcessHelper.PartialResults = _asyncProcessHelper.PartialResults.Add(partialResult);
				}
			}
		}
	}

	public abstract class AsyncPartialResultCollector<TPart>
	{
		public AsyncPartialResultCollector() { }

		public abstract void AddPartialResult(TPart partialResult);
	}

	public abstract class AsyncProcessHelper
	{
		/// <summary>
		/// Creates an <see cref="AsyncProcessHelper{TPart, TFull}"/> that has both partial results and a final result.
		/// </summary>
		public static AsyncProcessHelper<TPart, TFull> Create<TPart, TFull>(Func<AsyncPartialResultCollector<TPart>, TFull> function, Logger logger, string processName)
		{
			return new AsyncProcessHelper<TPart, TFull>(function, logger, processName);
		}

		/// <summary>
		/// Creates an <see cref="AsyncProcessHelper{TPart, TFull}"/> that has partial results but no final result
		/// (i.e. the final result is simply the collection of partial results).
		/// </summary>
		public static AsyncProcessHelper<TPart, ValueTuple> Create<TPart>(Action<AsyncPartialResultCollector<TPart>> function, Logger logger, string processName)
		{
			return new AsyncProcessHelper<TPart, ValueTuple>(
				function: partialResultCollector => { function(partialResultCollector); return new ValueTuple(); },
				logger: logger,
				processName: processName
			);
		}

		/// <summary>
		/// Creates an <see cref="AsyncProcessHelper{TPart, TFull}"/> that does not have partial results (but has a final result).
		/// </summary>
		public static AsyncProcessHelper<ValueTuple, TFull> Create<TFull>(Func<TFull> function, Logger logger, string processName)
		{
			return new AsyncProcessHelper<ValueTuple, TFull>(
				function: partialResultCollector => function(),
				logger: logger,
				processName: processName
			);
		}

		/// <summary>
		/// Creates an <see cref="AsyncProcessHelper{TPart, TFull}"/> that does not have partial results or a final result.
		/// </summary>
		public static AsyncProcessHelper<ValueTuple, ValueTuple> Create(Action function, Logger logger, string processName)
		{
			return new AsyncProcessHelper<ValueTuple, ValueTuple>(
				function: partialResultCollector => { function(); return new ValueTuple(); },
				logger: logger,
				processName: processName
			);
		}

		//Docs for when using different names to avoid compiler ambiguities.
		//It turned out that this didn't actually fix the ambiguity with type inference for whatever reason.
		//	/// <summary>
		//	/// Creates an <see cref="AsyncProcessHelper{TPart, TFull}"/> that has both partial results and a final result.
		//	/// </summary>
		//	/// <summary>
		//	/// Creates an <see cref="AsyncProcessHelper{TPart, TFull}"/> that has partial results but no final result
		//	/// (i.e. the final result is nothing more than the aggregate of the partial results).
		//	/// </summary>
		//	/// <remarks>
		//	/// Including 'Aggregate' in the name avoids compiler ambiguities.
		//	/// </remarks>
		//	/// <summary>
		//	/// Creates an <see cref="AsyncProcessHelper{TPart, TFull}"/> that does not have partial results (but has a final result)
		//	/// (i.e. is a single operation, not a collection of partial).
		//	/// </summary>
		//	/// <remarks>
		//	/// Including 'Atomic' in the name avoids compiler ambiguities.
		//	/// </remarks>
		//	/// <summary>
		//	/// Creates an <see cref="AsyncProcessHelper{TPart, TFull}"/> that does not have partial results or a final result
		//	/// (i.e. fire & forget).
		//	/// </summary>
		//	/// <remarks>
		//	/// Including 'Forgettable' in the name avoids compiler ambiguities.
		//	/// </remarks>
	}
}
