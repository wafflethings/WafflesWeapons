using UnityEngine;
using UnityEngine.Audio;

public class TreeRustle : MonoBehaviour
{
	public MeshRenderer leafRenderer;

	public AudioClip[] audioClips;

	public AudioMixerGroup audioGroup;

	public float rustleDuration;

	public float rustleStrengthScale;

	public float rustleSpeedScale;

	private float baseRustleStrength;

	private float baseRustleSpeed;

	private MaterialPropertyBlock propertyBlock;

	private float time;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void DoRustle()
	{
	}
}
