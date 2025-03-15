using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldOptions : MonoBehaviour
{
	[SerializeField]
	private Image borderIcon;

	[SerializeField]
	private TMP_Text borderStatus;

	[SerializeField]
	private TMP_Text buttonText;

	[Space]
	[SerializeField]
	private GameObject border;

	private bool isBorderOn;

	public const string BorderEnabledKey = "border_enabled";

	private void Start()
	{
	}

	public void ToggleBorder()
	{
	}

	public void SetBorderOn(bool state)
	{
	}
}
