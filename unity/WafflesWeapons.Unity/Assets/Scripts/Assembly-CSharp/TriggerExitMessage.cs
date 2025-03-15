using UnityEngine;

[DisallowMultipleComponent]
public sealed class TriggerExitMessage : MessageDispatcher<Collider>.Callback<UnityEventCollider>
{
	private void OnTriggerExit(Collider other)
	{
	}
}
