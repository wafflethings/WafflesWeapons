using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Discord
{
	public class NetworkManager
	{
		internal struct FFIEvents
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void MessageHandler(IntPtr ptr, ulong peerId, byte channelId, IntPtr dataPtr, int dataLen);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void RouteUpdateHandler(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr)] string routeData);

			internal MessageHandler OnMessage;

			internal RouteUpdateHandler OnRouteUpdate;
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetPeerIdMethod(IntPtr methodsPtr, ref ulong peerId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result FlushMethod(IntPtr methodsPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result OpenPeerMethod(IntPtr methodsPtr, ulong peerId, [MarshalAs(UnmanagedType.LPStr)] string routeData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result UpdatePeerMethod(IntPtr methodsPtr, ulong peerId, [MarshalAs(UnmanagedType.LPStr)] string routeData);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result ClosePeerMethod(IntPtr methodsPtr, ulong peerId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result OpenChannelMethod(IntPtr methodsPtr, ulong peerId, byte channelId, bool reliable);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result CloseChannelMethod(IntPtr methodsPtr, ulong peerId, byte channelId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SendMessageMethod(IntPtr methodsPtr, ulong peerId, byte channelId, byte[] data, int dataLen);

			internal GetPeerIdMethod GetPeerId;

			internal FlushMethod Flush;

			internal OpenPeerMethod OpenPeer;

			internal UpdatePeerMethod UpdatePeer;

			internal ClosePeerMethod ClosePeer;

			internal OpenChannelMethod OpenChannel;

			internal CloseChannelMethod CloseChannel;

			internal SendMessageMethod SendMessage;
		}

		public delegate void MessageHandler(ulong peerId, byte channelId, byte[] data);

		public delegate void RouteUpdateHandler(string routeData);

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public event MessageHandler OnMessage
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

		public event RouteUpdateHandler OnRouteUpdate
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

		internal NetworkManager(IntPtr ptr, IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		public ulong GetPeerId()
		{
			return 0uL;
		}

		public void Flush()
		{
		}

		public void OpenPeer(ulong peerId, string routeData)
		{
		}

		public void UpdatePeer(ulong peerId, string routeData)
		{
		}

		public void ClosePeer(ulong peerId)
		{
		}

		public void OpenChannel(ulong peerId, byte channelId, bool reliable)
		{
		}

		public void CloseChannel(ulong peerId, byte channelId)
		{
		}

		public void SendMessage(ulong peerId, byte channelId, byte[] data)
		{
		}

		[MonoPInvokeCallback]
		private static void OnMessageImpl(IntPtr ptr, ulong peerId, byte channelId, IntPtr dataPtr, int dataLen)
		{
		}

		[MonoPInvokeCallback]
		private static void OnRouteUpdateImpl(IntPtr ptr, string routeData)
		{
		}
	}
}
