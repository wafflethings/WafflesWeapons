using UnityEngine;

public class Beamgun : MonoBehaviour
{
	[SerializeField]
	private Transform shootPoint;

	[SerializeField]
	private BeamgunBeam beam;

	[SerializeField]
	private GameObject beamDrone;

	private GameObject currentBeamDrone;

	private float tempWidthCooldown;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
