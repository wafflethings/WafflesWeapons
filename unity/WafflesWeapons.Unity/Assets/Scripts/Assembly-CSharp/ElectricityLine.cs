using UnityEngine;

public class ElectricityLine : MonoBehaviour
{
	private LineRenderer lr;

	public Texture2DArray electricityArray;

	public float minWidth;

	public float maxWidth;

	public Gradient colors;

	private float cooldown;

	public float fadeSpeed;

	private float fadeLerp;

	private AnimatedTexture animatedTexture;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
