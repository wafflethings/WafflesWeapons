using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
	public DecimalType decimalType;

	[FormerlySerializedAs("modifier")]
	public float multiplier;

	private string decString;

	private Slider targetSlider;

	private Text targetText;

	private TMP_Text targetTextTMP;

	public string suffix;

	public string ifMax;

	public string ifMin;

	public Color minColor;

	public Color maxColor;

	private Color? origColor;

	private Color nullColor;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ConfigureFrom(SliderValueToTextConfig config)
	{
	}
}
