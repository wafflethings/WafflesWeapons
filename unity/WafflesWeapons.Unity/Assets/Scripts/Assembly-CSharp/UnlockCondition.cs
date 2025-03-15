using System;

[Serializable]
public abstract class UnlockCondition
{
	[Serializable]
	public class HasCompletedLevelChallenge : UnlockCondition
	{
		public int levelIndex;

		public override bool conditionMet => false;

		public override string description => null;
	}

	[Serializable]
	public class HasSeenEnemy : UnlockCondition
	{
		public EnemyType enemy;

		public override bool conditionMet => false;

		public override string description => null;
	}

	[Serializable]
	public class HasReachedLevel : UnlockCondition
	{
		public int levelIndex;

		public override bool conditionMet => false;

		public override string description => null;
	}

	[Serializable]
	public class HasCompletedLevel : UnlockCondition
	{
		public int levelIndex;

		public override bool conditionMet => false;

		public override string description => null;
	}

	[Serializable]
	public class HasCompletedSecretLevel : UnlockCondition
	{
		public int secretLevelIndex;

		public override bool conditionMet => false;

		public override string description => null;
	}

	[Serializable]
	public class HasObtainedWeapon : UnlockCondition
	{
		public string gearName;

		public override bool conditionMet => false;

		public override string description => null;
	}

	public abstract bool conditionMet { get; }

	public abstract string description { get; }

	public UnlockCondition()
	{
	}
}
