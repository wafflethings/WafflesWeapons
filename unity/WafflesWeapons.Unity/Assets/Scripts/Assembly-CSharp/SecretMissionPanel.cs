using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SecretMissionPanel : MonoBehaviour
{
	public LayerSelect layerSelect;

	public int missionNumber;

	[HideInInspector]
	public Image img;

	[HideInInspector]
	public Sprite origSprite;

	public Sprite spriteOnComplete;

	[HideInInspector]
	public TMP_Text txt;

	[HideInInspector]
	public Button btn;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Setup()
	{
	}

	public void GotEnabled()
	{
	}
}
