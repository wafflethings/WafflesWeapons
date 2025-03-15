using UnityEngine;

public class BaitItem : MonoBehaviour
{
	[SerializeField]
	private bool silentFail;

	[SerializeField]
	private GameObject consumedPrefab;

	[SerializeField]
	private FishObject[] attractFish;

	[SerializeField]
	private FishDB[] supportedWaters;

	private bool used;

	private void OnTriggerEnter(Collider other)
	{
	}
}
