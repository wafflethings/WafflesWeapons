using UnityEngine;

public class PickClosestPoint : MonoBehaviour
{
	public Transform target;

	public Transform[] points;

	public Transform customComparisonPoint;

	[SerializeField]
	private bool pickOnEnable;

	[SerializeField]
	private bool parentTargetToClosestPoint;

	[SerializeField]
	private bool mimicRotation;

	[SerializeField]
	private bool mimicPosition;

	[SerializeField]
	private bool mimicScale;

	[SerializeField]
	private bool closestToPlayer;

	private void OnEnable()
	{
	}

	private void Pick()
	{
	}
}
