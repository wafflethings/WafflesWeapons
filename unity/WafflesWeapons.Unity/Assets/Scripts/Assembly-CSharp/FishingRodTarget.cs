using UnityEngine;
using UnityEngine.UI;

public class FishingRodTarget : MonoBehaviour
{
	[SerializeField]
	private GameObject goodBadge;

	[SerializeField]
	private GameObject badBadge;

	[SerializeField]
	private Transform canvas;

	public Text waterNameText;

	private void Awake()
	{
	}

	public void SetState(bool isGood, float distance)
	{
	}
}
