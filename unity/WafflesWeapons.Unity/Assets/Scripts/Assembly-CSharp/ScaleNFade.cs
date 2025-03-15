using UnityEngine;
using UnityEngine.UI;

public class ScaleNFade : MonoBehaviour
{
	public bool scale;

	public bool fade;

	public FadeType ft;

	public float scaleSpeed;

	public float fadeSpeed;

	private SpriteRenderer sr;

	private LineRenderer lr;

	private Light lght;

	private Renderer rend;

	private Image img;

	public bool dontDestroyOnZero;

	public bool lightUseIntensityInsteadOfRange;

	public bool fadeToBlack;

	private Vector3 scaleAmt;

	private bool hasOpacScale;

	private bool hasTint;

	private bool hasColor;

	public bool clampFade;

	public float clampMinimum;

	public float clampMaximum;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private Color UpdateColor(Color newColor)
	{
		return default(Color);
	}

	private void UpdateLightFade()
	{
	}

	private void UpdateRendererFade()
	{
	}

	private void UpdateOpacityScale()
	{
	}

	private void UpdateColorFade()
	{
	}

	private void FixedUpdate()
	{
	}

	public void ChangeFadeSpeed(float newSpeed)
	{
	}

	public void ChangeScaleSpeed(float newSpeed)
	{
	}
}
