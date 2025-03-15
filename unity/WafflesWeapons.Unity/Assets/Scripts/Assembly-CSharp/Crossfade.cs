using UnityEngine;

public class Crossfade : MonoBehaviour
{
	public bool multipleTargets;

	public AudioSource from;

	public AudioSource to;

	public AudioSource[] froms;

	public AudioSource[] tos;

	[HideInInspector]
	public float[] fromMaxVolumes;

	[HideInInspector]
	public float[] toOriginalVolumes;

	[HideInInspector]
	public float[] toMaxVolumes;

	[HideInInspector]
	public float[] toMinVolumes;

	[HideInInspector]
	public bool inProgress;

	public float time;

	public bool unscaledTime;

	private float fadeAmount;

	public bool match;

	public bool dontActivateOnStart;

	public bool oneTime;

	private bool activated;

	private bool firstTime;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void StartFade()
	{
	}

	public void StopFade()
	{
	}
}
