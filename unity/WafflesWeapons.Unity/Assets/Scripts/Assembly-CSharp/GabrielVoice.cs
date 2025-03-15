using System.Collections.Generic;
using UnityEngine;

public class GabrielVoice : MonoBehaviour
{
	private AudioSource aud;

	public AudioClip[] hurt;

	public AudioClip[] bigHurt;

	public AudioClip phaseChange;

	public string phaseChangeSubtitle;

	public AudioClip[] taunt;

	[SerializeField]
	private string[] taunts;

	public bool secondPhase;

	public AudioClip[] tauntSecondPhase;

	[SerializeField]
	private string[] tauntsSecondPhase;

	private List<int> usedTaunts;

	private int priority;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Hurt()
	{
	}

	public void BigHurt()
	{
	}

	public void PhaseChange()
	{
	}

	public void Taunt()
	{
	}

	private void TauntNow(AudioClip[] clips, string[] subs)
	{
	}
}
