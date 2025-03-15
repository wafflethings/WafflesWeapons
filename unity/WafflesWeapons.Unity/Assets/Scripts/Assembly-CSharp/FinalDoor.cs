using UnityEngine;

public class FinalDoor : MonoBehaviour
{
	public Door[] doors;

	public GameObject doorLight;

	public bool startOpen;

	public Material[] offMaterials;

	public Material[] onMaterials;

	private MeshRenderer[] allRenderers;

	private bool opened;

	[HideInInspector]
	public bool aboutToOpen;

	private AudioSource aud;

	public GameObject closingBlocker;

	private void Start()
	{
	}

	public void Open()
	{
	}

	public void Close()
	{
	}

	private int GetOnMaterial(MeshRenderer mr)
	{
		return 0;
	}

	private int GetOffMaterial(MeshRenderer mr)
	{
		return 0;
	}

	public void OpenDoors()
	{
	}
}
