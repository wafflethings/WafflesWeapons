using System;
using UnityEngine.UI;

[Serializable]
public class StyleFreshnessData
{
	public StyleFreshnessState state;

	public string text;

	public float scoreMultiplier;

	public float min;

	public float max;

	public Slider slider;

	public float span => 0f;

	public float justAboveMin => 0f;
}
