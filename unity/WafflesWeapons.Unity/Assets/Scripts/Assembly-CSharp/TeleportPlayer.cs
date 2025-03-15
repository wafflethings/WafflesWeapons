using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
	public bool affectPosition;

	public Vector3 relativePosition;

	public bool notRelative;

	public bool relativeToCollider;

	public Vector3 objectivePosition;

	public bool includeOffsetFromCollider;

	public bool affectRotation;

	public bool notRelativeRotation;

	public Vector2 rotationDelta;

	public Vector2 objectiveRotation;

	public bool resetPlayerSpeed;

	public bool cancelGroundSlam;

	public bool dontDetachPlayerFromMovementParent;

	public Transform[] teleportWithPlayer;

	public GameObject teleportEffect;

	public UltrakillEvent onTeleportPlayer;

	private void OnTriggerEnter(Collider other)
	{
	}

	public void PerformTheTeleport()
	{
	}

	private void PerformTheTeleport(Transform target)
	{
	}
}
