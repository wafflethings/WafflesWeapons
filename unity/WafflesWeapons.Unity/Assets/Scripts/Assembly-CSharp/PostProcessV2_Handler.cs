using System;
using UnityEngine;
using UnityEngine.Rendering;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PostProcessV2_Handler : MonoSingleton<PostProcessV2_Handler>
{
	public ComputeShader outlineCompute;

	public Material postProcessV2_VSRM;

	[Space(10f)]
	public bool useHeightFog;

	public float heightFogStart;

	public float heightFogEnd;

	public Texture oilTex;

	public Texture sandTex;

	public Texture buffTex;

	public Texture ditherTexture;

	public int distance;

	public Camera mainCam;

	public Camera hudCam;

	public Camera virtualCam;

	private RenderBuffer[] buffers;

	private RenderTexture mainTex;

	private RenderTexture reusableBufferA;

	private RenderTexture reusableBufferB;

	public RenderTexture depthBuffer;

	private int width;

	private int height;

	private int lastWidth;

	private int lastHeight;

	private bool reinitializeTextures;

	private bool mainCameraOnly;

	[HideInInspector]
	public float downscaleResolution;

	public Texture CurrentTexture;

	public Texture CurrentMapPaletteOverride;

	public Material radiantBuff;

	private OptionsManager oman;

	public bool debugFooled;

	[SerializeField]
	private ComputeShader paletteCompute;

	private bool isGLCore;

	private CommandBuffer outlineCB;

	private float realDist;

	public Action<bool> onReinitialize;

	private int heightFogStartID;

	private int heightFogEndID;

	public bool usedComputeShadersAtStart;

	private void OnValidate()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	private void SetPixelization(int option)
	{
	}

	private void Start()
	{
	}

	public void Fooled(bool doEnable)
	{
	}

	public void ColorPalette(bool stuff)
	{
	}

	public void ApplyUserColorPalette(Texture tex)
	{
	}

	public void ApplyMapColorPalette(Texture tex)
	{
	}

	private void ReinitializeCameras()
	{
	}

	private void SetupRTs()
	{
	}

	public void SetupOutlines(bool forceOnePixelOutline = false)
	{
	}

	public void ChangeCamera(bool hudless)
	{
	}

	public void OnPreRenderCallback(Camera cam)
	{
	}

	protected override void OnDestroy()
	{
	}
}
