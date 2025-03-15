using UnityEngine;

[DisallowMultipleComponent]
public sealed class CollisionStayMessage : MessageDispatcher<Collision>.Callback<UnityEventCollision>
{
	private void OnCollisionStay(Collision collision)
	{
	}
}
