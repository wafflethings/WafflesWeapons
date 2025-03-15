using UnityEngine.EventSystems;

public class FirstPersonInputModule : StandaloneInputModule
{
	protected override MouseState GetMousePointerEventData(int id)
	{
		return null;
	}

	protected override void ProcessMove(PointerEventData pointerEvent)
	{
	}

	protected override void ProcessDrag(PointerEventData pointerEvent)
	{
	}
}
