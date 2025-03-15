using UnityEngine;

public class AnimatedTexture : MonoBehaviour
{
	[SerializeField]
	private bool randomFrame;

	[SerializeField]
	private bool manualTrigger;

	[SerializeField]
	private float delay;

	[SerializeField]
	private Texture2D[] framePool;

	[SerializeField]
	public Texture2DArray arrayTex;

	[SerializeField]
	private TextureType textureType;

	private TimeSince counter;

	private int selector;

	private MaterialPropertyBlock block;

	private Renderer renderer;

	private static readonly int MainTexID;

	private static readonly int EmissiveTexID;

	private Texture2D arrayIndexTexture;

	private int texID;

	private void OnValidate()
	{
	}

	private void Awake()
	{
	}

	private void Setup()
	{
	}

	private void Update()
	{
	}

	private void SetTexture()
	{
	}

	public void AddTime(float newTime)
	{
	}

	public void SetArraySlice(int slice)
	{
	}
}
