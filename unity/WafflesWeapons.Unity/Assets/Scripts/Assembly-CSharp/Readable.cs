using UnityEngine;

public class Readable : MonoBehaviour
{
	[SerializeField]
	[TextArea(3, 12)]
	private string content;

	[SerializeField]
	private bool instantScan;

	private bool pickedUp;

	private int gameObjectInstanceId;

	private void Awake()
	{
	}

	public void PickUp()
	{
	}

	public void PutDown()
	{
	}

	private void StartScan()
	{
	}

	private void OnDestroy()
	{
	}
}
