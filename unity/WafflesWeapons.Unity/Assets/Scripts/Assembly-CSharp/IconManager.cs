using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class IconManager : MonoSingleton<IconManager>
{
	[SerializeField]
	private CheatAssetObject[] iconPacks;

	private int currentIconPack;

	private bool prefFetched;

	public int CurrentIconPackId => 0;

	public CheatAssetObject CurrentIcons => null;

	protected override void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPrefChanged(string key, object value)
	{
	}

	private int FetchSavedPref()
	{
		return 0;
	}

	public string[] AvailableIconPacks()
	{
		return null;
	}

	public void SetIconPack(int pack, bool setPref = true)
	{
	}

	public void Reload()
	{
	}
}
