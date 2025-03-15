using UnityEngine;

[DisallowMultipleComponent]
public sealed class CollisionEnterMessage : MessageDispatcher<Collision>.Callback<UnityEventCollision>
{
	private void OnCollisionEnter(Collision collision)
	{
	}
}
