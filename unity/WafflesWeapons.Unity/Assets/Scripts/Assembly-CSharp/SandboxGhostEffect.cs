using UnityEngine;

public class SandboxGhostEffect : MonoBehaviour
{
	public Collider targetCollider;

	private const float scaleMulti = 1.3f;

	private const float duration = 0.2f;

	private Vector3 originalScale;

	private TimeSince timeSinceStart;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
