using System;
using UnityEngine;

// Token: 0x020001A1 RID: 417
public class GunColorGetter : MonoBehaviour
{
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
		throw new NotImplementedException();
	}

	private GunColorPreset GetColors()
	{
		throw new NotImplementedException();
	}

	private Renderer rend;
	public Material[] defaultMaterials;
	public Material[] coloredMaterials;
	public int weaponNumber;
	public bool altVersion;
}

[Serializable]
public class GunColorPreset
{
	public GunColorPreset(Color a, Color b, Color c)
	{

	}

	public Color color1;
	public Color color2;
	public Color color3;
}

