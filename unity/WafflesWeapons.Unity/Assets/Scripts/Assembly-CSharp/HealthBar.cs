using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	private NewMovement nmov;

	public Slider[] hpSliders;

	public Slider[] afterImageSliders;

	public Slider antiHpSlider;

	public Image antiHpSliderFill;

	public TMP_Text hpText;

	private float hp;

	private float antiHp;

	public bool changeTextColor;

	public Color normalTextColor;

	public bool yellowColor;

	public bool antiHpText;

	private int difficulty;

	private float lastHP;

	private float lastAntiHP;

	private string lowDifHealth;

	private ColorBlindSettings colorBlindSettings;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
