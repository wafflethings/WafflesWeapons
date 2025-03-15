using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
	public bool fadeIn;

	public bool distance;

	private List<float> origVol;

	public AudioSource[] auds;

	private bool fading;

	public float speed;

	public float maxDistance;

	public bool activateOnEnable;

	public bool dontStopOnZero;

	private GameObject player;

	public bool fadeEvenIfNotPlaying;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void BeginFade()
	{
	}
}
