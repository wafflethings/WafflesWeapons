using UnityEngine;

public class HudOpenEffect : MonoBehaviour
{
	private RectTransform tran;

	[HideInInspector]
	public Vector2 originalDimensions;

	[HideInInspector]
	public Vector2 targetDimensions;

	[HideInInspector]
	public bool gotValues;

	public bool animating;

	public float speed;

	[HideInInspector]
	public float originalSpeed;

	public bool skip;

	public bool reverse;

	public bool YFirst;

	public bool dontUseScale;

	private void Awake()
	{
	}

	private void Initialize()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public Vector2 GetOriginalDimensions()
	{
		return default(Vector2);
	}

	public void Force()
	{
	}

	public void ResetValues()
	{
	}

	public void ResetValues(Vector2? inheritedOriginalDimensions)
	{
	}

	public void Reverse(float newSpeed = 10f)
	{
	}
}
