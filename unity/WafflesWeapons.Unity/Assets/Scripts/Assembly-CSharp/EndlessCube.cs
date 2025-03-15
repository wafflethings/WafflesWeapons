using UnityEngine;

public class EndlessCube : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer meshRenderer;

	[SerializeField]
	private MeshFilter meshFilter;

	public Vector2Int positionOnGrid;

	public bool blockedByPrefab;

	private Vector3 targetPos;

	private Transform tf;

	private bool active;

	private float speed;

	private EndlessGrid eg;

	public MeshRenderer MeshRenderer => null;

	public MeshFilter MeshFilter => null;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void SetTarget(float target)
	{
	}

	private void StartMoving()
	{
	}
}
