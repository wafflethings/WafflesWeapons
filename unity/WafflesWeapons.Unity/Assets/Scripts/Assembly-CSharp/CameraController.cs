using UnityEngine;
using UnityEngine.Audio;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class CameraController : MonoSingleton<CameraController>
{
	public bool invert;

	public float minimumX;

	public float maximumX;

	public float minimumY;

	public float maximumY;

	public OptionsManager opm;

	public float scroll;

	public Vector3 defaultTarget;

	public Vector3 originalPos;

	public Vector3 defaultPos;

	private Vector3 targetPos;

	public GameObject player;

	public NewMovement pm;

	[HideInInspector]
	public Camera cam;

	public bool activated;

	public int gamepadFreezeCount;

	public float rotationY;

	public float rotationX;

	public bool reverseX;

	public bool reverseY;

	public float cameraShaking;

	public float movementHor;

	public float movementVer;

	public int dodgeDirection;

	public float defaultFov;

	private AudioMixer[] audmix;

	private bool mouseUnlocked;

	public bool slide;

	private AssistController asscon;

	[SerializeField]
	private GameObject parryLight;

	[SerializeField]
	private GameObject parryFlash;

	[SerializeField]
	private Camera hudCamera;

	private float aspectRatio;

	private bool pixeled;

	private bool tilt;

	private float currentStop;

	private bool zooming;

	private float zoomTarget;

	private LayerMask environmentMask;

	public bool platformerCamera;

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	public void CameraShake(float shakeAmount)
	{
	}

	public void StopShake()
	{
	}

	public void ResetCamera(float degreesY, float degreesX = 0f)
	{
	}

	public void Zoom(float amount)
	{
	}

	public void StopZoom()
	{
	}

	public void ResetToDefaultPos()
	{
	}

	public Vector3 GetDefaultPos()
	{
		return default(Vector3);
	}

	public void CheckAspectRatio()
	{
	}

	public void CheckMouseReverse()
	{
	}
}
