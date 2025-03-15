using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindSetter : MonoBehaviour
{
	private TMP_Text nameText;

	private string originalName;

	public new string name;

	public bool enemyColor;

	public bool variationColor;

	public HudColorType hct;

	public EnemyType ect;

	public int variationNumber;

	private Color originalColor;

	private Color newColor;

	public Image colorExample;

	private float redAmount;

	private float greenAmount;

	private float blueAmount;

	public Slider redSlider;

	public Slider greenSlider;

	public Slider blueSlider;

	private void OnEnable()
	{
	}

	public void Prepare()
	{
	}

	private void UpdateColor()
	{
	}

	public void ChangeRed(float amount)
	{
	}

	public void ChangeGreen(float amount)
	{
	}

	public void ChangeBlue(float amount)
	{
	}

	public void ResetToDefault()
	{
	}
}
