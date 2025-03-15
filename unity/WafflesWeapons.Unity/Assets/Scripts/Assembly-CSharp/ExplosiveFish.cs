using UnityEngine;

public class ExplosiveFish : MonoBehaviour
{
	private Rigidbody rb;

	private bool activated;

	private TimeSince timeSinceActivated;

	[SerializeField]
	private GameObject fire;

	[SerializeField]
	private GameObject explosion;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
