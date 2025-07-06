namespace WafflesWeapons.Weapons.Charging;

public interface IChargeable
{
    public void ResetCharge();
    public void ChargeOverTime(float amount);
    public void MaxCharges();
}
