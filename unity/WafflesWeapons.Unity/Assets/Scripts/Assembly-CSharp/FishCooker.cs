using UnityEngine;

public class FishCooker : MonoBehaviour
{
	[SerializeField]
	private bool unusable;

	private TimeSince timeSinceLastError;

	[SerializeField]
	private ItemIdentifier fishPickupTemplate;

	[SerializeField]
	private FishObject cookedFish;

	[SerializeField]
	private FishObject failedFish;

	[SerializeField]
	private GameObject cookedSound;

	[SerializeField]
	private GameObject cookedParticles;

	private void Awake()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
