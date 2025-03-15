using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Discord
{
	public class ImageManager
	{
		internal struct FFIEvents
		{
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void FetchCallback(IntPtr ptr, Result result, ImageHandle handleResult);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void FetchMethod(IntPtr methodsPtr, ImageHandle handle, bool refresh, IntPtr callbackData, FetchCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetDimensionsMethod(IntPtr methodsPtr, ImageHandle handle, ref ImageDimensions dimensions);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetDataMethod(IntPtr methodsPtr, ImageHandle handle, byte[] data, int dataLen);

			internal FetchMethod Fetch;

			internal GetDimensionsMethod GetDimensions;

			internal GetDataMethod GetData;
		}

		public delegate void FetchHandler(Result result, ImageHandle handleResult);

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		internal ImageManager(IntPtr ptr, IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		[MonoPInvokeCallback]
		private static void FetchCallbackImpl(IntPtr ptr, Result result, ImageHandle handleResult)
		{
		}

		public void Fetch(ImageHandle handle, bool refresh, FetchHandler callback)
		{
		}

		public ImageDimensions GetDimensions(ImageHandle handle)
		{
			return default(ImageDimensions);
		}

		public void GetData(ImageHandle handle, byte[] data)
		{
		}

		public void Fetch(ImageHandle handle, FetchHandler callback)
		{
		}

		public byte[] GetData(ImageHandle handle)
		{
			return null;
		}

		public Texture2D GetTexture(ImageHandle handle)
		{
			return null;
		}
	}
}
