using UnityEngine;
using UnityEngine.UI;

public class PuzzleLine : MonoBehaviour
{
	private RectTransform imageRectTransform;

	private Image img;

	public int length;

	public void DrawLine(Vector3 pointA, Vector3 pointB, TileColor color)
	{
	}

	public void Hide()
	{
	}

	public Color TranslateColor(TileColor color)
	{
		return default(Color);
	}
}
