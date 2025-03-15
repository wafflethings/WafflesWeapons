using UnityEngine;
using UnityEngine.Events;

public class OutOfBounds : MonoBehaviour
{
	public AffectedSubjects targets;

	private StatsManager sman;

	public Vector3 overrideResetPosition;

	public GameObject[] toActivate;

	public GameObject[] toDisactivate;

	public Door[] toUnlock;

	public UnityEvent toEvent;

	private void OnTriggerEnter(Collider other)
	{
	}
}
