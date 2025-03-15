using UnityEngine;

public class FishingRodWeapon : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private FishingRodTarget targetPrefab;

	[SerializeField]
	private FishBait baitPrefab;

	[SerializeField]
	private Transform rodTip;

	[SerializeField]
	private ItemIdentifier fishPickupTemplate;

	public AudioSource pullSound;

	private FishingRodTarget targetingCircle;

	private FishBait spawnedBaitCon;

	private FishingRodState state;

	private float selectedPower;

	private bool climaxed;

	private static readonly int Set;

	private static readonly int Throw;

	private bool baitThrown;

	private float distanceAfterThrow;

	private bool fishHooked;

	private FishDB currentFishPool;

	private Water currentWater;

	private FishDescriptor hookedFishe;

	private static readonly int Pull;

	private static readonly int Idle;

	private float fishTolerance;

	private float fishDesirePosition;

	private float playerProvidedPosition;

	private float playerPositionVelocity;

	private TimeSince timeSinceBaitInWater;

	private TimeSince timeSinceAction;

	private bool noFishErrorDisplayed;

	public static float suggestedDistanceMulti;

	public static float minDistanceMulti;

	private float bottomBound => 0f;

	private float topBound => 0f;

	private bool struggleSatisfied => false;

	private Vector3 approximateTargetPosition => default(Vector3);

	public void ThrowBaitEvent()
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public static GameObject CreateFishPickup(ItemIdentifier template, FishObject fish, bool grab, bool unlock = true)
	{
		return null;
	}

	public void FishCaughtAndGrabbed()
	{
	}

	private void ResetFishing()
	{
	}

	private void OnGUI()
	{
	}

	private void Update()
	{
	}
}
