using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Discord
{
	public class LobbyManager
	{
		internal struct FFIEvents
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void LobbyUpdateHandler(IntPtr ptr, long lobbyId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void LobbyDeleteHandler(IntPtr ptr, long lobbyId, uint reason);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void MemberConnectHandler(IntPtr ptr, long lobbyId, long userId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void MemberUpdateHandler(IntPtr ptr, long lobbyId, long userId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void MemberDisconnectHandler(IntPtr ptr, long lobbyId, long userId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void LobbyMessageHandler(IntPtr ptr, long lobbyId, long userId, IntPtr dataPtr, int dataLen);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SpeakingHandler(IntPtr ptr, long lobbyId, long userId, bool speaking);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void NetworkMessageHandler(IntPtr ptr, long lobbyId, long userId, byte channelId, IntPtr dataPtr, int dataLen);

			internal LobbyUpdateHandler OnLobbyUpdate;

			internal LobbyDeleteHandler OnLobbyDelete;

			internal MemberConnectHandler OnMemberConnect;

			internal MemberUpdateHandler OnMemberUpdate;

			internal MemberDisconnectHandler OnMemberDisconnect;

			internal LobbyMessageHandler OnLobbyMessage;

			internal SpeakingHandler OnSpeaking;

			internal NetworkMessageHandler OnNetworkMessage;
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetLobbyCreateTransactionMethod(IntPtr methodsPtr, ref IntPtr transaction);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetLobbyUpdateTransactionMethod(IntPtr methodsPtr, long lobbyId, ref IntPtr transaction);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetMemberUpdateTransactionMethod(IntPtr methodsPtr, long lobbyId, long userId, ref IntPtr transaction);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void CreateLobbyCallback(IntPtr ptr, Result result, ref Lobby lobby);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void CreateLobbyMethod(IntPtr methodsPtr, IntPtr transaction, IntPtr callbackData, CreateLobbyCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void UpdateLobbyCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void UpdateLobbyMethod(IntPtr methodsPtr, long lobbyId, IntPtr transaction, IntPtr callbackData, UpdateLobbyCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void DeleteLobbyCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void DeleteLobbyMethod(IntPtr methodsPtr, long lobbyId, IntPtr callbackData, DeleteLobbyCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ConnectLobbyCallback(IntPtr ptr, Result result, ref Lobby lobby);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ConnectLobbyMethod(IntPtr methodsPtr, long lobbyId, [MarshalAs(UnmanagedType.LPStr)] string secret, IntPtr callbackData, ConnectLobbyCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ConnectLobbyWithActivitySecretCallback(IntPtr ptr, Result result, ref Lobby lobby);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ConnectLobbyWithActivitySecretMethod(IntPtr methodsPtr, [MarshalAs(UnmanagedType.LPStr)] string activitySecret, IntPtr callbackData, ConnectLobbyWithActivitySecretCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void DisconnectLobbyCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void DisconnectLobbyMethod(IntPtr methodsPtr, long lobbyId, IntPtr callbackData, DisconnectLobbyCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetLobbyMethod(IntPtr methodsPtr, long lobbyId, ref Lobby lobby);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetLobbyActivitySecretMethod(IntPtr methodsPtr, long lobbyId, StringBuilder secret);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetLobbyMetadataValueMethod(IntPtr methodsPtr, long lobbyId, [MarshalAs(UnmanagedType.LPStr)] string key, StringBuilder value);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetLobbyMetadataKeyMethod(IntPtr methodsPtr, long lobbyId, int index, StringBuilder key);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result LobbyMetadataCountMethod(IntPtr methodsPtr, long lobbyId, ref int count);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result MemberCountMethod(IntPtr methodsPtr, long lobbyId, ref int count);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetMemberUserIdMethod(IntPtr methodsPtr, long lobbyId, int index, ref long userId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetMemberUserMethod(IntPtr methodsPtr, long lobbyId, long userId, ref User user);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetMemberMetadataValueMethod(IntPtr methodsPtr, long lobbyId, long userId, [MarshalAs(UnmanagedType.LPStr)] string key, StringBuilder value);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetMemberMetadataKeyMethod(IntPtr methodsPtr, long lobbyId, long userId, int index, StringBuilder key);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result MemberMetadataCountMethod(IntPtr methodsPtr, long lobbyId, long userId, ref int count);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void UpdateMemberCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void UpdateMemberMethod(IntPtr methodsPtr, long lobbyId, long userId, IntPtr transaction, IntPtr callbackData, UpdateMemberCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SendLobbyMessageCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SendLobbyMessageMethod(IntPtr methodsPtr, long lobbyId, byte[] data, int dataLen, IntPtr callbackData, SendLobbyMessageCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetSearchQueryMethod(IntPtr methodsPtr, ref IntPtr query);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SearchCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SearchMethod(IntPtr methodsPtr, IntPtr query, IntPtr callbackData, SearchCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void LobbyCountMethod(IntPtr methodsPtr, ref int count);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetLobbyIdMethod(IntPtr methodsPtr, int index, ref long lobbyId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ConnectVoiceCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ConnectVoiceMethod(IntPtr methodsPtr, long lobbyId, IntPtr callbackData, ConnectVoiceCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void DisconnectVoiceCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void DisconnectVoiceMethod(IntPtr methodsPtr, long lobbyId, IntPtr callbackData, DisconnectVoiceCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result ConnectNetworkMethod(IntPtr methodsPtr, long lobbyId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result DisconnectNetworkMethod(IntPtr methodsPtr, long lobbyId);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result FlushNetworkMethod(IntPtr methodsPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result OpenNetworkChannelMethod(IntPtr methodsPtr, long lobbyId, byte channelId, bool reliable);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result SendNetworkMessageMethod(IntPtr methodsPtr, long lobbyId, long userId, byte channelId, byte[] data, int dataLen);

			internal GetLobbyCreateTransactionMethod GetLobbyCreateTransaction;

			internal GetLobbyUpdateTransactionMethod GetLobbyUpdateTransaction;

			internal GetMemberUpdateTransactionMethod GetMemberUpdateTransaction;

			internal CreateLobbyMethod CreateLobby;

			internal UpdateLobbyMethod UpdateLobby;

			internal DeleteLobbyMethod DeleteLobby;

			internal ConnectLobbyMethod ConnectLobby;

			internal ConnectLobbyWithActivitySecretMethod ConnectLobbyWithActivitySecret;

			internal DisconnectLobbyMethod DisconnectLobby;

			internal GetLobbyMethod GetLobby;

			internal GetLobbyActivitySecretMethod GetLobbyActivitySecret;

			internal GetLobbyMetadataValueMethod GetLobbyMetadataValue;

			internal GetLobbyMetadataKeyMethod GetLobbyMetadataKey;

			internal LobbyMetadataCountMethod LobbyMetadataCount;

			internal MemberCountMethod MemberCount;

			internal GetMemberUserIdMethod GetMemberUserId;

			internal GetMemberUserMethod GetMemberUser;

			internal GetMemberMetadataValueMethod GetMemberMetadataValue;

			internal GetMemberMetadataKeyMethod GetMemberMetadataKey;

			internal MemberMetadataCountMethod MemberMetadataCount;

			internal UpdateMemberMethod UpdateMember;

			internal SendLobbyMessageMethod SendLobbyMessage;

			internal GetSearchQueryMethod GetSearchQuery;

			internal SearchMethod Search;

			internal LobbyCountMethod LobbyCount;

			internal GetLobbyIdMethod GetLobbyId;

			internal ConnectVoiceMethod ConnectVoice;

			internal DisconnectVoiceMethod DisconnectVoice;

			internal ConnectNetworkMethod ConnectNetwork;

			internal DisconnectNetworkMethod DisconnectNetwork;

			internal FlushNetworkMethod FlushNetwork;

			internal OpenNetworkChannelMethod OpenNetworkChannel;

			internal SendNetworkMessageMethod SendNetworkMessage;
		}

		public delegate void CreateLobbyHandler(Result result, ref Lobby lobby);

		public delegate void UpdateLobbyHandler(Result result);

		public delegate void DeleteLobbyHandler(Result result);

		public delegate void ConnectLobbyHandler(Result result, ref Lobby lobby);

		public delegate void ConnectLobbyWithActivitySecretHandler(Result result, ref Lobby lobby);

		public delegate void DisconnectLobbyHandler(Result result);

		public delegate void UpdateMemberHandler(Result result);

		public delegate void SendLobbyMessageHandler(Result result);

		public delegate void SearchHandler(Result result);

		public delegate void ConnectVoiceHandler(Result result);

		public delegate void DisconnectVoiceHandler(Result result);

		public delegate void LobbyUpdateHandler(long lobbyId);

		public delegate void LobbyDeleteHandler(long lobbyId, uint reason);

		public delegate void MemberConnectHandler(long lobbyId, long userId);

		public delegate void MemberUpdateHandler(long lobbyId, long userId);

		public delegate void MemberDisconnectHandler(long lobbyId, long userId);

		public delegate void LobbyMessageHandler(long lobbyId, long userId, byte[] data);

		public delegate void SpeakingHandler(long lobbyId, long userId, bool speaking);

		public delegate void NetworkMessageHandler(long lobbyId, long userId, byte channelId, byte[] data);

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public event LobbyUpdateHandler OnLobbyUpdate
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

		public event LobbyDeleteHandler OnLobbyDelete
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

		public event MemberConnectHandler OnMemberConnect
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

		public event MemberUpdateHandler OnMemberUpdate
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

		public event MemberDisconnectHandler OnMemberDisconnect
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

		public event LobbyMessageHandler OnLobbyMessage
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

		public event SpeakingHandler OnSpeaking
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

		public event NetworkMessageHandler OnNetworkMessage
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

		internal LobbyManager(IntPtr ptr, IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		public LobbyTransaction GetLobbyCreateTransaction()
		{
			return default(LobbyTransaction);
		}

		public LobbyTransaction GetLobbyUpdateTransaction(long lobbyId)
		{
			return default(LobbyTransaction);
		}

		public LobbyMemberTransaction GetMemberUpdateTransaction(long lobbyId, long userId)
		{
			return default(LobbyMemberTransaction);
		}

		[MonoPInvokeCallback]
		private static void CreateLobbyCallbackImpl(IntPtr ptr, Result result, ref Lobby lobby)
		{
		}

		public void CreateLobby(LobbyTransaction transaction, CreateLobbyHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void UpdateLobbyCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void UpdateLobby(long lobbyId, LobbyTransaction transaction, UpdateLobbyHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void DeleteLobbyCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void DeleteLobby(long lobbyId, DeleteLobbyHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void ConnectLobbyCallbackImpl(IntPtr ptr, Result result, ref Lobby lobby)
		{
		}

		public void ConnectLobby(long lobbyId, string secret, ConnectLobbyHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void ConnectLobbyWithActivitySecretCallbackImpl(IntPtr ptr, Result result, ref Lobby lobby)
		{
		}

		public void ConnectLobbyWithActivitySecret(string activitySecret, ConnectLobbyWithActivitySecretHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void DisconnectLobbyCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void DisconnectLobby(long lobbyId, DisconnectLobbyHandler callback)
		{
		}

		public Lobby GetLobby(long lobbyId)
		{
			return default(Lobby);
		}

		public string GetLobbyActivitySecret(long lobbyId)
		{
			return null;
		}

		public string GetLobbyMetadataValue(long lobbyId, string key)
		{
			return null;
		}

		public string GetLobbyMetadataKey(long lobbyId, int index)
		{
			return null;
		}

		public int LobbyMetadataCount(long lobbyId)
		{
			return 0;
		}

		public int MemberCount(long lobbyId)
		{
			return 0;
		}

		public long GetMemberUserId(long lobbyId, int index)
		{
			return 0L;
		}

		public User GetMemberUser(long lobbyId, long userId)
		{
			return default(User);
		}

		public string GetMemberMetadataValue(long lobbyId, long userId, string key)
		{
			return null;
		}

		public string GetMemberMetadataKey(long lobbyId, long userId, int index)
		{
			return null;
		}

		public int MemberMetadataCount(long lobbyId, long userId)
		{
			return 0;
		}

		[MonoPInvokeCallback]
		private static void UpdateMemberCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void UpdateMember(long lobbyId, long userId, LobbyMemberTransaction transaction, UpdateMemberHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void SendLobbyMessageCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void SendLobbyMessage(long lobbyId, byte[] data, SendLobbyMessageHandler callback)
		{
		}

		public LobbySearchQuery GetSearchQuery()
		{
			return default(LobbySearchQuery);
		}

		[MonoPInvokeCallback]
		private static void SearchCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void Search(LobbySearchQuery query, SearchHandler callback)
		{
		}

		public int LobbyCount()
		{
			return 0;
		}

		public long GetLobbyId(int index)
		{
			return 0L;
		}

		[MonoPInvokeCallback]
		private static void ConnectVoiceCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void ConnectVoice(long lobbyId, ConnectVoiceHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void DisconnectVoiceCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void DisconnectVoice(long lobbyId, DisconnectVoiceHandler callback)
		{
		}

		public void ConnectNetwork(long lobbyId)
		{
		}

		public void DisconnectNetwork(long lobbyId)
		{
		}

		public void FlushNetwork()
		{
		}

		public void OpenNetworkChannel(long lobbyId, byte channelId, bool reliable)
		{
		}

		public void SendNetworkMessage(long lobbyId, long userId, byte channelId, byte[] data)
		{
		}

		[MonoPInvokeCallback]
		private static void OnLobbyUpdateImpl(IntPtr ptr, long lobbyId)
		{
		}

		[MonoPInvokeCallback]
		private static void OnLobbyDeleteImpl(IntPtr ptr, long lobbyId, uint reason)
		{
		}

		[MonoPInvokeCallback]
		private static void OnMemberConnectImpl(IntPtr ptr, long lobbyId, long userId)
		{
		}

		[MonoPInvokeCallback]
		private static void OnMemberUpdateImpl(IntPtr ptr, long lobbyId, long userId)
		{
		}

		[MonoPInvokeCallback]
		private static void OnMemberDisconnectImpl(IntPtr ptr, long lobbyId, long userId)
		{
		}

		[MonoPInvokeCallback]
		private static void OnLobbyMessageImpl(IntPtr ptr, long lobbyId, long userId, IntPtr dataPtr, int dataLen)
		{
		}

		[MonoPInvokeCallback]
		private static void OnSpeakingImpl(IntPtr ptr, long lobbyId, long userId, bool speaking)
		{
		}

		[MonoPInvokeCallback]
		private static void OnNetworkMessageImpl(IntPtr ptr, long lobbyId, long userId, byte channelId, IntPtr dataPtr, int dataLen)
		{
		}

		public IEnumerable<User> GetMemberUsers(long lobbyID)
		{
			return null;
		}

		public void SendLobbyMessage(long lobbyID, string data, SendLobbyMessageHandler handler)
		{
		}
	}
}
