using System;
using System.Runtime.InteropServices;

namespace Discord
{
	public struct LobbyMemberTransaction
	{
		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetMetadataMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)] string key, [MarshalAs(UnmanagedType.LPStr)] string value);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result DeleteMetadataMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)] string key);

			internal SetMetadataMethod SetMetadata;

			internal DeleteMetadataMethod DeleteMetadata;
		}

		internal IntPtr MethodsPtr;

		internal object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public void SetMetadata(string key, string value)
		{
		}

		public void DeleteMetadata(string key)
		{
		}
	}
}
