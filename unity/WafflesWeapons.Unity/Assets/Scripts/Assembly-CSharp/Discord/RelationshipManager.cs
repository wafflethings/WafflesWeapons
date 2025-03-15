using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Discord
{
	public class RelationshipManager
	{
		internal struct FFIEvents
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RefreshHandler(IntPtr ptr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RelationshipUpdateHandler(IntPtr ptr, ref Relationship relationship);

			internal RefreshHandler OnRefresh;

			internal RelationshipUpdateHandler OnRelationshipUpdate;
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate bool FilterCallback(IntPtr ptr, ref Relationship relationship);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void FilterMethod(IntPtr methodsPtr, IntPtr callbackData, FilterCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result CountMethod(IntPtr methodsPtr, ref int count);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetMethod(IntPtr methodsPtr, long userId, ref Relationship relationship);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetAtMethod(IntPtr methodsPtr, uint index, ref Relationship relationship);

			internal FilterMethod Filter;

			internal CountMethod Count;

			internal GetMethod Get;

			internal GetAtMethod GetAt;
		}

		public delegate bool FilterHandler(ref Relationship relationship);

		public delegate void RefreshHandler();

		public delegate void RelationshipUpdateHandler(ref Relationship relationship);

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public event RefreshHandler OnRefresh
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event RelationshipUpdateHandler OnRelationshipUpdate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		internal RelationshipManager(IntPtr ptr, IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		[MonoPInvokeCallback]
		private static bool FilterCallbackImpl(IntPtr ptr, ref Relationship relationship)
		{
			return false;
		}

		public void Filter(FilterHandler callback)
		{
		}

		public int Count()
		{
			return 0;
		}

		public Relationship Get(long userId)
		{
			return default(Relationship);
		}

		public Relationship GetAt(uint index)
		{
			return default(Relationship);
		}

		[MonoPInvokeCallback]
		private static void OnRefreshImpl(IntPtr ptr)
		{
		}

		[MonoPInvokeCallback]
		private static void OnRelationshipUpdateImpl(IntPtr ptr, ref Relationship relationship)
		{
		}
	}
}
