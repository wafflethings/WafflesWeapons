using UnityEngine;
using UnityEngine.UI;

public class MenuAlphaPop : MonoBehaviour
{
	[SerializeField]
	private bool animateOnEnable;

	[SerializeField]
	private bool canvasGroupInsteadOfImage;

	[SerializeField]
	private float initialAlpha;

	[SerializeField]
	private float finalAlpha;

	[SerializeField]
	private float animationDuration;

	private Image targetImage;

	private CanvasGroup targetGroup;

	private bool isAnimating;

	private float progress;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void Animate()
	{
	}
}
