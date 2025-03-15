using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class RailcannonMeter : MonoSingleton<RailcannonMeter>
{
	public Image meterBackground;

	public Image[] meters;

	private Image[] trueMeters;

	public Image colorlessMeter;

	private Image self;

	public GameObject[] altHudPanels;

	private float flashAmount;

	public GameObject miniVersion;

	private bool hasFlashed;

	private void Start()
	{
	}

	protected override void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void CheckStatus()
	{
	}

	private bool RailcannonStatus()
	{
		return false;
	}
}
