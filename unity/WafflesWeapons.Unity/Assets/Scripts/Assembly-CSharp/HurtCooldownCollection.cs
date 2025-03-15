using System.Collections.Generic;
using plog;

public class HurtCooldownCollection
{
	private static readonly Logger Log;

	private const float HurtDelay = 0.5f;

	private readonly Dictionary<EnemyIdentifier, TimeSince> timeSinceHurtEnemies;

	private readonly Dictionary<Flammable, TimeSince> timeSinceHurtFlammables;

	private TimeSince? timeSinceHurtPlayer;

	public bool TryHurtCheckEnemy(EnemyIdentifier eid, bool autoUpdate = true)
	{
		return false;
	}

	public void ResetEnemyCooldown(EnemyIdentifier eid)
	{
	}

	public bool TryHurtCheckPlayer(bool autoUpdate = true)
	{
		return false;
	}

	public void ResetPlayerCooldown()
	{
	}

	public bool TryHurtCheckFlammable(Flammable flammable, bool autoUpdate = true)
	{
		return false;
	}

	public void ResetFlammableCooldown(Flammable flammable)
	{
	}
}
