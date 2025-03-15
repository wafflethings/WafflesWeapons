using UnityEngine;

public class CheckForScroller : MonoBehaviour
{
	public bool checkOnStart;

	public bool checkOnCollision;

	private ScrollingTexture scroller;

	public bool asRigidbody;

	private Rigidbody rb;

	private ComponentsDatabase cdat;

	private void Start()
	{
	}

	private void OnCollisionEnter(Collision col)
	{
	}

	private void OnCollisionExit(Collision col)
	{
	}
}
