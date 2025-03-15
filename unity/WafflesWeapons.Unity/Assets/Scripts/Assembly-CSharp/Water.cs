using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
	public struct WaterColData
	{
		public float maxHeight;

		public float minHeight;

		public Vector3 position;

		public Quaternion rotation;
	}

	public enum WaterGOType
	{
		none = 0,
		small = 1,
		big = 2,
		continuous = 3,
		bubble = 4,
		wetparticle = 5
	}

	private Dictionary<Collider, WaterObject> tracked;

	[Header("Visual/FX")]
	public Color clr;

	public bool notWet;

	public bool simplifyWaterProcessing;

	[Header("References (Optional)")]
	public FishDB fishDB;

	public Transform overrideFishingPoint;

	public FishObject[] attractFish;

	private Collider[] waterColliders;

	private bool isPlayerUnderWater;

	[HideInInspector]
	public bool isPlayerTouchingWater;

	private DryZoneController dzc;

	private HashSet<Collider> toRemove;

	private List<WaterColData> waterColData;

	private int waterCount;

	private Vector3 gravity;

	private float scaledGravityY;

	private Quaternion lookUp;

	private bool doneThisFrame;

	private PooledWaterStore waterStore;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Cleanup()
	{
	}

	private void FixedUpdate()
	{
	}

	private bool MarkIfStaleObject(WaterObject wObj)
	{
		return false;
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	public void EnterDryZone(Collider other)
	{
	}

	public void ExitDryZone(Collider other)
	{
	}

	public bool IsCollidingWithWater(Collider other)
	{
		return false;
	}

	private void RemoveFromWater(Collider col, bool wasOnTriggerExit)
	{
	}

	private void ApplyWaterForces(WaterObject wObj, bool doBackupCheck)
	{
	}

	private void UpdateContinuousSplash(WaterObject wObj, Vector3 surfacePoint, bool isSubmerged)
	{
	}

	private bool TryGetSurfaceAndIsSubmerged(Collider col, out Vector3 surfacePoint, out bool isSubmerged)
	{
		surfacePoint = default(Vector3);
		isSubmerged = default(bool);
		return false;
	}

	private void TrySpawnSplash(WaterObject wObj)
	{
	}

	public GameObject SpawnBasicSplash(WaterGOType type)
	{
		return null;
	}

	private void AddLowPassFilters(WaterObject wObj)
	{
	}

	private void RemoveLowPassFilters(WaterObject wObj)
	{
	}

	private void SpawnBubbles(WaterObject wObj)
	{
	}

	private void ExtinguishFires(Collider col)
	{
	}

	private void MarkObjectWet(WaterObject wObj)
	{
	}

	private void KillStreetCleaner(WaterObject wObj)
	{
	}

	private void CleanupWaterEffects(WaterObject wObj)
	{
	}

	public void UpdateColor(Color newColor)
	{
	}
}
