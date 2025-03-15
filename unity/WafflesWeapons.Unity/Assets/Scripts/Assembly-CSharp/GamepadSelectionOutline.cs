using UnityEngine;
using UnityEngine.UI;

public class GamepadSelectionOutline : MonoBehaviour
{
	private static readonly Vector3[] s_Corners;

	[SerializeField]
	private Image image;

	[SerializeField]
	private float scrollSpeedPixelsPerSecond;

	[SerializeField]
	private Vector2 outlineSize;

	private ScrollRect lastScrollRect;

	private void Update()
	{
	}

	private Bounds GetSelectedBounds(RectTransform selected, out RectTransform rect)
	{
		rect = null;
		return default(Bounds);
	}

	private Bounds GetRelativeBounds(Transform root, RectTransform child)
	{
		return default(Bounds);
	}

	private void EnsureVisibility(ScrollRect scrollRect, RectTransform child, bool instantScroll = false)
	{
	}
}
