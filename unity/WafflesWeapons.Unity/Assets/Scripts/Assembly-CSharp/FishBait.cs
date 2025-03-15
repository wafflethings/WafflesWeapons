using UnityEngine;

public class FishBait : MonoBehaviour
{
	public Transform baitPoint;

	[SerializeField]
	private LineRenderer lineRenderer;

	[SerializeField]
	private GameObject splashPrefab;

	[SerializeField]
	private GameObject fishHookedPrefab;

	private GameObject fishHookedSpawned;

	private Transform initialParent;

	private Vector3 landTarget;

	private FishingRodWeapon sourceWeapon;

	public bool landed;

	public float flyProgress;

	private float fishPullVelocity;

	private float overrideLastMile;

	public bool allowedToProgress;

	private bool returnToRod;

	private bool outOfWater;

	private Transform spawnedFish;

	private void Update()
	{
	}

	private void ThrowAnim()
	{
	}

	private void ReturnAnim()
	{
	}

	private void UpdateLineRenderer()
	{
	}

	public void ThrowStart(Vector3 targetWorldPosition, Transform inPar, FishingRodWeapon srcWpn)
	{
	}

	public void FishHooked()
	{
	}

	public void Dispose()
	{
	}

	public void CatchFish(FishObject fish)
	{
	}

	public void OutOfWater()
	{
	}

	public void OnTriggerExit(Collider other)
	{
	}

	public void OnCollisionEnter(Collision collision)
	{
	}
}
