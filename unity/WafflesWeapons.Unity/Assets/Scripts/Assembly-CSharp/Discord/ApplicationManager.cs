using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Discord
{
	public class ApplicationManager
	{
		internal struct FFIEvents
		{
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ValidateOrExitCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void ValidateOrExitMethod(IntPtr methodsPtr, IntPtr callbackData, ValidateOrExitCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetCurrentLocaleMethod(IntPtr methodsPtr, StringBuilder locale);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetCurrentBranchMethod(IntPtr methodsPtr, StringBuilder branch);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetOAuth2TokenCallback(IntPtr ptr, Result result, ref OAuth2Token oauth2Token);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetOAuth2TokenMethod(IntPtr methodsPtr, IntPtr callbackData, GetOAuth2TokenCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetTicketCallback(IntPtr ptr, Result result, [MarshalAs(UnmanagedType.LPStr)] ref string data);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void GetTicketMethod(IntPtr methodsPtr, IntPtr callbackData, GetTicketCallback callback);

			internal ValidateOrExitMethod ValidateOrExit;

			internal GetCurrentLocaleMethod GetCurrentLocale;

			internal GetCurrentBranchMethod GetCurrentBranch;

			internal GetOAuth2TokenMethod GetOAuth2Token;

			internal GetTicketMethod GetTicket;
		}

		public delegate void ValidateOrExitHandler(Result result);

		public delegate void GetOAuth2TokenHandler(Result result, ref OAuth2Token oauth2Token);

		public delegate void GetTicketHandler(Result result, ref string data);

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		internal ApplicationManager(IntPtr ptr, IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		[MonoPInvokeCallback]
		private static void ValidateOrExitCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void ValidateOrExit(ValidateOrExitHandler callback)
		{
		}

		public string GetCurrentLocale()
		{
			return null;
		}

		public string GetCurrentBranch()
		{
			return null;
		}

		[MonoPInvokeCallback]
		private static void GetOAuth2TokenCallbackImpl(IntPtr ptr, Result result, ref OAuth2Token oauth2Token)
		{
		}

		public void GetOAuth2Token(GetOAuth2TokenHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void GetTicketCallbackImpl(IntPtr ptr, Result result, ref string data)
		{
		}

		public void GetTicket(GetTicketHandler callback)
		{
		}
	}
}
