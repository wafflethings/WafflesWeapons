using UnityEngine;

public class PlayerActivator : MonoBehaviour
{
	private NewMovement nm;

	private bool activated;

	[SerializeField]
	private bool startTimer;

	[SerializeField]
	private bool onlyActivatePlayer;

	private GunControl gc;

	public static Vector3 lastActivatedPosition;

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Activate()
	{
	}

	private void ActivateObjects()
	{
	}
}
