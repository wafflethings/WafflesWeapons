using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Discord
{
	public class StoreManager
	{
		internal struct FFIEvents
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void EntitlementCreateHandler(IntPtr ptr, ref Entitlement entitlement);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void EntitlementDeleteHandler(IntPtr ptr, ref Entitlement entitlement);

			internal EntitlementCreateHandler OnEntitlementCreate;

			internal EntitlementDeleteHandler OnEntitlementDelete;
		}

		internal struct FFIMethods
		{
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void FetchSkusCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void FetchSkusMethod(IntPtr methodsPtr, IntPtr callbackData, FetchSkusCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void CountSkusMethod(IntPtr methodsPtr, ref int count);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetSkuMethod(IntPtr methodsPtr, long skuId, ref Sku sku);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetSkuAtMethod(IntPtr methodsPtr, int index, ref Sku sku);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void FetchEntitlementsCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void FetchEntitlementsMethod(IntPtr methodsPtr, IntPtr callbackData, FetchEntitlementsCallback callback);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void CountEntitlementsMethod(IntPtr methodsPtr, ref int count);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetEntitlementMethod(IntPtr methodsPtr, long entitlementId, ref Entitlement entitlement);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result GetEntitlementAtMethod(IntPtr methodsPtr, int index, ref Entitlement entitlement);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Result HasSkuEntitlementMethod(IntPtr methodsPtr, long skuId, ref bool hasEntitlement);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void StartPurchaseCallback(IntPtr ptr, Result result);

			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void StartPurchaseMethod(IntPtr methodsPtr, long skuId, IntPtr callbackData, StartPurchaseCallback callback);

			internal FetchSkusMethod FetchSkus;

			internal CountSkusMethod CountSkus;

			internal GetSkuMethod GetSku;

			internal GetSkuAtMethod GetSkuAt;

			internal FetchEntitlementsMethod FetchEntitlements;

			internal CountEntitlementsMethod CountEntitlements;

			internal GetEntitlementMethod GetEntitlement;

			internal GetEntitlementAtMethod GetEntitlementAt;

			internal HasSkuEntitlementMethod HasSkuEntitlement;

			internal StartPurchaseMethod StartPurchase;
		}

		public delegate void FetchSkusHandler(Result result);

		public delegate void FetchEntitlementsHandler(Result result);

		public delegate void StartPurchaseHandler(Result result);

		public delegate void EntitlementCreateHandler(ref Entitlement entitlement);

		public delegate void EntitlementDeleteHandler(ref Entitlement entitlement);

		private IntPtr MethodsPtr;

		private object MethodsStructure;

		private FFIMethods Methods => default(FFIMethods);

		public event EntitlementCreateHandler OnEntitlementCreate
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

		public event EntitlementDeleteHandler OnEntitlementDelete
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

		internal StoreManager(IntPtr ptr, IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		private void InitEvents(IntPtr eventsPtr, ref FFIEvents events)
		{
		}

		[MonoPInvokeCallback]
		private static void FetchSkusCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void FetchSkus(FetchSkusHandler callback)
		{
		}

		public int CountSkus()
		{
			return 0;
		}

		public Sku GetSku(long skuId)
		{
			return default(Sku);
		}

		public Sku GetSkuAt(int index)
		{
			return default(Sku);
		}

		[MonoPInvokeCallback]
		private static void FetchEntitlementsCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void FetchEntitlements(FetchEntitlementsHandler callback)
		{
		}

		public int CountEntitlements()
		{
			return 0;
		}

		public Entitlement GetEntitlement(long entitlementId)
		{
			return default(Entitlement);
		}

		public Entitlement GetEntitlementAt(int index)
		{
			return default(Entitlement);
		}

		public bool HasSkuEntitlement(long skuId)
		{
			return false;
		}

		[MonoPInvokeCallback]
		private static void StartPurchaseCallbackImpl(IntPtr ptr, Result result)
		{
		}

		public void StartPurchase(long skuId, StartPurchaseHandler callback)
		{
		}

		[MonoPInvokeCallback]
		private static void OnEntitlementCreateImpl(IntPtr ptr, ref Entitlement entitlement)
		{
		}

		[MonoPInvokeCallback]
		private static void OnEntitlementDeleteImpl(IntPtr ptr, ref Entitlement entitlement)
		{
		}

		public IEnumerable<Entitlement> GetEntitlements()
		{
			return null;
		}

		public IEnumerable<Sku> GetSkus()
		{
			return null;
		}
	}
}
