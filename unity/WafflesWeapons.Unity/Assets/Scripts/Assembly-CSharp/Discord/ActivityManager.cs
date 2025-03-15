using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Discord
{
	public class ActivityManager
	{
		internal struct FFIEvents
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ActivityJoinHandler(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] string secret);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ActivitySpectateHandler(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] string secret);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ActivityJoinRequestHandler(IntPtr ptr, ref User user);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ActivityInviteHandler(IntPtr ptr, ActivityActionType type, ref User user, ref Activity activity);

			internal ActivityJoinHandler OnActivityJoin;

			internal ActivitySpectateHandler OnActivitySpectate;

			internal ActivityJoinRequestHandler OnActivityJoinRequest;

			internal ActivityInviteHandler OnActivityInvite;
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result RegisterCommandMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)] string command);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result RegisterSteamMethod(IntPtr methodsPtr, uint steamId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void UpdateActivityCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void UpdateActivityMethod(IntPtr methodsPtr, ref Activity activity, IntPtr callbackData, UpdateActivityCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ClearActivityCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ClearActivityMethod(IntPtr methodsPtr, IntPtr callbackData, ClearActivityCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SendRequestReplyCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SendRequestReplyMethod(IntPtr methodsPtr, long userId, ActivityJoinRequestReply reply, IntPtr callbackData, SendRequestReplyCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SendInviteCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SendInviteMethod(IntPtr methodsPtr, long userId, ActivityActionType type, [MarshalAs(UnmanagedType.LPStr)] string content, IntPtr callbackData, SendInviteCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void AcceptInviteCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void AcceptInviteMethod(IntPtr methodsPtr, long userId, IntPtr callbackData, AcceptInviteCallback callback);

			internal RegisterCommandMethod RegisterCommand;

			internal RegisterSteamMethod RegisterSteam;

			internal UpdateActivityMethod UpdateActivity;

			internal ClearActivityMethod ClearActivity;

			internal SendRequestReplyMethod SendRequestReply;

			internal SendInviteMethod SendInvite;

			internal AcceptInviteMethod AcceptInvite;
		}

		public delegate void UpdateActivityHandler(Result result);

		public delegate void ClearActivityHandler(Result result);

		public delegate void SendRequestReplyHandler(Result result);

		public delegate void SendInviteHandler(Result result);

		public delegate void AcceptInviteHandler(Result result);

		public delegate void ActivityJoinHandler(string secret);

		public delegate void ActivitySpectateHandler(string secret);

		public delegate void ActivityJoinRequestHandler(ref User user);

		public delegate void ActivityInviteHandler(ActivityActionType type, ref User user, ref Activity activity);

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public event ActivityJoinHandler OnActivityJoin
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

		public event ActivitySpectateHandler OnActivitySpectate
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

		public event ActivityJoinRequestHandler OnActivityJoinRequest
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

		public event ActivityInviteHandler OnActivityInvite
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

		public void RegisterCommand()
		{
		}

		internal ActivityManager(IntPtr ptr, IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		public void RegisterCommand(string command)
		{
		}

		public void RegisterSteam(uint steamId)
		{
		}

		[MonoPInvokeCallback]
		private static void UpdateActivityCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void UpdateActivity(Activity activity, UpdateActivityHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void ClearActivityCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void ClearActivity(ClearActivityHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void SendRequestReplyCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void SendRequestReply(long userId, ActivityJoinRequestReply reply, SendRequestReplyHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void SendInviteCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void SendInvite(long userId, ActivityActionType type, string content, SendInviteHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void AcceptInviteCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void AcceptInvite(long userId, AcceptInviteHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void OnActivityJoinImpl(IntPtr ptr, string secret)
		{
		}

		[MonoPInvokeCallback]
		private static void OnActivitySpectateImpl(IntPtr ptr, string secret)
		{
		}

		[MonoPInvokeCallback]
		private static void OnActivityJoinRequestImpl(IntPtr ptr, ref User user)
		{
		}

		[MonoPInvokeCallback]
		private static void OnActivityInviteImpl(IntPtr ptr, ActivityActionType type, ref User user, ref Activity activity)
		{
		}
	}
}
