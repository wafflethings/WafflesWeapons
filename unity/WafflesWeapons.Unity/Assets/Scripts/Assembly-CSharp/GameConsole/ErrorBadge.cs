using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace GameConsole
{
	public class ErrorBadge : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFlashBadge_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ErrorBadge _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFlashBadge_003Ed__9(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private GameObject badgeContainer;

		[SerializeField]
		private TMP_Text errorCountText;

		[SerializeField]
		private CanvasGroup flashGroup;

		[SerializeField]
		private CanvasGroup alertGroup;

		public bool hidden;

		private readonly CustomYieldInstruction waitTime;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnError()
		{
		}

		[IteratorStateMachine(typeof(_003CFlashBadge_003Ed__9))]
		private IEnumerator FlashBadge()
		{
			return null;
		}

		public void SetEnabled(bool enabled, bool hide = true)
		{
		}

		public void Dismiss()
		{
		}

		private void Update()
		{
		}
	}
}
