using UnityEngine;

[DisallowMultipleComponent]
public sealed class AnimationEventMessage : MessageDispatcher<AnimationEvent>.Callback<AnimationEventMessageEvent>
{
	private void OnAnimationEvent(AnimationEvent evt)
	{
	}
}
