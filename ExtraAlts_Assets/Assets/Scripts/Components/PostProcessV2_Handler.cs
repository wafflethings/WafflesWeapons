using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.IO;
using UnityEngine.Experimental.Rendering;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]

public class PostProcessV2_Handler : MonoSingleton<PostProcessV2_Handler>
{

	 
	public Shader outlineCreate;
	public Material postProcessV2_VSRM;

	[Space(10)]


	public Texture sandTex;
	public Texture buffTex;
	public Texture ditherTexture;
	public int distance = 1;
	public Camera hudCam;
	public Camera virtualCam;

	public Texture CurrentTexture;
	public Texture CurrentMapPaletteOverride;
	public Material radiantBuff;

	[SerializeField] private Material conversionMaterial;


	private void Start() { }
	public void ColorPalette(bool stuff) { }
	public void ApplyUserColorPalette(Texture tex) { }    
	public void ApplyMapColorPalette(Texture tex) { }
	public void ChangeCamera(bool hudless) { }
	public void OnPreRenderCallback(Camera cam) { }
	void OnPostRenderCallback(Camera cam) { }
	protected override void OnDestroy() { }}
