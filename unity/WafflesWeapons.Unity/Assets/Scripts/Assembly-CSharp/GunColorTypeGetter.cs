using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GunColorTypeGetter : MonoBehaviour
{
	public int weaponNumber;

	public bool altVersion;

	public GameObject template;

	public GameObject custom;

	public Button altButton;

	public Button presetsButton;

	public Button customButton;

	public GameObject previewModelStandard;

	public GunColorGetter[] previewColorGetterStandard;

	public GameObject previewModelAlt;

	public GunColorGetter[] previewColorGetterAlt;

	public List<Button> templateButtons;

	private Image[] templateButtonsImages;

	private TMP_Text[] templateTexts;

	private string[] originalTemplateTexts;

	public GunColorSetter[] gunColorSetters;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public void SetType(bool isCustom)
	{
	}

	public void SetPreset(int index)
	{
	}

	public void UpdatePreview()
	{
	}

	public void ToggleAlternate()
	{
	}
}
