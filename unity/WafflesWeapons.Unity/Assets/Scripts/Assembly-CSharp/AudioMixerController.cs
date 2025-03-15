using UnityEngine;
using UnityEngine.Audio;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
[DefaultExecutionOrder(-10)]
public class AudioMixerController : MonoSingleton<AudioMixerController>
{
	[Header("Mixers")]
	public AudioMixer allSound;

	public AudioMixer goreSound;

	public AudioMixer musicSound;

	public AudioMixer doorSound;

	public AudioMixer unfreezeableSound;

	[Header("Mixer Groups")]
	public AudioMixerGroup allGroup;

	public AudioMixerGroup goreGroup;

	public AudioMixerGroup musicGroup;

	public AudioMixerGroup doorGroup;

	public AudioMixerGroup unfreezeableGroup;

	[HideInInspector]
	public float sfxVolume;

	[HideInInspector]
	public float musicVolume;

	[HideInInspector]
	public float optionsMusicVolume;

	[HideInInspector]
	public bool muffleMusic;

	[Space]
	public bool forceOff;

	private float temporaryDipAmount;

	private bool isUnderWater;

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

	public void SetMusicVolume(float volume)
	{
	}

	public void SetSFXVolume(float volume)
	{
	}

	public void UpdateSFXVolume()
	{
	}

	public void TemporaryDip(float amount)
	{
	}

	public float CalculateVolume(float volume)
	{
		return 0f;
	}

	public void IsInWater(bool isInWater)
	{
	}

	public void MuffleMusic(bool isOn)
	{
	}
}
