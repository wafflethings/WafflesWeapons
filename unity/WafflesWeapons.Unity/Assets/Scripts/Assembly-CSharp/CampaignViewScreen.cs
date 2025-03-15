using UnityEngine;
using UnityEngine.UI;

public class CampaignViewScreen : MonoBehaviour
{
	[SerializeField]
	private Text campaignTitle;

	[SerializeField]
	private CustomLevelButton buttonTemplate;

	[SerializeField]
	private Texture2D placeholderThumbnail;

	[SerializeField]
	private GameObject grid;

	public void Show(CustomCampaign campaign)
	{
	}

	public void Close()
	{
	}

	private void ResetGrid()
	{
	}
}
