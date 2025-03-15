using UnityEngine.InputSystem;
using plog;

public static class InputExtensions
{
	private const bool DebugLogging = false;

	private static readonly Logger Log;

	public static string GetBindingDisplayStringWithoutOverride(this InputAction action, InputBinding binding, InputBinding.DisplayStringOptions options = (InputBinding.DisplayStringOptions)0)
	{
		return null;
	}

	public static void WipeAction(this InputAction action, string controlScheme)
	{
	}

	public static bool IsActionEqual(this InputAction action, InputAction baseAction, string controlScheme = null)
	{
		return false;
	}

	public static bool IsBindingEqual(this InputBinding binding, InputBinding other)
	{
		return false;
	}

	public static bool BindingHasGroup(this InputAction action, InputBinding binding, string group)
	{
		return false;
	}

	public static bool BindingHasGroup(this InputAction action, int i, string group)
	{
		return false;
	}

	public static int[] GetBindingsWithGroup(this InputAction action, string group)
	{
		return null;
	}

	private static bool AreStringsEqual(string str1, string str2)
	{
		return false;
	}
}
