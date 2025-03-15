using UnityEngine;
using UnityEngine.UI;

public class AuthorLinkRow : MonoBehaviour
{
	public Text platformName;

	public Text platformUsername;

	public Text platformDisplayName;

	public Text description;

	private string url;

	public void Instantiate(string platform, string username, string displayName, Color platformColor, string targetURL, string descriptionText = "")
	{
	}

	public void OnClick()
	{
	}
}
