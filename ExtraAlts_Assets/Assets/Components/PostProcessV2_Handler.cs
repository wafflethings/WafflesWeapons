using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.IO;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]

public class PostProcessV2_Handler : MonoBehaviour
{
	public Shader outlineJFA_Initialize;
	public Shader outlineJFA_Loop;

	[Space(10)]


	public Material postProcessV2_VSRM;
	public Texture sandTex;
	public Texture ditherTexture;
	public int distance = 1;
	private bool distanceConfirm;
	private Camera mainCam;
	public Camera hudCam;
	public Camera virtualCam;

	RenderBuffer[] buffers = new RenderBuffer[2];
	private RenderTexture mainTex;
	private RenderTexture testTex;
	private RenderTexture hudTex;
	private RenderTexture outlineTex_BufferA;
	private RenderTexture outlineTex_BufferB;

	private Material outlineJFA_Initialize_Mat;
	private Material outlineJFA_Loop_Mat;

	private int width;
	private int height;
	private int lastWidth;
	private int lastHeight;
	private bool resolutionChanged;

	[HideInInspector] public bool enableJFA;
	[HideInInspector] public float downscaleResolution;

	private void Update()
	{
		if(testTex)
		{
			RenderTexture lastActive = RenderTexture.active;
			RenderTexture.active = testTex;
			GL.Clear(false, true, Color.clear);
			RenderTexture.active = lastActive;
		}
	}

	private void ReinitializeCameras()
	{
		if (Application.isPlaying)
		{
			Camera.onPreRender = null;
			Camera.onPreRender = null;
			Camera.onPreRender += OnPreRenderCallback;
			Camera.onPostRender += OnPostRenderCallback;
		}
	}

	private void SolveResolution()
	{
		width = Screen.width;
		height = Screen.height;

		if (downscaleResolution != 0)
		{
			float sWidth = width;
			float sHeight = height;
			float minDim = Mathf.Min(sWidth, sHeight);
			Vector2 screenAspect = new Vector2(sWidth / minDim, sHeight / minDim);

			screenAspect *= downscaleResolution;
			width = (int)screenAspect.x;
			height = (int)screenAspect.y;
		}

		resolutionChanged = !(width == lastWidth && height == lastHeight);
		lastWidth = width;
		lastHeight = height;
		
		postProcessV2_VSRM.SetFloat("_VirtualX", width);
		postProcessV2_VSRM.SetFloat("_VirtualY", height);
	}

	private void SetupRTs()
	{
		if (resolutionChanged)
		{
			// Release old textures
			if (mainTex)
			{
				mainTex.Release();
				Object.Destroy(mainTex);
			}
			if (hudTex)
			{
				hudTex.Release();
				Object.Destroy(hudTex);
			}

			// Setup Main and Hud Camera Textures
			mainTex = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32)
			{
				antiAliasing = 1,
				filterMode = FilterMode.Point
			};

			if (mainTex == null)
				Debug.LogWarning(mainTex);

			testTex = new RenderTexture(width, height, 24, RenderTextureFormat.R8)
			{
				antiAliasing = 1,
				filterMode = FilterMode.Point
			};

			hudTex = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32)
			{
				antiAliasing = 1,
				filterMode = FilterMode.Point
			};

			if (hudTex == null)
				Debug.LogWarning(mainTex);
		}

		// Assignment
		buffers[0] = mainTex.colorBuffer;
		buffers[1] = testTex.colorBuffer;
		//mainCam.targetTexture = mainTex;
		mainCam.SetTargetBuffers(buffers, testTex.depthBuffer);
		outlineJFA_Initialize_Mat.SetTexture("_MainTex", mainTex);
		postProcessV2_VSRM.SetTexture("_MainTex", mainTex);
		postProcessV2_VSRM.SetTexture("_OutlineTex", testTex);

		hudCam.targetTexture = hudTex;
		postProcessV2_VSRM.SetTexture("_HudTex", hudTex);
	}

	private void SetupJFA()
	{
		Vector4 resolutionDifference = new Vector4((float)Screen.width / (float)width, (float)Screen.height / (float)height, 0, 0);
		outlineJFA_Loop_Mat.SetVector("_ResolutionDifference", resolutionDifference);

		Vector2 onePixelDistance = new Vector2(1f, 1f) / new Vector2((float)Screen.width, (float)Screen.height);

		Vector2 virtualDistance = (new Vector2((float)distance, (float)distance) / resolutionDifference) * onePixelDistance;

		distanceConfirm = virtualDistance.x < onePixelDistance.x && virtualDistance.y < onePixelDistance.y;

		postProcessV2_VSRM.SetFloat("_EnableJFA", System.Convert.ToSingle(enableJFA));
		postProcessV2_VSRM.SetFloat("_JFADistance", (float)distance);

		if (resolutionChanged || !enableJFA || distance < 1 || distanceConfirm)
		{
			// Release old textures
			if (outlineTex_BufferA)
			{
				outlineTex_BufferA.Release();
				Object.Destroy(outlineTex_BufferA);
			}

			if (outlineTex_BufferB)
			{
				outlineTex_BufferB.Release();
				Object.Destroy(outlineTex_BufferB);
			}
		}

		if (enableJFA && distance > 1 && !distanceConfirm)
		{
			if (resolutionChanged || !outlineTex_BufferA || !outlineTex_BufferB)
			{
				outlineTex_BufferA = new RenderTexture(width, height, 0, RenderTextureFormat.RGHalf);
				outlineTex_BufferA.antiAliasing = 1;
				outlineTex_BufferA.filterMode = FilterMode.Point;
				outlineTex_BufferB = new RenderTexture(width, height, 0, RenderTextureFormat.RGHalf);
				outlineTex_BufferB.antiAliasing = 1;
				outlineTex_BufferB.filterMode = FilterMode.Point;
			}
		}
	}

	void JFA()
	{
		if (distance > 1 && !distanceConfirm)
		{
			// Initialize in BufferA
			Graphics.Blit(null, outlineTex_BufferA, outlineJFA_Initialize_Mat);

			float searchDistance = ((float)distance + 0.5f) * 0.5f;

			while (searchDistance >= 0.5f)
			{
				outlineJFA_Loop_Mat.SetFloat("_Distance", searchDistance);
				outlineJFA_Loop_Mat.SetTexture("_MainTex", outlineTex_BufferA);
				Graphics.Blit(null, outlineTex_BufferB, outlineJFA_Loop_Mat);
				RenderTexture temp = outlineTex_BufferA;
				outlineTex_BufferA = outlineTex_BufferB;
				outlineTex_BufferB = temp;

				searchDistance *= 0.5f;
			}
			postProcessV2_VSRM.SetTexture("_OutlineTex", outlineTex_BufferA);
		}
	}

	private void Start()
	{
		ReinitializeCameras();
		postProcessV2_VSRM.SetTexture("_Dither", ditherTexture);

		if (sandTex != null)
			Shader.SetGlobalTexture("_SandTex", sandTex);

		outlineJFA_Initialize_Mat = new Material(outlineJFA_Initialize);
		outlineJFA_Loop_Mat = new Material(outlineJFA_Loop);
	}

	public void OnPreRenderCallback(Camera cam)
	{
		if (cam == virtualCam)
		{
			//print(cam);
			SolveResolution();
			SetupRTs();
			SetupJFA();
		}
	}

	void OnPostRenderCallback(Camera cam)
	{

		if (cam == virtualCam)
		{
			if (enableJFA && distance > 1 && !distanceConfirm)
				JFA();
		}
	}

	public void SetOutlineThickness(int newAmount)
    {
		distance = newAmount;
    }

	protected void OnDestroy()
	{
		Camera.onPreRender -= OnPreRenderCallback;
		Camera.onPostRender -= OnPostRenderCallback;
	}
}
