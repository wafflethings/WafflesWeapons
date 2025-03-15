using UnityEngine;
using UnityEngine.UI;

public class PooledSplash : MonoBehaviour
{
	public float defaultPitch;

	public float pitchVariation;

	public AudioSource aud;

	public float time;

	public float randomizer;

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

	private bool hasOpacScale;

	private bool hasTint;

	private bool hasColor;

	private Vector3 scaleAmt;

	public Water.WaterGOType splashType;

	[HideInInspector]
	public PooledWaterStore waterStore;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void RandomizePitch()
	{
	}

	private void ScheduleRemove()
	{
	}

	private void ReturnToQueue()
	{
	}

	private void InitializeScaleNFade()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private Color FadeColor(Color c)
	{
		return default(Color);
	}

	private void FadeRenderer()
	{
	}

	public void ChangeFadeSpeed(float newSpeed)
	{
	}

	public void ChangeScaleSpeed(float newSpeed)
	{
	}
}
