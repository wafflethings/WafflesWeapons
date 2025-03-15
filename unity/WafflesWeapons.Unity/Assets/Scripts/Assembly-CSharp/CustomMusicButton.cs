using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CustomMusicButton : CustomContentButton, IDragHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private RectTransform canvasTransform;

	[SerializeField]
	private ControllerPointer pointer;

	[SerializeField]
	private UnityEvent<GameObject, Vector3> onDrag;

	[SerializeField]
	private UnityEvent<GameObject, Vector3> onDrop;

	private Vector3? dragPoint;

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}

	private Vector2 GetScreenPositionInCanvasSpace(Vector2 screenPos)
	{
		return default(Vector2);
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
}
