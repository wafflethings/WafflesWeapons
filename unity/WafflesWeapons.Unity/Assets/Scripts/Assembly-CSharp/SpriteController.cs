using UnityEngine;

public class SpriteController : MonoBehaviour
{
	public Vector3 randomRotation;

	public bool blinking;

	public float fadeSpeed;

	public float shrinkSpeed;

	private SpriteRenderer spr;

	private float originalAlpha;

	private Vector3 originalScale;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
