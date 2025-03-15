using UnityEngine;

public class Bonus : MonoBehaviour
{
	private Vector3 cRotation;

	public GameObject breakEffect;

	private bool activated;

	public bool ghost;

	public bool tutorial;

	public bool superCharge;

	public bool dontReplaceWithGhost;

	[HideInInspector]
	public bool beenFound;

	public int secretNumber;

	public GameObject ghostVersion;

	private void Start()
	{
	}

	public void UpdateStatsManagerReference()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void BeenFound()
	{
	}
}
