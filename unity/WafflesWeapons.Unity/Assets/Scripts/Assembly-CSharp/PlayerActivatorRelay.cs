using UnityEngine;

public class PlayerActivatorRelay : MonoSingleton<PlayerActivatorRelay>
{
	[SerializeField]
	private GameObject[] toActivate;

	[SerializeField]
	private GameObject gunPanel;

	[SerializeField]
	private GameObject crosshair;

	[SerializeField]
	private float delay;

	private int index;

	private void Start()
	{
	}

	public void Activate()
	{
	}
}
