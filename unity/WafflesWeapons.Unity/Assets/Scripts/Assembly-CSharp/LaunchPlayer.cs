using UnityEngine;

public class LaunchPlayer : MonoBehaviour
{
	public Vector3 direction;

	public bool relative;

	public bool oneTime;

	private bool beenLaunched;

	public bool dontLaunchOnEnable;

	private bool colliderless;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Launch()
	{
	}
}
