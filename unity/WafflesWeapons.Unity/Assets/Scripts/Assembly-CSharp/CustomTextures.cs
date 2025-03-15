using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CustomTextures : DirectoryTreeBrowser<FileInfo>
{
	private enum EditMode
	{
		None = 0,
		Grid = 1,
		Skybox = 2,
		Emission = 3,
		Fog = 4
	}

	[SerializeField]
	private Material[] gridMaterials;

	[SerializeField]
	private OutdoorLightMaster olm;

	[SerializeField]
	private Material skyMaterial;

	[SerializeField]
	private Texture defaultGlow;

	[SerializeField]
	private Texture[] defaultGridTextures;

	[SerializeField]
	private Texture defaultEmission;

	[SerializeField]
	private Texture[] defaultSkyboxes;

	[SerializeField]
	private GameObject gridWrapper;

	[SerializeField]
	private Button gridBtn;

	[SerializeField]
	private Button skyboxBtn;

	[SerializeField]
	private Button emissionBtn;

	[SerializeField]
	private Button fogBtn;

	private Dictionary<string, Texture2D> imageCache;

	private EditMode currentEditMode;

	private bool editBase;

	private bool editTop;

	private bool editTopRow;

	[SerializeField]
	private Button baseBtn;

	[SerializeField]
	private Image baseBtnFrame;

	[SerializeField]
	private Button topBtn;

	[SerializeField]
	private Image topBtnFrame;

	[SerializeField]
	private Button topRowBtn;

	[SerializeField]
	private Image topRowBtnFrame;

	[SerializeField]
	private Slider glowSlider;

	private static readonly int EmissiveTex;

	public static readonly string[] AllowedExtensions;

	private string TexturesPath => null;

	protected override int maxPageLength => 0;

	protected override IDirectoryTree<FileInfo> baseDirectory => null;

	public bool TryToLoad(string key)
	{
		return false;
	}

	public void SetEditMode(int m)
	{
	}

	public void SetGridEditMode(int num)
	{
	}

	public void SetTexture(string key)
	{
	}

	public void SetGlowIntensity()
	{
	}

	private void Start()
	{
	}

	protected override Action BuildLeaf(FileInfo file, int indexInPage)
	{
		return null;
	}

	private Texture2D LoadTexture(string name)
	{
		return null;
	}

	public void RemoveCustomPrefs()
	{
	}

	public void ResetTexture()
	{
	}
}
