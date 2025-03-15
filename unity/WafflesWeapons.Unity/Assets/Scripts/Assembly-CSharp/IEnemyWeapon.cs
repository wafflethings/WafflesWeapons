public interface IEnemyWeapon
{
	void UpdateTarget(EnemyTarget target);

	void Fire();

	void AltFire();

	void CancelAltCharge();
}
