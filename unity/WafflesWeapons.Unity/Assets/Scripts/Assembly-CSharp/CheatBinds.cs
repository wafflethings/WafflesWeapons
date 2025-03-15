using System.Collections.Generic;
using UnityEngine.InputSystem;

public class CheatBinds : MonoSingleton<CheatBinds>
{
	public Dictionary<string, InputActionState> registeredCheatBinds;

	public bool isRebinding;

	private readonly Dictionary<string, string> defaultBinds;

	private readonly string[] bannedBinds;

	private InputAction rebindAction;

	private ICheat rebindCheat;

	protected override void Awake()
	{
	}

	public void RestoreBinds(Dictionary<string, List<ICheat>> allRegisteredCheats)
	{
	}

	public void ResetCheatBind(string cheatIdentifier)
	{
	}

	public void CancelRebind()
	{
	}

	public void SetupRebind(ICheat targetCheat)
	{
	}

	protected override void OnDestroy()
	{
	}

	private void Rebind(string cheatIdentifier, string path)
	{
	}

	private void AddBinding(string cheatIdentifier, string path)
	{
	}

	public string ResolveCheatKey(string cheatIdentifier)
	{
		return null;
	}
}
