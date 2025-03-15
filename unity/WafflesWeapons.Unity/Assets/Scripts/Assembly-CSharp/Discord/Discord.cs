using System;
using System.Runtime.InteropServices;

namespace Discord
{
	public class Discord : IDisposable
	{
		internal struct FFIEvents
		{
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void DestroyHandler(IntPtr MethodsPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result RunCallbacksMethod(IntPtr methodsPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SetLogHookCallback(IntPtr ptr, LogLevel level, [MarshalAs(UnmanagedType.LPStr)] string message);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void SetLogHookMethod(IntPtr methodsPtr, LogLevel minLevel, IntPtr callbackData, SetLogHookCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetApplicationManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetUserManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetImageManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetActivityManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetRelationshipManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetLobbyManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetNetworkManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetOverlayManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetStorageManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetStoreManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetVoiceManagerMethod(IntPtr discordPtr);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr GetAchievementManagerMethod(IntPtr discordPtr);

			internal DestroyHandler Destroy;

			internal RunCallbacksMethod RunCallbacks;

			internal SetLogHookMethod SetLogHook;

			internal GetApplicationManagerMethod GetApplicationManager;

			internal GetUserManagerMethod GetUserManager;

			internal GetImageManagerMethod GetImageManager;

			internal GetActivityManagerMethod GetActivityManager;

			internal GetRelationshipManagerMethod GetRelationshipManager;

			internal GetLobbyManagerMethod GetLobbyManager;

			internal GetNetworkManagerMethod GetNetworkManager;

			internal GetOverlayManagerMethod GetOverlayManager;

			internal GetStorageManagerMethod GetStorageManager;

			internal GetStoreManagerMethod GetStoreManager;

			internal GetVoiceManagerMethod GetVoiceManager;

			internal GetAchievementManagerMethod GetAchievementManager;
		}

		internal struct FFICreateParams
		{
			internal long ClientId;

			internal ulong Flags;

			internal IntPtr Events;

			internal IntPtr EventData;

			internal IntPtr ApplicationEvents;

			internal uint ApplicationVersion;

			internal IntPtr UserEvents;

			internal uint UserVersion;

			internal IntPtr ImageEvents;

			internal uint ImageVersion;

			internal IntPtr ActivityEvents;

			internal uint ActivityVersion;

			internal IntPtr RelationshipEvents;

			internal uint RelationshipVersion;

			internal IntPtr LobbyEvents;

			internal uint LobbyVersion;

			internal IntPtr NetworkEvents;

			internal uint NetworkVersion;

			internal IntPtr OverlayEvents;

			internal uint OverlayVersion;

			internal IntPtr StorageEvents;

			internal uint StorageVersion;

			internal IntPtr StoreEvents;

			internal uint StoreVersion;

			internal IntPtr VoiceEvents;

			internal uint VoiceVersion;

			internal IntPtr AchievementEvents;

			internal uint AchievementVersion;
		}

		public delegate void SetLogHookHandler(LogLevel level, string message);

		private GCHandle SelfHandle;

		private IntPtr EventsPtr;

		private FFIEvents Events;

		private IntPtr ApplicationEventsPtr;

		private ApplicationManager.FFIEvents ApplicationEvents;

		internal ApplicationManager ApplicationManagerInstance;

		private IntPtr UserEventsPtr;

		private UserManager.FFIEvents UserEvents;

		internal UserManager UserManagerInstance;

		private IntPtr ImageEventsPtr;

		private ImageManager.FFIEvents ImageEvents;

		internal ImageManager ImageManagerInstance;

		private IntPtr ActivityEventsPtr;

		private ActivityManager.FFIEvents ActivityEvents;

		internal ActivityManager ActivityManagerInstance;

		private IntPtr RelationshipEventsPtr;

		private RelationshipManager.FFIEvents RelationshipEvents;

		internal RelationshipManager RelationshipManagerInstance;

		private IntPtr LobbyEventsPtr;

		private LobbyManager.FFIEvents LobbyEvents;

		internal LobbyManager LobbyManagerInstance;

		private IntPtr NetworkEventsPtr;

		private NetworkManager.FFIEvents NetworkEvents;

		internal NetworkManager NetworkManagerInstance;

		private IntPtr OverlayEventsPtr;

		private OverlayManager.FFIEvents OverlayEvents;

		internal OverlayManager OverlayManagerInstance;

		private IntPtr StorageEventsPtr;

		private StorageManager.FFIEvents StorageEvents;

		internal StorageManager StorageManagerInstance;

		private IntPtr StoreEventsPtr;

		private StoreManager.FFIEvents StoreEvents;

		internal StoreManager StoreManagerInstance;

		private IntPtr VoiceEventsPtr;

		private VoiceManager.FFIEvents VoiceEvents;

		internal VoiceManager VoiceManagerInstance;

		private IntPtr AchievementEventsPtr;

		private AchievementManager.FFIEvents AchievementEvents;

		internal AchievementManager AchievementManagerInstance;

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private GCHandle? setLogHook;

		private FFIMethods Methods => default(FFIMethods);

		[DllImport("discord_game_sdk", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		private static extern Result DiscordCreate(uint version, ref FFICreateParams createParams, out IntPtr manager);

		public Discord(long clientId, ulong flags)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		public void Dispose()
		{
		}

		public void RunCallbacks()
		{
		}

		[MonoPInvokeCallback]
		private static void SetLogHookCallbackImpl(IntPtr ptr, LogLevel level, string message)
		{
		}

		public void SetLogHook(LogLevel minLevel, SetLogHookHandler callback)
		{
		}

		public ApplicationManager GetApplicationManager()
		{
			return null;
		}

		public UserManager GetUserManager()
		{
			return null;
		}

		public ImageManager GetImageManager()
		{
			return null;
		}

		public ActivityManager GetActivityManager()
		{
			return null;
		}

		public RelationshipManager GetRelationshipManager()
		{
			return null;
		}

		public LobbyManager GetLobbyManager()
		{
			return null;
		}

		public NetworkManager GetNetworkManager()
		{
			return null;
		}

		public OverlayManager GetOverlayManager()
		{
			return null;
		}

		public StorageManager GetStorageManager()
		{
			return null;
		}

		public StoreManager GetStoreManager()
		{
			return null;
		}

		public VoiceManager GetVoiceManager()
		{
			return null;
		}

		public AchievementManager GetAchievementManager()
		{
			return null;
		}
	}
}
