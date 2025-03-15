using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using plog;

public class MainMenuAgony : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCloseMainMenuDelayed_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuAgony _003C_003E4__this;

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
		public _003CCloseMainMenuDelayed_003Ed__9(int _003C_003E1__state)
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

	private static readonly plog.Logger Log;

	public static bool isAgonyOpen;

	[SerializeField]
	private GameObject agonyButton;

	[Space]
	[SerializeField]
	private GameObject normalLights;

	[SerializeField]
	private GameObject agonyLights;

	[Space]
	[SerializeField]
	private GameObject[] agonyMenus;

	[SerializeField]
	private GameObject mainMenu;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CCloseMainMenuDelayed_003Ed__9))]
	private IEnumerator CloseMainMenuDelayed()
	{
		return null;
	}

	private void Update()
	{
	}

	public void OpenAgony(bool restore = false)
	{
	}

	public void CloseAgony()
	{
	}
}
