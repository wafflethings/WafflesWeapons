using System;
using System.Collections.Generic;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
	public GameObject tooltipTemplate;

	private Dictionary<Guid, GameObject> dict;

	private RectTransform canvasRect;

	private void Awake()
	{
	}

	public Guid ShowTooltip(Vector2 position, string text = "")
	{
		return default(Guid);
	}

	public void HideTooltip(Guid id)
	{
	}

	private void EnsureWithinBounds(RectTransform rect)
	{
	}
}
