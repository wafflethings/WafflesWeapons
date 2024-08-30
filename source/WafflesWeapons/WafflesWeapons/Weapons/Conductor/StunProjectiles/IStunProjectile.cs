using UnityEngine;

namespace WafflesWeapons.Weapons.Conductor.StunProjectiles;

public interface IStunProjectile
{
    public void Initialize(ConductorBehaviour source, float chargeLength);
}