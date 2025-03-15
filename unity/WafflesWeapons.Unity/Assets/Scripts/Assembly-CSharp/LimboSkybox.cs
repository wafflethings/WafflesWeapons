using UnityEngine;

[ExecuteInEditMode]
public class LimboSkybox : MonoBehaviour
{
	public bool lockMinimumHeight;

	public float downscaleFactor;

	public Transform playerStart;

	public Transform fakeCamStart;

	private RenderTexture skybox;

	private Camera fakeCam;

	private int lastWidth;

	private int lastHeight;

	private CameraController cc;

	private Camera playerCam;

	private Vector3 playerStartPos;

	[Header("Fog Settings")]
	public bool useFogOverrides;

	public bool overrideFogDistance;

	public float fogStart;

	public float fogEnd;

	public bool overrideFogColor;

	public Color fogColor;

	private float oldFogStart;

	private float oldFogEnd;

	private Color oldFogColor;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void OnRenderObject()
	{
	}

	private void OnPreRender()
	{
	}

	private void OnPostRender()
	{
	}

	private void UpdateCamera()
	{
	}

	private void InitializeRT()
	{
	}
}
