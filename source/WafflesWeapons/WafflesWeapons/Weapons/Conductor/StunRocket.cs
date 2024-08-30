using UnityEngine;
using WafflesWeapons.Weapons.Conductor.StunProjectiles;

namespace WafflesWeapons.Weapons.Conductor;

public class StunRocket : MonoBehaviour
{
    public void Initialize(GameObject explosion, GameObject lightningEffect)
    {
        Grenade grenade = GetComponent<Grenade>();
            
        GameObject effect = Instantiate(lightningEffect, transform);
        effect.transform.localScale *= 1.5f;
        ParticleSystem.EmissionModule emit = effect.GetComponent<ParticleSystem>().emission;
        emit.rateOverTimeMultiplier *= 2;

        if (grenade.rocket)
        {
            grenade.rocketSpeed *= 2f;
        }

        grenade.harmlessExplosion = explosion;
        grenade.explosion = explosion;
        grenade.superExplosion = explosion;
    }
}
