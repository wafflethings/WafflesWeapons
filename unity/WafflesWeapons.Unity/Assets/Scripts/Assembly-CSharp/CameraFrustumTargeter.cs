using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class CameraFrustumTargeter : MonoSingleton<CameraFrustumTargeter>
{
	private const int MaxPotentialTargets = 256;

	public static bool isEnabled;

	[SerializeField]
	private RectTransform crosshair;

	[SerializeField]
	private LayerMask mask;

	private LayerMask occlusionMask;

	[SerializeField]
	private float maximumRange;

	public float maxHorAim;

	private RaycastHit[] occluders;

	private Plane[] frustum;

	private Vector3[] corners;

	private Bounds bounds;

	private Collider[] targets;

	private Camera camera;

	public Collider CurrentTarget { get; private set; }

	public bool IsAutoAimed { get; private set; }

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

	private bool RaycastFromViewportCenter(out RaycastHit hit)
	{
		hit = default(RaycastHit);
		return false;
	}

	private void CalculateFrustumInformation()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}
}
