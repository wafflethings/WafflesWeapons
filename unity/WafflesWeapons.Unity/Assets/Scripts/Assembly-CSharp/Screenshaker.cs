using UnityEngine;

public class Screenshaker : MonoBehaviour
{
	public float amount;

	public bool oneTime;

	public bool continuous;

	private bool alreadyShaken;

	private bool colliderless;

	public float minDistance;

	public float maxDistance;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void Update()
	{
	}

	public void Shake()
	{
	}

	private float GetDistanceValue()
	{
		return 0f;
	}
}
