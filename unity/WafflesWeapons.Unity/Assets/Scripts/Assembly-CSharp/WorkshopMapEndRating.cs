using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class WorkshopMapEndRating : MonoSingleton<WorkshopMapEndRating>
{
	[SerializeField]
	private GameObject container;

	[SerializeField]
	private TMP_Text mapName;

	[SerializeField]
	private Button voteUpButton;

	[SerializeField]
	private GameObject votedUpObject;

	[SerializeField]
	private Button voteDownButton;

	[SerializeField]
	private GameObject votedDownObject;

	[SerializeField]
	private Texture2D placeholderThumbnail;

	[SerializeField]
	private RawImage thumbnail;

	[SerializeField]
	private PersistentColors nameColors;

	public void VoteUp()
	{
	}

	public void VoteDown()
	{
	}

	public void LeaveAComment()
	{
	}

	public void ToggleFavorite()
	{
	}

	public void JustContinue()
	{
	}
}
