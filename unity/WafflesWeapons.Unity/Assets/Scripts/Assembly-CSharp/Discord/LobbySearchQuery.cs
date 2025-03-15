using System;
using System.Runtime.InteropServices;

namespace Discord
{
	public struct LobbySearchQuery
	{
		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result FilterMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)] string key, LobbySearchComparison comparison, LobbySearchCast cast, [MarshalAs(UnmanagedType.LPStr)] string value);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SortMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)] string key, LobbySearchCast cast, [MarshalAs(UnmanagedType.LPStr)] string value);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result LimitMethod(IntPtr methodsPtr, uint limit);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result DistanceMethod(IntPtr methodsPtr, LobbySearchDistance distance);

			internal FilterMethod Filter;

			internal SortMethod Sort;

			internal LimitMethod Limit;

			internal DistanceMethod Distance;
		}

		internal IntPtr MethodsPtr;

		internal object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public void Filter(string key, LobbySearchComparison comparison, LobbySearchCast cast, string value)
		{
		}

		public void Sort(string key, LobbySearchCast cast, string value)
		{
		}

		public void Limit(uint limit)
		{
		}

		public void Distance(LobbySearchDistance distance)
		{
		}
	}
}
