using UnityEngine;

public class GasolineProjectile : MonoBehaviour
{
	[SerializeField]
	private GasolineStain stain;

	[SerializeField]
	private Rigidbody rb;

	[SerializeField]
	private SphereCollider col;

	private bool hitSomething;

	private void OnTriggerEnter(Collider other)
	{
	}
}
