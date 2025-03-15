using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageFadeIn : MonoBehaviour
{
	private Image img;

	private TMP_Text text;

	public float speed;

	public float maxAlpha;

	public bool startAt0;

	public UnityEvent onFull;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ResetFade()
	{
	}

	public void CancelFade()
	{
	}
}
