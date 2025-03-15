using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Discord
{
	public class VoiceManager
	{
		internal struct FFIEvents
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SettingsUpdateHandler(IntPtr ptr);

			internal SettingsUpdateHandler OnSettingsUpdate;
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetInputModeMethod(IntPtr methodsPtr, ref InputMode inputMode);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SetInputModeCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SetInputModeMethod(IntPtr methodsPtr, InputMode inputMode, IntPtr callbackData, SetInputModeCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result IsSelfMuteMethod(IntPtr methodsPtr, ref bool mute);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetSelfMuteMethod(IntPtr methodsPtr, bool mute);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result IsSelfDeafMethod(IntPtr methodsPtr, ref bool deaf);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetSelfDeafMethod(IntPtr methodsPtr, bool deaf);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result IsLocalMuteMethod(IntPtr methodsPtr, long userId, ref bool mute);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetLocalMuteMethod(IntPtr methodsPtr, long userId, bool mute);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetLocalVolumeMethod(IntPtr methodsPtr, long userId, ref byte volume);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SetLocalVolumeMethod(IntPtr methodsPtr, long userId, byte volume);

			internal GetInputModeMethod GetInputMode;

			internal SetInputModeMethod SetInputMode;

			internal IsSelfMuteMethod IsSelfMute;

			internal SetSelfMuteMethod SetSelfMute;

			internal IsSelfDeafMethod IsSelfDeaf;

			internal SetSelfDeafMethod SetSelfDeaf;

			internal IsLocalMuteMethod IsLocalMute;

			internal SetLocalMuteMethod SetLocalMute;

			internal GetLocalVolumeMethod GetLocalVolume;

			internal SetLocalVolumeMethod SetLocalVolume;
		}

		public delegate void SetInputModeHandler(Result result);

		public delegate void SettingsUpdateHandler();

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public event SettingsUpdateHandler OnSettingsUpdate
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

		internal VoiceManager(IntPtr ptr, IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		public InputMode GetInputMode()
		{
			return default(InputMode);
		}

		[MonoPInvokeCallback]
		private static void SetInputModeCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void SetInputMode(InputMode inputMode, SetInputModeHandler callback)
		{
		}

		public bool IsSelfMute()
		{
			return false;
		}

		public void SetSelfMute(bool mute)
		{
		}

		public bool IsSelfDeaf()
		{
			return false;
		}

		public void SetSelfDeaf(bool deaf)
		{
		}

		public bool IsLocalMute(long userId)
		{
			return false;
		}

		public void SetLocalMute(long userId, bool mute)
		{
		}

		public byte GetLocalVolume(long userId)
		{
			return 0;
		}

		public void SetLocalVolume(long userId, byte volume)
		{
		}

		[MonoPInvokeCallback]
		private static void OnSettingsUpdateImpl(IntPtr ptr)
		{
		}
	}
}
