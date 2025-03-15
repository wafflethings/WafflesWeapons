using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class SliderValueToTextConfig
{
	public DecimalType decimalType;

	[FormerlySerializedAs("modifier")]
	public float multiplier;

	public string suffix;

	public string ifMax;

	public string ifMin;

	public Color minColor;

	public Color maxColor;
}
