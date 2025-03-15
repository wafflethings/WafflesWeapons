using UnityEngine;

[DisallowMultipleComponent]
public sealed class CollisionExitMessage : MessageDispatcher<Collision>.Callback<UnityEventCollision>
{
	private void OnCollisionExit(Collision collision)
	{
	}
}
