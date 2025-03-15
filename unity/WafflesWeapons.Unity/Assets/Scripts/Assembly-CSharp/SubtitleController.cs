using System.Collections.Generic;
using UnityEngine;

public class SubtitleController : MonoSingleton<SubtitleController>
{
	public class SubtitleData
	{
		public string caption;

		public float time;

		public GameObject origin;
	}

	[SerializeField]
	private Transform container;

	[SerializeField]
	private Subtitle subtitleLine;

	private Subtitle previousSubtitle;

	private List<SubtitleData> delayedSubs;

	private bool subtitlesEnabled;

	public bool SubtitlesEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	private void Update()
	{
	}

	public void NotifyHoldEnd(Subtitle self)
	{
	}

	public void DisplaySubtitleTranslated(string translationKey)
	{
	}

	public void DisplaySubtitle(string caption, AudioSource audioSource = null, bool ignoreSetting = false)
	{
	}

	public void DisplaySubtitle(string caption, float time, GameObject origin)
	{
	}

	public void CancelSubtitle(GameObject origin)
	{
	}
}
