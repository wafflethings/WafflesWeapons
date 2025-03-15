using UnityEngine;

public class ParticleCluster : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem[] particles;

	private ParticleSystem.EmissionModule[] emissionModules;

	private void Awake()
	{
	}

	public void EmissionOn()
	{
	}

	public void EmissionOff()
	{
	}
}
