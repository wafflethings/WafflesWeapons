using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class IntroViolenceScreen : MonoBehaviour
{
	private Image img;

	private float fadeAmount;

	private bool fade;

	private float targetAlpha;

	private VideoPlayer vp;

	private bool videoOver;

	[SerializeField]
	private GameObject loadingScreen;

	[SerializeField]
	private Image red;

	private bool shouldLoadTutorial;

	private bool bundlesLoaded;

	private void Start()
	{
	}

	private string GetTargetScene()
	{
		return null;
	}

	private void Update()
	{
	}

	private void Skip()
	{
	}

	private void Red()
	{
	}

	private void FadeOut()
	{
	}
}
