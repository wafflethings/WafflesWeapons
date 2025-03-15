using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class GamepadObjectSelector : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CSelectFirstChildOnNextFrame_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GamepadObjectSelector _003C_003E4__this;

		public GameObject obj;

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
		public _003CSelectFirstChildOnNextFrame_003Ed__18(int _003C_003E1__state)
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

	private static Stack<GamepadObjectSelector> s_Selectors;

	[SerializeField]
	private bool selectOnEnable;

	[SerializeField]
	private bool firstChild;

	[SerializeField]
	private bool allowNonInteractable;

	[SerializeField]
	private bool topOnly;

	[SerializeField]
	private bool dontMarkTop;

	[SerializeField]
	[FormerlySerializedAs("target")]
	private GameObject mainTarget;

	[SerializeField]
	private GameObject fallbackTarget;

	private GameObject target => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void Activate()
	{
	}

	public static void DisableTop()
	{
	}

	public void PopTop()
	{
	}

	public void SetTop()
	{
	}

	public void SetMainTarget(Selectable sel)
	{
	}

	[IteratorStateMachine(typeof(_003CSelectFirstChildOnNextFrame_003Ed__18))]
	private IEnumerator SelectFirstChildOnNextFrame(GameObject obj)
	{
		return null;
	}

	private GameObject SelectFirstChild(GameObject obj)
	{
		return null;
	}
}
