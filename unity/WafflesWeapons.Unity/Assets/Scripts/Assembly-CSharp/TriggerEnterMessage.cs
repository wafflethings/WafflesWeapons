using UnityEngine;

[DisallowMultipleComponent]
public sealed class TriggerEnterMessage : MessageDispatcher<Collider>.Callback<UnityEventCollider>
{
	private void OnTriggerEnter(Collider other)
	{
	}
}
