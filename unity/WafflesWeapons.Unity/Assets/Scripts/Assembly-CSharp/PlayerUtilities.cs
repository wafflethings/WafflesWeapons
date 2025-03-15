using UnityEngine;

public class PlayerUtilities : MonoSingleton<PlayerUtilities>
{
	public bool enableOutput;

	public string distanceTraveledMapVar;

	public string currentHealthVar;

	public string currentHardDamageVar;

	public string currentStyleScoreVar;

	public string currentTimeVar;

	public string currentKillCountVar;

	public string currentRankVar;

	private static AudioSource detachedWhoosh;

	private float distanceTraveled;

	private Vector3? lastRecordedPosition;

	public void Update()
	{
	}

	public void DisablePlayer()
	{
	}

	public void EnablePlayer()
	{
	}

	public void FreezePlayer()
	{
	}

	public void UnfreezePlayer()
	{
	}

	public void FadeOutFallingWhoosh()
	{
	}

	public void FadeOutFallingWhooshCustomSpeed(float speed)
	{
	}

	public void RestoreFallingWhoosh()
	{
	}

	public void YesWeapon()
	{
	}

	public void NoWeapon()
	{
	}

	public void YesFist()
	{
	}

	public void NoFist()
	{
	}

	public void HealPlayer(int health)
	{
	}

	public void HealPlayerSilent(int health)
	{
	}

	public void EmptyStamina()
	{
	}

	public void FullStamina()
	{
	}

	public void ResetHardDamage()
	{
	}

	public void MaxCharges()
	{
	}

	public void DestroyHeldObject()
	{
	}

	public void PlaceHeldObject(ItemPlaceZone target)
	{
	}

	public void ForceHoldObject(ItemIdentifier pickup)
	{
	}

	public void ParryFlash()
	{
	}

	public void QuitMap()
	{
	}

	public void FinishMap()
	{
	}

	public void SetGravity(float gravity)
	{
	}

	public void SetGravity(Vector3 gravity)
	{
	}

	public void SetPlayerHealth(int health)
	{
	}

	public void SetPlayerHardDamage(float damage)
	{
	}

	public void SetPlayerStamina(float boostCharge)
	{
	}
}
