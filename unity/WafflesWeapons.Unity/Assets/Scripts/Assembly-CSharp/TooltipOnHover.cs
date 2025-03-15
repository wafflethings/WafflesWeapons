using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipOnHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public TooltipManager tooltipManager;

	public float hoverTime;

	[HideInInspector]
	public bool multiline;

	[HideInInspector]
	public string text;

	private bool hovered;

	private UnscaledTimeSince sinceHoverStart;

	private Guid tooltipId;

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}
}
