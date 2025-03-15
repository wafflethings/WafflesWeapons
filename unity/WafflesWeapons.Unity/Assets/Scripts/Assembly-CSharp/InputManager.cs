using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class InputManager : MonoSingleton<InputManager>
{
	private sealed class ButtonPressListener : IObserver<InputControl>
	{
		public static ButtonPressListener Instance { get; }

		public void OnCompleted()
		{
		}

		public void OnError(Exception error)
		{
		}

		public void OnNext(InputControl value)
		{
		}
	}

	private class BindingInfo
	{
		public InputAction Action;

		public string Name;

		public int Offset;

		public KeyCode DefaultKey;

		public string PrefName => null;
	}

	public Dictionary<string, KeyCode> inputsDictionary;

	public InputActionAsset defaultActions;

	private IDisposable anyButtonListener;

	public bool ScrOn;

	public bool ScrWep;

	public bool ScrVar;

	public bool ScrRev;

	public Action<InputAction> actionModified;

	private BindingInfo[] legacyBindings;

	private InputActionRebindingExtensions.RebindingOperation rebinding;

	public PlayerInput InputSource { get; private set; }

	public InputDevice LastButtonDevice { get; private set; }

	private static IObservable<InputControl> onAnyInput => null;

	public Dictionary<string, KeyCode> Inputs => null;

	private FileInfo savedBindingsFile => null;

	protected override void Awake()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	public void ResetToDefault()
	{
	}

	public void ResetToDefault(InputAction action, InputControlScheme controlScheme)
	{
	}

	public bool PerformingCheatMenuCombo()
	{
		return false;
	}

	public void SaveBindings(InputActionAsset asset)
	{
	}

	public void UpgradeBindings()
	{
	}

	public void WaitForButton(Action<string> onComplete, Action onCancel, List<string> allowedPaths = null)
	{
	}

	public void WaitForButtonSequence(Queue<string> partNames, Action<string> onBeginPart, Action<string, string> onCompletePart, Action onComplete, Action onCancel, List<string> allowedPaths = null)
	{
	}

	public void ClearOtherActions(InputAction action, string path)
	{
	}

	public void Rebind(InputAction action, int? existingIndex, Action onComplete, Action onCancel, InputControlScheme scheme)
	{
	}

	public void RebindComposite(InputAction action, int? existingIndex, Action<string> onBeginPart, Action onComplete, Action onCancel, InputControlScheme scheme)
	{
	}

	public string GetBindingString(Guid actionId)
	{
		return null;
	}

	public string GetBindingString(string nameOrId)
	{
		return null;
	}
}
