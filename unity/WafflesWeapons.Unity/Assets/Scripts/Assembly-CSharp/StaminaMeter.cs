using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaMeter : MonoBehaviour
{
	private NewMovement nmov;

	private float stamina;

	private Slider stm;

	private TMP_Text stmText;

	public bool changeTextColor;

	public Color normalTextColor;

	private Image staminaFlash;

	private Color flashColor;

	private Image staminaBar;

	private bool full;

	private AudioSource aud;

	private Color emptyColor;

	private Color origColor;

	public bool redEmpty;

	private bool intro;

	private float lastStamina;

	private Canvas parentCanvas;

	public bool alwaysUpdate;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void Flash(bool red = false)
	{
	}

	public void UpdateColors()
	{
	}
}
