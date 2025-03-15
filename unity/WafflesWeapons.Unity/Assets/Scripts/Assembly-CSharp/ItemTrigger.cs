using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
	public ItemType targetType;

	public bool oneTime;

	private bool activated;

	public bool disableOnExit;

	public bool disableActivator;

	public bool destroyActivator;

	public bool dontRequireItemLayer;

	public UltrakillEvent onEvent;

	private int requests;

	private void OnDisable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
