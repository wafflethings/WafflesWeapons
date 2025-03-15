using UnityEngine;

public class BeatInfo : MonoBehaviour
{
	[HideInInspector]
	public bool valuesSet;

	public float bpm;

	public float timeSignature;

	[HideInInspector]
	public AudioSource aud;

	public TimeSignatureChange[] timeSignatureChanges;

	public void SetValues()
	{
	}
}
