using UnityEngine;

public class Morse : MonoBehaviour
{
	[SerializeField]
	private string code;

	[SerializeField]
	private float speed;

	[HideInInspector]
	public int current;

	[SerializeField]
	private UltrakillEvent onDot;

	[SerializeField]
	private UltrakillEvent onDash;

	[SerializeField]
	private UltrakillEvent onSpace;

	private TimeSince timer;

	private void Update()
	{
	}

	private void Tick()
	{
	}
}
