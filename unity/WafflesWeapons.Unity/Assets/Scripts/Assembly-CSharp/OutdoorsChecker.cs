using UnityEngine;

public class OutdoorsChecker : MonoBehaviour
{
	public bool nonSolid;

	public bool oneTime;

	public GameObject[] targets;

	[Header("Additional Events")]
	public UltrakillEvent onIndoors;

	public UltrakillEvent onOutdoors;

	private BoxCollider boxCol;

	private void Start()
	{
	}

	public void SlowUpdate()
	{
	}

	public static bool CheckIfPositionOutdoors(Vector3 position)
	{
		return false;
	}
}
