using UnityEngine;

public class BulkInstantiate : MonoBehaviour
{
	[SerializeField]
	private int count;

	[SerializeField]
	private bool instantiateOnEnable;

	[SerializeField]
	private bool instantiateOnStart;

	[SerializeField]
	private GameObject source;

	[SerializeField]
	private InstantiateObjectMode mode;

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	private void OnDrawGizmos()
	{
	}

	public void Instantiate()
	{
	}
}
