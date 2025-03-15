using UnityEngine;

public class EndlessStairs : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer primaryMeshRenderer;

	[SerializeField]
	private MeshRenderer secondaryMeshRenderer;

	[SerializeField]
	private MeshFilter primaryMeshFilter;

	[SerializeField]
	private MeshFilter secondaryMeshFilter;

	private Transform primaryStairs;

	private Transform secondaryStairs;

	private LayerMask lmask;

	private bool activateFirst;

	private bool activateSecond;

	private bool moving;

	public MeshRenderer PrimaryMeshRenderer => null;

	public MeshRenderer SecondaryMeshRenderer => null;

	public MeshFilter PrimaryMeshFilter => null;

	public MeshFilter SecondaryMeshFilter => null;

	public bool ActivateFirst => false;

	public bool ActivateSecond => false;

	private void Start()
	{
	}

	private bool RayCastCheck(Vector3 direction, float height = 1f)
	{
		return false;
	}

	private void ActivationTime()
	{
	}

	private void Update()
	{
	}
}
