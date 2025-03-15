using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarTemplate : MonoBehaviour
{
	private static readonly Color IdolProtectedColor;

	public BossHealthSliderTemplate sliderTemplate;

	public TMP_Text bossNameText;

	public BossHealthSliderTemplate thinSliderTemplate;

	private TMP_Text[] textInstances;

	private Slider[] hpSlider;

	private Slider[] hpAfterImage;

	private Color[] hpColors;

	private float[] healFadeLerps;

	private float introCharge;

	private float waitForDamage;

	private GameObject filler;

	private float shakeTime;

	private Vector3 originalPosition;

	private bool done;

	private Slider secondarySlider;

	private GameObject secondaryObject;

	private int currentHpSlider;

	private int currentAfterImageSlider;

	private IEnemyHealthDetails source;

	public void Initialize(BossHealthBar bossBar, SliderLayer[] colorLayers)
	{
	}

	public void SetVisible(bool isVisible)
	{
	}

	private void CreateSecondaryBar(BossHealthBar bossBar)
	{
	}

	public void UpdateSecondaryBar(BossHealthBar bossBar)
	{
	}

	public void ResetSecondaryBar()
	{
	}

	public void ScaleChanged(float scale)
	{
	}

	public void UpdateState(IEnemyHealthDetails details)
	{
	}

	private Color GetHPColor(int index)
	{
		return default(Color);
	}

	private void Update()
	{
	}

	public void ChangeName(string text)
	{
	}
}
