using System;
using System.Runtime.InteropServices;

namespace Discord
{
	public struct LobbyTransaction
	{
		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetTypeMethod(IntPtr methodsPtr, LobbyType type);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetOwnerMethod(IntPtr methodsPtr, long ownerId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetCapacityMethod(IntPtr methodsPtr, uint capacity);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetMetadataMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result DeleteMetadataMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)] string key);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetLockedMethod(IntPtr methodsPtr, bool locked);

			internal SetTypeMethod SetType;

			internal SetOwnerMethod SetOwner;

			internal SetCapacityMethod SetCapacity;

			internal SetMetadataMethod SetMetadata;

			internal DeleteMetadataMethod DeleteMetadata;

			internal SetLockedMethod SetLocked;
		}

		internal IntPtr MethodsPtr;

		internal object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public void SetType(LobbyType type)
		{
		}

		public void SetOwner(long ownerId)
		{
		}

		public void SetCapacity(uint capacity)
		{
		}

		public void SetMetadata(string key, string value)
		{
		}

		public void DeleteMetadata(string key)
		{
		}

		public void SetLocked(bool locked)
		{
		}
	}
}
