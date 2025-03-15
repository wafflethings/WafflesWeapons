using System.Collections.Generic;
using UnityEngine;

public class WaterObject
{
	public GameObject rbGO;

	public Rigidbody Rb;

	public Collider Col;

	public bool IsUWC;

	public bool IsPlayer;

	public bool IsEnemy;

	public int Layer;

	public EnemyIdentifier EID;

	public Vector3 EnterVelocity;

	public GameObject BubbleEffect;

	public Transform ContinuousSplashEffect;

	public AudioSource[] AudioSources;

	public List<AudioLowPassFilter> LowPassFilters;
}
