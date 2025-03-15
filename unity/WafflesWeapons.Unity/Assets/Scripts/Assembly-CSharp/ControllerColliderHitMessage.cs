using UnityEngine;

[DisallowMultipleComponent]
public sealed class ControllerColliderHitMessage : MessageDispatcher<ControllerColliderHit>.Callback<UnityEventControllerColliderHit>
{
	private void OnControllerColliderHit(ControllerColliderHit collision)
	{
	}
}
