using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomLevelPanel : MonoBehaviour
{
	[SerializeField]
	private PersistentColors nameColors;

	[Space]
	[SerializeField]
	private TMP_Text title;

	[SerializeField]
	private RawImage thumbnail;

	[Space]
	[SerializeField]
	private GameObject workshopInfoContainer;

	[SerializeField]
	private Button likeButton;

	[SerializeField]
	private TMP_Text likeCount;

	[SerializeField]
	private Image likeIcon;

	[SerializeField]
	private Button subscribeButton;

	[SerializeField]
	private Sprite subscribeSprite;

	[SerializeField]
	private Sprite subscribedSprite;

	[SerializeField]
	private Image subscribeIcon;

	[SerializeField]
	private Button dislikeButton;

	[SerializeField]
	private TMP_Text dislikeCount;

	[SerializeField]
	private Image dislikeIcon;

	[Space]
	[SerializeField]
	private GameObject downloadArrowIcon;

	[Space]
	[SerializeField]
	public HudOpenEffect detailsOpenEffect;

	[SerializeField]
	private TMP_Text description;

	[SerializeField]
	private CustomLevelStats stats;

	[Space]
	[SerializeField]
	private Image descriptionButton;

	[SerializeField]
	private Image statsButton;

	[SerializeField]
	private TMP_Text descriptionButtonLabel;

	[SerializeField]
	private TMP_Text statsButtonLabel;

	[Space]
	[SerializeField]
	private Button selfButton;

	[NonSerialized]
	public Vector2? originalDetailsSize;

	private string uniqueId;

	public void SetDetailsTab(int tabIndex)
	{
	}
}
