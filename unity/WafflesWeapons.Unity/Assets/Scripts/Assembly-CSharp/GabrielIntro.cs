using UnityEngine;

public class GabrielIntro : MonoBehaviour
{
	private Animator anim;

	private bool shaking;

	private bool tracking;

	private Quaternion previousRotation;

	private Vector3 defaultPos;

	private float shakeAmount;

	[SerializeField]
	private Transform root;

	[SerializeField]
	private SkinnedMeshRenderer sword1;

	[SerializeField]
	private GameObject fakeSword1;

	[SerializeField]
	private SkinnedMeshRenderer sword2;

	[SerializeField]
	private GameObject fakeSword2;

	[SerializeField]
	private AudioSource swordUnsheatheSound;

	[SerializeField]
	private GameObject rumbling;

	public void Begin()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void StartShaking()
	{
	}

	private void StopShaking()
	{
	}

	private void StartTracking()
	{
	}

	private void SwordPull(int sword)
	{
	}
}
