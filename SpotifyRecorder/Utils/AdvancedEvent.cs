/*

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyRec.Utils
{
	public struct AdvancedEventBackend<TDelegate> where TDelegate : class, ICloneable, ISerializable
	{
		//Use an immutable list, and make a copy of it during non-atomic operations, to avoid certain multithreading issues
		private ImmutableList<AdvancedEventHandler<TDelegate>> _handlers;

		static AdvancedEventBackend()
		{
			if (!typeof(MulticastDelegate).IsAssignableFrom(typeof(TDelegate)))
			{
				throw new InvalidCastException(
					"TDelegate type '" + typeof(TDelegate).AssemblyQualifiedName + "' is not derived from Delegate."
				);
			}
		}

		public void Sub(AdvancedEventHandler<TDelegate> handler)
		{
			ThrowIfHandlerArgEmpty(handler, nameof(handler));
			_handlers = _handlers.Add(handler);
		}

		public void Unsub(AdvancedEventHandler<TDelegate> handler)
		{
			ThrowIfHandlerArgEmpty(handler, nameof(handler));
			_handlers = _handlers.Remove(handler);
		}

		public void UnsubAllIdentical(AdvancedEventHandler<TDelegate> handler)
		{
			ThrowIfHandlerArgEmpty(handler, nameof(handler));
			_handlers = _handlers.RemoveAll(x => x.Equals(handler));
		}

		public void Fire(Action<TDelegate> firer)
		{
			ThrowIfArgNull(firer, nameof(firer));

			var handlersCopy = _handlers;
			for (int i = 0; i < handlersCopy.Count; i++)
			{
				firer(handlersCopy[i].Delegate);
			}
		}

		public void Clear()
		{
			_handlers = _handlers.Clear();
		}



		public void UnsubExecutingHandler()
		{

		}

		public void ResubExecutingHandler()
		{

		}


		public void SubNorm(TDelegate del)
		{
			ThrowIfArgNull(del, nameof(del));
			_handlers.Add(del);
		}

		public void UnsubNorm(TDelegate del)
		{
			ThrowIfArgNull(del, nameof(del));
			_normalHandlers.Remove(del);
		}

		public void UnsubAllNorm(TDelegate del)
		{
			ThrowIfArgNull(del, nameof(del));
			_normalHandlers.RemoveAll(x => x.Equals(del));
		}

		public void SubForOneFire(TDelegate del)
		{
			ThrowIfArgNull(del, nameof(del));
			_onceOnlyHandlers.Add(del);
		}

		public void CancelOneFire(TDelegate del)
		{
			ThrowIfArgNull(del, nameof(del));
			_onceOnlyHandlers.Remove(del);
		}

		public void CancelAllOneFires(TDelegate del)
		{
			ThrowIfArgNull(del, nameof(del));
			_onceOnlyHandlers.RemoveAll(x => x.Equals(del));
		}

		public void SubWeakRef(TDelegate del)
		{
			_weaklyReferencedHandlers.
		}

		private static T ThrowIfArgNull<T>(T arg, string name)
		{
			if (arg == null) throw new ArgumentNullException(name);
			else return arg;
		}

		private static AdvancedEventHandler<TDelegate> ThrowIfHandlerArgEmpty(AdvancedEventHandler<TDelegate> arg, string name)
		{
			if (arg.IsEmpty) throw new ArgumentException("AdvancedEventHandler is empty", name);
			else return arg;
		}
	}

	public struct AdvancedEvent<TDelegate>
	{
		

		


	}

	public struct AdvancedEventHandlerBackend<TDelegate>
		where TDelegate : class, ICloneable, ISerializable
	{
		public bool FireOnce { get; }
		public bool IsWeakReference => _weakReference != null;

		public bool IsEmpty => _weakReference == null && _strongReference == null;

		private readonly TDelegate _strongReference;
		private readonly WeakReference<TDelegate> _weakReference;

		public TDelegate Delegate
			=> IsWeakReference && _weakReference.TryGetTarget(out TDelegate weakRefTarget)
			? weakRefTarget
			: _strongReference;

		public AdvancedEventHandlerBackend(TDelegate del, bool fireOnce, bool weakRef)
		{
			this.FireOnce = fireOnce;
			if (weakRef) {
				this._weakReference = new WeakReference<TDelegate>(del, trackResurrection: false);
				this._strongReference = null;
			} else {
				this._strongReference = del;
				this._weakReference = null;
			}
		}

		public override bool Equals(object obj) => obj is AdvancedEventHandlerBackend<TDelegate> handler && Equals(this, handler);

		public static bool Equals(AdvancedEventHandlerBackend<TDelegate> a, AdvancedEventHandlerBackend<TDelegate> b)
			=> a.FireOnce == b.FireOnce
			&& a.IsWeakReference == b.IsWeakReference
			&& a.Delegate == b.Delegate;

		public static bool operator ==(AdvancedEventHandlerBackend<TDelegate> a, AdvancedEventHandlerBackend<TDelegate> b) => Equals(a, b);
		public static bool operator !=(AdvancedEventHandlerBackend<TDelegate> a, AdvancedEventHandlerBackend<TDelegate> b) => !(a == b);

		public override int GetHashCode() {
			unchecked {
				var hash = 17;
				hash = hash * 23 + FireOnce.GetHashCode();
				hash = hash * 23 + IsWeakReference.GetHashCode();
				hash = hash * 23 + (Delegate?.GetHashCode() ?? 0);
				return hash;
			}
		}
	}

	public struct AdvancedEventHandler<TDelegate>
		where TDelegate : class, ICloneable, ISerializable
	{
		private AdvancedEventHandlerBackend<TDelegate> _backend;

		public bool FireOnce => _backend.FireOnce;
		public bool IsWeakReference => _backend.IsWeakReference;
		public bool IsEmpty => _backend.IsEmpty;
		public TDelegate Delegate => _backend.Delegate;

		public AdvancedEventHandler(AdvancedEventHandlerBackend<TDelegate> backend)
		{
			this._backend = backend;
		}

		public AdvancedEventHandler(TDelegate del, bool fireOnce, bool weakRef)
			: this(backend: new AdvancedEventHandlerBackend<TDelegate>(del, fireOnce, weakRef))
		{ }

		public override bool Equals(object obj) => obj is AdvancedEventHandler<TDelegate> handler && Equals(this, handler);

		public static bool Equals(AdvancedEventHandler<TDelegate> a, AdvancedEventHandler<TDelegate> b) => a._backend == b._backend;

		public static bool operator ==(AdvancedEventHandler<TDelegate> a, AdvancedEventHandler<TDelegate> b) => Equals(a, b);
		public static bool operator !=(AdvancedEventHandler<TDelegate> a, AdvancedEventHandler<TDelegate> b) => !(a == b);

		public override int GetHashCode() => _backend.GetHashCode();
	}
}

//*/