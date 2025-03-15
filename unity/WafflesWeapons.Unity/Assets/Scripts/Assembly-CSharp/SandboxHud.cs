using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class SandboxHud : MonoSingleton<SandboxHud>
{
	[CompilerGenerated]
	private sealed class _003CFadeOutNotice_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SandboxHud _003C_003E4__this;

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
		public _003CFadeOutNotice_003Ed__18(int _003C_003E1__state)
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

	[Header("Nav")]
	[SerializeField]
	private CanvasGroup navmeshNoticeGroup;

	[Space]
	[SerializeField]
	private GameObject sandboxSavesWindow;

	[SerializeField]
	private SandboxSaveItem sandboxSaveTemplate;

	[SerializeField]
	private Transform savesContainer;

	[Space]
	[SerializeField]
	private InputField newSaveName;

	[SerializeField]
	private Button newSaveButton;

	public static bool SavesMenuOpen => false;

	private void Start()
	{
	}

	private void ResetSavesMenu()
	{
	}

	private void BuildSavesMenu()
	{
	}

	public void OpenDirectory()
	{
	}

	public void UpdateNewSaveInput()
	{
	}

	public void NewSave()
	{
	}

	public void HideSavesMenu()
	{
	}

	public void ShowSavesMenu()
	{
	}

	public void NavmeshDirty()
	{
	}

	private void NavmeshStartFadeOut()
	{
	}

	[IteratorStateMachine(typeof(_003CFadeOutNotice_003Ed__18))]
	private IEnumerator FadeOutNotice()
	{
		return null;
	}

	public void HideNavmeshNotice()
	{
	}
}
