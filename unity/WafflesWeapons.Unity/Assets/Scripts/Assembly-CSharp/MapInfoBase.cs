using ScriptableObjects;
using UnityEngine;

public abstract class MapInfoBase : MonoBehaviour
{
	public static MapInfoBase Instance;

	public string layerName;

	public string levelName;

	public bool sandboxTools;

	public bool hideStockHUD;

	public bool replaceCheckpointButtonWithSkip;

	public bool forceUpdateEnemyRenderers;

	public bool continuousGibCollisions;

	public bool removeGibsWithoutAbsorbers;

	public float gibRemoveTime;

	public TipOfTheDay tipOfTheDay;

	internal virtual void Awake()
	{
	}
}
