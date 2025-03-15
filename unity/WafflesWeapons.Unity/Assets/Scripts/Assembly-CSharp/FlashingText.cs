using TMPro;
using UnityEngine;

public class FlashingText : MonoBehaviour
{
	private TextMeshProUGUI text;

	private Color originalColor;

	public Color flashColor;

	public float fadeTime;

	private float fading;

	public float delay;

	private float cooldown;

	public bool forcePreciseTiming;

	private float previousLerp;

	public AudioSource[] matchToMusic;

	public UltrakillEvent onFlash;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void Flash()
	{
	}
}
