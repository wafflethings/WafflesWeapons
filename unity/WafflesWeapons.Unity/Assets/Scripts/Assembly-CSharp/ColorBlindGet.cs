using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorBlindGet : MonoBehaviour
{
	public HudColorType hct;

	private Image img;

	private Text txt;

	private Light lit;

	private SpriteRenderer sr;

	private TMP_Text txt2;

	private ParticleSystem ps;

	private bool gotTarget;

	public bool variationColor;

	public int variationNumber;

	public bool customColorRenderer;

	private Renderer rend;

	private MaterialPropertyBlock block;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void UpdateColor()
	{
	}

	private void GetTarget()
	{
	}
}
