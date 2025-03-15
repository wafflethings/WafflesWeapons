using UnityEngine;

public class SkyboxEnabler : MonoBehaviour
{
	public bool disable;

	public bool oneTime;

	public bool dontActivateOnEnable;

	private bool activated;

	public Material changeSkybox;

	private void OnEnable()
	{
	}

	public void Activate()
	{
	}
}
