using UnityEngine;

[DisallowMultipleComponent]
public sealed class TriggerStayMessage : MessageDispatcher<Collider>.Callback<UnityEventCollider>
{
	private void OnTriggerStay(Collider other)
	{
	}
}
