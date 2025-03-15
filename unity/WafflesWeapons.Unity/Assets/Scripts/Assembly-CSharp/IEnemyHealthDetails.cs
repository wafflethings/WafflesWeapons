public interface IEnemyHealthDetails
{
	string FullName { get; }

	float Health { get; }

	bool Dead { get; }

	bool Blessed { get; }

	void ForceGetHealth();
}
