using UnityEngine;

public class SplashingElement : MonoBehaviour
{
	public SplashingElement previousElement;

	private bool _isSplashing;

	private Vector3 _splashPosition;

	public bool isSplashing => false;

	public Vector3 splashPosition => default(Vector3);

	public void FixedUpdate()
	{
	}
}
