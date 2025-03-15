using UnityEngine;

public class MannequinPoses : MonoBehaviour
{
	private Animator anim;

	[SerializeField]
	private bool altar;

	[HideInInspector]
	public bool beenActivated;

	[HideInInspector]
	public int currentPose;

	private void Start()
	{
	}

	private void SlowUpdate()
	{
	}

	private void RandomPose()
	{
	}

	private void ChangePose(int num)
	{
	}
}
