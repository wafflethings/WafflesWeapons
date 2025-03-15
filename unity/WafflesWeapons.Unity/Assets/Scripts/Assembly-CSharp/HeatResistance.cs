using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeatResistance : MonoBehaviour
{
	[SerializeField]
	private Slider meter;

	[SerializeField]
	private TMP_Text meterLabel;

	[SerializeField]
	private TMP_Text meterPercentage;

	[SerializeField]
	private Image greenFlash;

	[SerializeField]
	private GameObject hurtingSound;

	[SerializeField]
	private Image screenShatter;

	public float speed;

	private float heatResistance;

	private TimeSince hurtTimer;

	private bool recharging;

	private float rechargeSpeed;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	public void RechargeOnce()
	{
	}

	public void SetRechargeMode(float targetSpeedMultiplier)
	{
	}
}
