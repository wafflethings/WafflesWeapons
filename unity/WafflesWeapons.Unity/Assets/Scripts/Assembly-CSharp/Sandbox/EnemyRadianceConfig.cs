using System;

namespace Sandbox
{
	[Serializable]
	public class EnemyRadianceConfig
	{
		public bool enabled;

		public float tier;

		public float damageBuff;

		public float speedBuff;

		public float healthBuff;

		public bool damageEnabled => false;

		public bool speedEnabled => false;

		public bool healthEnabled => false;

		public EnemyRadianceConfig()
		{
		}

		public EnemyRadianceConfig(EnemyIdentifier enemyId)
		{
		}
	}
}
