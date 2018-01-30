using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

//DO NOT MODIFY - MODIFY THE VERSION IN THE PERSONAL EXPERIENCE-APP UNITY PROJECT

namespace SpotifyRec.Utils
{
	public delegate void EventHandler<TSender, TEventArgs>(TSender sender, TEventArgs e);
	public delegate void EventHandlerSender<TSender>(TSender sender, EventArgs e);

	public class EventArgsTuple<T1> : EventArgs
	{
		public readonly T1 Arg1;
		public EventArgsTuple(T1 arg1) {
			this.Arg1 = arg1;
		}
	}
	public class EventArgsTuple<T1, T2> : EventArgs
	{
		public readonly T1 Arg1;
		public readonly T2 Arg2;
		public EventArgsTuple(T1 arg1, T2 arg2) {
			this.Arg1 = arg1;
			this.Arg2 = arg2;
		}
	}
	public class EventArgsTuple<T1, T2, T3> : EventArgs
	{
		public readonly T1 Arg1;
		public readonly T2 Arg2;
		public readonly T3 Arg3;
		public EventArgsTuple(T1 arg1, T2 arg2, T3 arg3) {
			this.Arg1 = arg1;
			this.Arg2 = arg2;
			this.Arg3 = arg3;
		}
	}
	public class EventArgsTuple<T1, T2, T3, T4> : EventArgs
	{
		public readonly T1 Arg1;
		public readonly T2 Arg2;
		public readonly T3 Arg3;
		public readonly T4 Arg4;
		public EventArgsTuple(T1 arg1, T2 arg2, T3 arg3, T4 arg4) {
			this.Arg1 = arg1;
			this.Arg2 = arg2;
			this.Arg3 = arg3;
			this.Arg4 = arg4;
		}
	}
	public class EventArgsTuple<T1, T2, T3, T4, T5> : EventArgs
	{
		public readonly T1 Arg1;
		public readonly T2 Arg2;
		public readonly T3 Arg3;
		public readonly T4 Arg4;
		public readonly T5 Arg5;
		public EventArgsTuple(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) {
			this.Arg1 = arg1;
			this.Arg2 = arg2;
			this.Arg3 = arg3;
			this.Arg4 = arg4;
			this.Arg5 = arg5;
		}
	}

	public delegate void EventHandlerTuple<T1                >(object sender, EventArgsTuple<T1                > e);
	public delegate void EventHandlerTuple<T1, T2            >(object sender, EventArgsTuple<T1, T2            > e);
	public delegate void EventHandlerTuple<T1, T2, T3        >(object sender, EventArgsTuple<T1, T2, T3        > e);
	public delegate void EventHandlerTuple<T1, T2, T3, T4    >(object sender, EventArgsTuple<T1, T2, T3, T4    > e);
	public delegate void EventHandlerTuple<T1, T2, T3, T4, T5>(object sender, EventArgsTuple<T1, T2, T3, T4, T5> e);

	public delegate void EventHandlerSenderTuple<TSender, T1                >(TSender sender, EventArgsTuple<T1                > e);
	public delegate void EventHandlerSenderTuple<TSender, T1, T2            >(TSender sender, EventArgsTuple<T1, T2            > e);
	public delegate void EventHandlerSenderTuple<TSender, T1, T2, T3        >(TSender sender, EventArgsTuple<T1, T2, T3        > e);
	public delegate void EventHandlerSenderTuple<TSender, T1, T2, T3, T4    >(TSender sender, EventArgsTuple<T1, T2, T3, T4    > e);
	public delegate void EventHandlerSenderTuple<TSender, T1, T2, T3, T4, T5>(TSender sender, EventArgsTuple<T1, T2, T3, T4, T5> e);

	public static class EventExtensions
	{
		public static void Fire(this EventHandler eventHandler, object sender)
		{
			if (eventHandler != null) {
				eventHandler(sender, EventArgs.Empty);
			}
		}

		public static void Fire<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs eventArgs)
			where TEventArgs : EventArgs
		{
			if (eventHandler != null) {
				eventHandler(sender, eventArgs);
			}
		}

		public static void Fire<TSender, TEventArgs>(this EventHandler<TSender, TEventArgs> eventHandler, TSender sender, TEventArgs eventArgs)
			where TEventArgs : EventArgs
		{
			if (eventHandler != null) {
				eventHandler(sender, eventArgs);
			}
		}

		public static void Fire<TSender>(this EventHandlerSender<TSender> eventHandler, TSender sender)
		{
			if (eventHandler != null) {
				eventHandler(sender, EventArgs.Empty);
			}
		}

		public static void Fire<T1                >(this EventHandlerTuple<T1                > eventHandler, object sender, EventArgsTuple<T1                > eventArgs) { if (eventHandler != null) eventHandler(sender, eventArgs); }
		public static void Fire<T1, T2            >(this EventHandlerTuple<T1, T2            > eventHandler, object sender, EventArgsTuple<T1, T2            > eventArgs) { if (eventHandler != null) eventHandler(sender, eventArgs); }
		public static void Fire<T1, T2, T3        >(this EventHandlerTuple<T1, T2, T3        > eventHandler, object sender, EventArgsTuple<T1, T2, T3        > eventArgs) { if (eventHandler != null) eventHandler(sender, eventArgs); }
		public static void Fire<T1, T2, T3, T4    >(this EventHandlerTuple<T1, T2, T3, T4    > eventHandler, object sender, EventArgsTuple<T1, T2, T3, T4    > eventArgs) { if (eventHandler != null) eventHandler(sender, eventArgs); }
		public static void Fire<T1, T2, T3, T4, T5>(this EventHandlerTuple<T1, T2, T3, T4, T5> eventHandler, object sender, EventArgsTuple<T1, T2, T3, T4, T5> eventArgs) { if (eventHandler != null) eventHandler(sender, eventArgs); }

		public static void Fire<T1                >(this EventHandlerTuple<T1                > eventHandler, object sender, T1 arg1                                    ) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1                >(arg1                        )); }
		public static void Fire<T1, T2            >(this EventHandlerTuple<T1, T2            > eventHandler, object sender, T1 arg1, T2 arg2                           ) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1, T2            >(arg1, arg2                  )); }
		public static void Fire<T1, T2, T3        >(this EventHandlerTuple<T1, T2, T3        > eventHandler, object sender, T1 arg1, T2 arg2, T3 arg3                  ) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1, T2, T3        >(arg1, arg2, arg3            )); }
		public static void Fire<T1, T2, T3, T4    >(this EventHandlerTuple<T1, T2, T3, T4    > eventHandler, object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4         ) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1, T2, T3, T4    >(arg1, arg2, arg3, arg4      )); }
		public static void Fire<T1, T2, T3, T4, T5>(this EventHandlerTuple<T1, T2, T3, T4, T5> eventHandler, object sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1, T2, T3, T4, T5>(arg1, arg2, arg3, arg4, arg5)); }

		public static void Fire<TSender, T1                >(this EventHandlerSenderTuple<TSender, T1                > eventHandler, TSender sender, T1 arg1                                    ) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1                >(arg1                        )); }
		public static void Fire<TSender, T1, T2            >(this EventHandlerSenderTuple<TSender, T1, T2            > eventHandler, TSender sender, T1 arg1, T2 arg2                           ) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1, T2            >(arg1, arg2                  )); }
		public static void Fire<TSender, T1, T2, T3        >(this EventHandlerSenderTuple<TSender, T1, T2, T3        > eventHandler, TSender sender, T1 arg1, T2 arg2, T3 arg3                  ) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1, T2, T3        >(arg1, arg2, arg3            )); }
		public static void Fire<TSender, T1, T2, T3, T4    >(this EventHandlerSenderTuple<TSender, T1, T2, T3, T4    > eventHandler, TSender sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4         ) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1, T2, T3, T4    >(arg1, arg2, arg3, arg4      )); }
		public static void Fire<TSender, T1, T2, T3, T4, T5>(this EventHandlerSenderTuple<TSender, T1, T2, T3, T4, T5> eventHandler, TSender sender, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) { if (eventHandler != null) eventHandler(sender, new EventArgsTuple<T1, T2, T3, T4, T5>(arg1, arg2, arg3, arg4, arg5)); }
	}
}


//*/