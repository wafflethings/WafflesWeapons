using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class WorkshopMapEndLinks : MonoSingleton<WorkshopMapEndLinks>
{
	[SerializeField]
	private AuthorLinkRow baseRow;

	[SerializeField]
	private GameObject container;

	public void Show()
	{
	}

	public static string GetLink(LinkPlatform platform, string username)
	{
		return null;
	}

	public static Color GetColor(LinkPlatform platform)
	{
		return default(Color);
	}

	public void Continue()
	{
	}
}
