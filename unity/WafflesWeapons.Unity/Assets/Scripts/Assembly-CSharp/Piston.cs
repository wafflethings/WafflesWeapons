using UnityEngine;

public class Piston : MonoBehaviour
{
	public bool off;

	private RaycastHit rhit;

	public Vector3 minPos;

	public Vector3 maxPos;

	public Vector3 targetPos;

	private Collider dzone;

	private Collider basedzone;

	public float timer;

	public float returnTime;

	public float attackTime;

	private ParticleSystem part;

	private ParticleSystem[] steamParts;

	private AudioSource partAud;

	private float partAudPitch;

	private AudioSource aud;

	private float audPitch;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
