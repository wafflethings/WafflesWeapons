using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class GunColorController : MonoSingleton<GunColorController>
{
	public static int[] requiredSecrets;

	public GunColorPreset[] revolverColors;

	public GunColorPreset[] shotgunColors;

	public GunColorPreset[] nailgunColors;

	public GunColorPreset[] railcannonColors;

	public GunColorPreset[] rocketLauncherColors;

	[HideInInspector]
	public GunColorPreset[] currentColors;

	[HideInInspector]
	public GunColorPreset[] currentAltColors;

	[HideInInspector]
	public int[] presets;

	[HideInInspector]
	public int[] altPresets;

	[HideInInspector]
	public bool[] hasUnlockedColors;

	[HideInInspector]
	public MaterialPropertyBlock[] currentPropBlocks;

	[HideInInspector]
	public MaterialPropertyBlock[] currentAltPropBlocks;

	[HideInInspector]
	public int weaponCount;

	private void Start()
	{
	}

	public void UpdateGunColors()
	{
	}

	private void UpdateColor(int gunNumber, bool altVersion)
	{
	}

	private void SetCustomColors(int gunNumber, bool altVersion, int[] presetArray = null)
	{
	}

	private GunColorPreset[] GetColorPresets(GameProgressSaver.WeaponCustomizationType weaponType)
	{
		return null;
	}

	private GunColorPreset CustomGunColorPreset(int gunNumber, bool altVersion)
	{
		return null;
	}

	private Color GetGunColor(int number, int gunNumber, bool altVersion)
	{
		return default(Color);
	}
}
