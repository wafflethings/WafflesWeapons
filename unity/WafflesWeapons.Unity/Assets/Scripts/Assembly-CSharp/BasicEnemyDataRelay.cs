using UnityEngine;

public class BasicEnemyDataRelay : MonoBehaviour, IPlaceholdableComponent
{
	[HideInInspector]
	public EnemyType enemyType;

	[HideInInspector]
	public float health;

	public void WillReplace(GameObject oldObject, GameObject newObject, bool isSelfBeingReplaced)
	{
	}

	private void Apply(BasicEnemyDataRelay source)
	{
	}
}
