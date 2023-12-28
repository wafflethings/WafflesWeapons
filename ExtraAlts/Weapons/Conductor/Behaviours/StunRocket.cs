using UnityEngine;

namespace WafflesWeapons.Weapons.Conductor
{
    public class StunRocket : MonoBehaviour
    {
        private void Start()
        {
            Grenade grenade = GetComponent<Grenade>();
            
            GameObject effect = Instantiate(Conductor.MagnetZapEffect, transform);
            effect.transform.localScale *= 1.5f;
            ParticleSystem.EmissionModule emit = effect.GetComponent<ParticleSystem>().emission;
            emit.rateOverTimeMultiplier *= 2;

            if (grenade.rocket)
            {
                grenade.rocketSpeed *= 2f;
            }

            grenade.harmlessExplosion = Conductor.RocketExplosion;
            grenade.explosion = Conductor.RocketExplosion;
            grenade.superExplosion = Conductor.RocketExplosion;
        }
    }
}
