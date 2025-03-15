using UnityEngine.InputSystem;

public class InputActionState
{
	public InputAction Action { get; }

	public float PerformedTime { get; private set; }

	public int PerformedFrame { get; private set; }

	public int CanceledFrame { get; private set; }

	public bool IsPressed { get; private set; }

	public string LastUsedBinding { get; private set; }

	public float HoldTime => 0f;

	public bool WasPerformedThisFrame => false;

	public bool WasCanceledThisFrame => false;

	public InputActionState(InputAction action)
	{
	}

	private void OnTriggered(InputAction.CallbackContext context)
	{
	}

	public TValue ReadValue<TValue>() where TValue : struct
	{
		return default(TValue);
	}
}
