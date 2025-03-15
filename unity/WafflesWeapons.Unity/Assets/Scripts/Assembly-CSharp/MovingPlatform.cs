using UnityEngine;
using UnityEngine.Serialization;

public class MovingPlatform : MonoBehaviour
{
	[HideInInspector]
	public bool infoSet;

	public Vector3[] relativePoints;

	[HideInInspector]
	public Vector3 originalPosition;

	[HideInInspector]
	public Vector3 currentPosition;

	[HideInInspector]
	public Vector3 targetPosition;

	[HideInInspector]
	public int currentPoint;

	public bool useRigidbody;

	private Rigidbody rb;

	public float speed;

	[FormerlySerializedAs("ease")]
	public bool easeIn;

	[FormerlySerializedAs("ease")]
	public bool easeOut;

	public float easeSpeedMultiplier;

	public bool reverseAtEnd;

	public bool teleportBackToStart;

	public bool stopAtEnd;

	[HideInInspector]
	public bool forward;

	public bool moving;

	public bool randomStartPoint;

	public int startPoint;

	public float startOffset;

	public float moveDelay;

	[HideInInspector]
	public AudioSource aud;

	[HideInInspector]
	public float origPitch;

	[HideInInspector]
	public float origDoppler;

	public AudioClip moveSound;

	public AudioClip stopSound;

	public UltrakillEvent[] onReachPoint;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void NextPoint()
	{
	}

	public void TeleportToPoint(int newPoint)
	{
	}

	private void ReEnableDoppler()
	{
	}
}
