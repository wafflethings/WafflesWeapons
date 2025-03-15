using System.Collections.Generic;
using UnityEngine;

public class TeleportCheat : MonoBehaviour
{
	private class TeleportTarget
	{
		public string overrideName;

		public CheckPoint checkpoint;

		public FirstRoomPrefab firstRoom;

		public Transform target;
	}

	[SerializeField]
	private GameObject buttonTemplate;

	[SerializeField]
	private Color checkpointColor;

	[SerializeField]
	private Color roomColor;

	private List<string> checkpointNames;

	private void Start()
	{
	}

	private void GenerateList()
	{
	}

	private void Update()
	{
	}

	private string ImproveCheckpointName(string original)
	{
		return null;
	}

	private void Teleport(Transform target)
	{
	}
}
