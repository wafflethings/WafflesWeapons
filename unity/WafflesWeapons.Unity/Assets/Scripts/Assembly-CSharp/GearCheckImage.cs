using UnityEngine;
using UnityEngine.UI;

public class GearCheckImage : MonoBehaviour
{
	public string gearName;

	private Image image;

	private Sprite originalSprite;

	[SerializeField]
	private Sprite lockedSprite;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}
}
