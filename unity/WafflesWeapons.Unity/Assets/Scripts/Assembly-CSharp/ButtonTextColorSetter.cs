using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextColorSetter : MonoBehaviour
{
	public bool onlyDisabledState;

	private Button button;

	private Graphic originalGraphic;

	private TMP_Text[] texts;

	private void Awake()
	{
	}

	public void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha, bool useRGB)
	{
	}
}
