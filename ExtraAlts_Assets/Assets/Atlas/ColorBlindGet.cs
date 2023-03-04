using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindGet : MonoBehaviour
{
	private void Start()
	{

	}

	private void OnEnable()
	{

	}

	public void UpdateColor()
	{
		
	}

	private void GetTarget()
	{

	}

	public HudColorType hct;
	private Image img;
	private Text txt;
	private bool gotTarget;
	public bool variationColor;
	public int variationNumber;
}

public enum HudColorType
{
	health,
	healthAfterImage,
	antiHp,
	overheal,
	healthText,
	stamina,
	staminaEmpty,
	railcannonFull,
	railcannonCharging
}
