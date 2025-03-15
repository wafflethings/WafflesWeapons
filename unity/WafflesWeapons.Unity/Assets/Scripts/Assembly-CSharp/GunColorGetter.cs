using UnityEngine;

public class GunColorGetter : MonoBehaviour
{
	private Renderer rend;

	public Material[] defaultMaterials;

	public Material[] coloredMaterials;

	private MaterialPropertyBlock customColors;

	public int weaponNumber;

	public bool altVersion;

	private GunColorPreset currentColors;

	private bool hasCustomColors;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void UpdateColor()
	{
	}

	private int GetPreset()
	{
		return 0;
	}

	private GunColorPreset GetColors()
	{
		return null;
	}
}
