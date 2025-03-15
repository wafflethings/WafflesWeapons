using UnityEngine;
using UnityEngine.UI;

public class GunColorSetter : MonoBehaviour
{
	private int weaponNumber;

	public int colorNumber;

	private bool altVersion;

	private float redAmount;

	private float greenAmount;

	private float blueAmount;

	private float metalAmount;

	public Slider redSlider;

	public Slider greenSlider;

	public Slider blueSlider;

	public Slider metalSlider;

	public Image colorExample;

	public Image metalExample;

	[SerializeField]
	private GunColorTypeGetter gctg;

	private void OnEnable()
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

	public void SetMetal(float amount)
	{
	}

	public void UpdateColor()
	{
	}

	public void UpdateSliders()
	{
	}
}
