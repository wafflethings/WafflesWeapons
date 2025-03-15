using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
	[SerializeField]
	private bool destroyOnEnable;

	[SerializeField]
	private bool dontDestroyOnTrigger;

	[SerializeField]
	private GameObject[] targets;

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void Destroy()
	{
	}
}
