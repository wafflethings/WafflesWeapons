using UnityEngine;
using UnityEngine.UI;

public class SliderToFillAmount : MonoBehaviour
{
	public Slider targetSlider;

	public float maxFill;

	public bool copyColor;

	private Image img;

	public FadeOutBars mama;

	public bool dontFadeUntilEmpty;

	private bool isInvisible;

	private bool lastInvisible;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	private void ResetFadeTimer()
	{
	}
}
