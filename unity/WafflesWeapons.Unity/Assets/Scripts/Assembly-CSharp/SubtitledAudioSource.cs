using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SubtitledAudioSource : MonoBehaviour
{
	[Serializable]
	public class SubtitleData
	{
		public SubtitleDataLine[] lines;
	}

	[Serializable]
	public class SubtitleDataLine
	{
		public string subtitle;

		public float time;
	}

	[SerializeField]
	private SubtitleData subtitles;

	[SerializeField]
	private bool distanceAware;

	private AudioSource audioSource;

	private int currentVoiceLine;

	private float lastAudioTime;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}
}
