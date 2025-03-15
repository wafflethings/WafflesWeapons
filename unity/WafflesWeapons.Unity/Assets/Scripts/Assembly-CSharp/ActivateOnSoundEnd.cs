using UnityEngine;

public class ActivateOnSoundEnd : MonoBehaviour
{
	private AudioSource aud;

	private bool hasStarted;

	[SerializeField]
	private UltrakillEvent events;

	[SerializeField]
	private bool dontWaitForStart;

	[SerializeField]
	private bool oneTime;

	private bool activated;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
