using UnityEngine;
using UnityEngine.EventSystems;

public class ConsoleWindowCorner : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField]
	private ConsoleWindow consoleWindow;

	[SerializeField]
	private GameObject feedbackIcon;

	[SerializeField]
	private Vector2Int corner;

	private bool dragging;

	private bool hovering;

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}
}
