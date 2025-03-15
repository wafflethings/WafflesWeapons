using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlightParent : MonoBehaviour
{
	private Image[] buttons;

	private TMP_Text[] buttonTexts;

	private Sprite[] buttonSprites;

	[SerializeField]
	private Sprite pressedVersion;

	[SerializeField]
	private Image targetOnStart;

	private void Start()
	{
	}

	public void ChangeButton(Image target)
	{
	}
}
