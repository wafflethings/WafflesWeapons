using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
	public GameObject target;

	public int layer;

	public float delay;

	public bool includeChildren;

	public bool oneTime;

	[HideInInspector]
	public bool activated;

	public bool activateOnEnable;

	private void Start()
	{
	}

	public void Change()
	{
	}

	public void Change(int targetLayer)
	{
	}
}
