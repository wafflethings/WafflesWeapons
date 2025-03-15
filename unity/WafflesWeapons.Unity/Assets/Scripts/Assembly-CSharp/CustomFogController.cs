using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomFogController : MonoBehaviour
{
	[Serializable]
	private struct ValuePreset
	{
		public float redAmount;

		public float greenAmount;

		public float blueAmount;

		public float startDistance;

		public float endDistance;

		public bool dynamicDistance;

		public ValuePreset(float redAmount, float greenAmount, float blueAmount, float startDistance, float endDistance, bool dynamicDistance)
		{
			this.redAmount = 0f;
			this.greenAmount = 0f;
			this.blueAmount = 0f;
			this.startDistance = 0f;
			this.endDistance = 0f;
			this.dynamicDistance = false;
		}
	}

	private float redAmount;

	private float greenAmount;

	private float blueAmount;

	[SerializeField]
	private Slider redSlider;

	[SerializeField]
	private Slider greenSlider;

	[SerializeField]
	private Slider blueSlider;

	[Space]
	[SerializeField]
	private Image colorImage;

	private float startDistance;

	private float endDistance;

	[Space]
	[SerializeField]
	private Slider startDistanceSlider;

	[SerializeField]
	private Slider endDistanceSlider;

	private bool dynamicDistance;

	[Space]
	[SerializeField]
	private TMP_Text dynamicDistanceButtonText;

	[SerializeField]
	private List<GameObject> staticDistanceElements;

	[SerializeField]
	private List<GameObject> dynamicDistanceElements;

	[Space]
	[SerializeField]
	private FogSetterBounds fogSetterBounds;

	[Header("Preset Values")]
	[SerializeField]
	private ValuePreset[] presets;

	private void Start()
	{
	}

	public void SetRed(float amount)
	{
	}

	public void SetGreen(float amount)
	{
	}

	public void SetBlue(float amount)
	{
	}

	private void UpdateColor()
	{
	}

	public void SetFogStartDistance(float distance)
	{
	}

	public void SetFogEndDistance(float distance)
	{
	}

	public void ToggleDynamicFogDistance()
	{
	}

	public void ResetValues()
	{
	}

	public void SetPreset(int index)
	{
	}
}
