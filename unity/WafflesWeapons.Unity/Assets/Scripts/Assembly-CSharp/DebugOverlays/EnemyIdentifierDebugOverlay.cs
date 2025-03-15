using UnityEngine;

namespace DebugOverlays
{
	public class EnemyIdentifierDebugOverlay : MonoBehaviour
	{
		private EnemyType enemyType;

		private EnemyClass enemyClass;

		private bool dead;

		private bool ignorePlayer;

		private bool attackEnemies;

		private EnemyTarget target;

		public void ConsumeData(EnemyType enemyType, EnemyClass enemyClass, bool dead, bool ignorePlayer, bool attackEnemies, EnemyTarget target)
		{
		}

		private void OnGUI()
		{
		}
	}
}
