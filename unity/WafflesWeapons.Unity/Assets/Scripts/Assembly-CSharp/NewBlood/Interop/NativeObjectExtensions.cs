using UnityEngine;

namespace NewBlood.Interop
{
	public static class NativeObjectExtensions
	{
		public unsafe static NativeObject* GetNativeObject(this Object @this)
		{
			//IL_0002: Expected I, but got O
			return (NativeObject*)null;
		}

		public unsafe static NativeComponent* GetNativeObject(this Component @this)
		{
			//IL_0002: Expected I, but got O
			return (NativeComponent*)null;
        }

		public unsafe static NativeRenderer* GetNativeObject(this Renderer @this)
		{
			//IL_0002: Expected I, but got O
			return (NativeRenderer*)null;
        }
	}
}
