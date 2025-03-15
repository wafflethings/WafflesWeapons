using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

[DisallowMultipleComponent]
internal class ControllerPointer : MonoBehaviour
{
	private static RaycastResult? bestResult;

	private PointerEventData eventData;

	private static int ignoreFrame;

	[SerializeField]
	private UnityEvent onPressed;

	[SerializeField]
	private UnityEvent onReleased;

	[SerializeField]
	private UnityEvent onEnter;

	[SerializeField]
	private UnityEvent onExit;

	[SerializeField]
	private float dragThreshold;

	private bool entered;

	private bool pointerDown;

	private bool scrollState;

	public static GraphicRaycaster raycaster;

	public static List<GraphicRaycaster> raycasters;

	private List<RaycastResult> results;

	private Vector2? dragPoint;

	private bool dragging;

	public UnityEvent OnPressed => null;

	public UnityEvent OnReleased => null;

	public UnityEvent OnEnter => null;

	public UnityEvent OnExit => null;

	private void Awake()
	{
	}

	private void UpdateSlider()
	{
	}

	private void UpdateScrollbars()
	{
	}

	private void UpdateScrollbar(Scrollbar scroll)
	{
	}

	private void UpdateRaycasters()
	{
	}

	private void Update()
	{
	}

	private void UpdateEvents()
	{
	}
}
