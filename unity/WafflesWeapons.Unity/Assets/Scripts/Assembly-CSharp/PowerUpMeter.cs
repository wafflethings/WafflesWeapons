using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PowerUpMeter : MonoSingleton<PowerUpMeter>
{
	public float juice;

	public float latestMaxJuice;

	private Image meter;

	public Image vignette;

	public Color powerUpColor;

	private Color currentColor;

	public GameObject endEffect;

	private bool hasPowerUp;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void UpdateMeter()
	{
	}

	public void EndPowerUp()
	{
	}

	private void UpdateCheats()
	{
	}
}
