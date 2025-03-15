using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownPipChanger : MonoBehaviour
{
	private TMP_Dropdown dropdown;

	[SerializeField]
	private Image pip;

	private Sprite defaultSprite;

	[SerializeField]
	private Sprite openedSprite;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
