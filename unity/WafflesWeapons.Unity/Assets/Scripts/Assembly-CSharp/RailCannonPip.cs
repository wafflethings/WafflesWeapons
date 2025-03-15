using UnityEngine;

public class RailCannonPip : MonoBehaviour
{
	private Vector3 origPos;

	private Vector3 targetPos;

	private Vector3 tempPos;

	public Vector3 pushAmount;

	public float chargeLevel;

	private Railcannon rc;

	private Quaternion origRot;

	private Quaternion tempRot;

	private AudioSource[] auds;

	private bool playIdle;

	private bool playClick;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void LateUpdate()
	{
	}

	private void CheckSounds()
	{
	}
}
