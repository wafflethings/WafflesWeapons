using UnityEngine;
using UnityEngine.EventSystems;

public class ConsoleWindow : MonoBehaviour
{
	private Vector2 minSize;

	private Vector2 defaultSize;

	private RectTransform selfFrame;

	private bool isDragging;

	private Vector2 dragOffset;

	private bool isResizing;

	private Vector2 resizeCursorStart;

	private Vector2Int lastResolution;

	private Vector2 position
	{
		get
		{
			return default(Vector2);
		}
		set
		{
		}
	}

	private Vector2 size
	{
		get
		{
			return default(Vector2);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void ResetWindow()
	{
	}

	private void Update()
	{
	}

	public void StartDrag(PointerEventData eventData)
	{
	}

	public void EndDrag(PointerEventData eventData)
	{
	}

	public void StartResize(PointerEventData eventData, Vector2Int corner)
	{
	}

	public void StopResize(PointerEventData eventData, Vector2Int corner)
	{
	}
}
