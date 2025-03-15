using UnityEngine;

public class LerpColor : MonoBehaviour
{
	public bool onEnable;

	public bool oneTime;

	[HideInInspector]
	public bool beenActivated;

	public LerpColorType type;

	private Light lit;

	private Material mat;

	private Water wtr;

	private SpriteRenderer spr;

	private bool activated;

	public bool rainbow;

	private Color originalColor;

	public Color targetColor;

	private Color currentColor;

	public float time;

	private float currentTime;

	public bool dontOverrideAlpha;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void Activate()
	{
	}

	public void Revert()
	{
	}

	public void Skip()
	{
	}

	private void GetValues()
	{
	}

	public static Color RainbowShift(Color color, float amount)
	{
		return default(Color);
	}
}
