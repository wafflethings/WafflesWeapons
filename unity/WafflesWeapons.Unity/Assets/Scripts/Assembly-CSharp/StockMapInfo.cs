using UnityEngine;

[DefaultExecutionOrder(-300)]
public class StockMapInfo : MapInfoBase
{
	public new static StockMapInfo Instance;

	public string nextSceneName;

	public SerializedActivityAssets assets;

	internal override void Awake()
	{
	}
}
