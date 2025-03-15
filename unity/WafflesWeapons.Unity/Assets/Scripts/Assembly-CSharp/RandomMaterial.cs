using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
	private Renderer renderer;

	public Material[] materials;

	public int delay;

	public bool instantOnFirstTime;

	private TimeSince previousChange;

	public bool oneTime;

	private bool activated;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Randomize()
	{
	}
}
