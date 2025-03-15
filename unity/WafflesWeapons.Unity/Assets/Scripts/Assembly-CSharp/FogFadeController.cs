using UnityEngine;

public class FogFadeController : MonoSingleton<FogFadeController>
{
	private bool fading;

	private bool toDisable;

	private bool autoDetect;

	private float speed;

	private Color previousFogColor;

	private float previousFogMin;

	private float previousFogMax;

	private float minTarget;

	private float maxTarget;

	private void Update()
	{
	}

	public void FadeOut(bool autoDetectFogChange = true, float fadeSpeed = 10f)
	{
	}

	public void FadeIn(float newMin, float newMax, bool autoDetectFogChange = true, float fadeSpeed = 10f)
	{
	}
}
