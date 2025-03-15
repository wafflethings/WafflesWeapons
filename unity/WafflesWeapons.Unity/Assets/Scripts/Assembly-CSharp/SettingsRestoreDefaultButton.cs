using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsRestoreDefaultButton : MonoBehaviour
{
	public GameObject buttonContainer;

	public string settingKey;

	[Header("Float")]
	public Slider slider;

	public float valueToPrefMultiplier;

	public float sliderTolerance;

	public bool integerSlider;

	[Header("Integer")]
	public TMP_Dropdown dropdown;

	[Header("Boolean")]
	public Toggle toggle;

	[SerializeField]
	private UnityEvent customToggleEvent;

	private float? defaultFloat;

	private int? defaultInt;

	private bool? defaultBool;

	public void RestoreDefault()
	{
	}

	public void SetNavigation(Selectable mainSelectable)
	{
	}

	private void Start()
	{
	}

	private void UpdateSelf()
	{
	}

	private int? ReadCurrentInt()
	{
		return null;
	}
}
