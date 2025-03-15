using UnityEngine;

public class TriggerSubtitle : MonoBehaviour
{
	[SerializeField]
	[TextArea]
	private string caption;

	[SerializeField]
	private bool ignorePlayerPreferences;

	[SerializeField]
	private bool activateOnEnableIfNoTrigger;

	private Collider col;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void PushCaption()
	{
	}

	public void PushCaptionOverride(string caption)
	{
	}
}
