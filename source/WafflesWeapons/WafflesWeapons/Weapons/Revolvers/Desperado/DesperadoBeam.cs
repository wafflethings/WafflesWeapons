using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Weapons.Revolvers.Desperado;

public class DesperadoBeam : MonoBehaviour
{
    [SerializeField] private GameObject _selfPrefab;
    [SerializeField] private float _damageStep;
    [SerializeField] private int _maxBounces;
    [SerializeField] private float _maxDistance;
    [SerializeField] private RevolverBeam _rb;
    private int _bounces = 0;
    private List<EnemyIdentifier> _ignoreEnemies = new();
    private bool _wasDead = false;

    private void Awake()
    {
        _rb.AddBeforeEnemyHit(BeforeBeamHitEnemy);
        _rb.AddOnEnemyHit(OnBeamHitEnemy);
    }

    private void BeforeBeamHitEnemy(RevolverBeam beam, EnemyIdentifier enemy, float damage)
    {
        _wasDead = enemy.dead;
    }

    private void OnBeamHitEnemy(RevolverBeam beam, EnemyIdentifier enemy, float damage)
    {
        if (_maxBounces < ++_bounces || _ignoreEnemies.Contains(enemy) || (enemy.dead && _wasDead))
        {
            return;
        }
        
        _ignoreEnemies.Add(enemy);
        EnemyIdentifier? targetEnemy = WeaponUtils.ClosestEnemy(beam.hit.point, _maxDistance, _ignoreEnemies);

        if (targetEnemy == null)
        {
            return;
        }
        
        StartCoroutine(CreateNewBeam(targetEnemy));
    }

    private IEnumerator CreateNewBeam(EnemyIdentifier targetEnemy)
    {
        yield return new WaitForSeconds(0.1f);
        
        GameObject newBeam = Instantiate(_selfPrefab, _rb.hit.point, Quaternion.identity);
        newBeam.transform.LookAt((targetEnemy.weakPoint?.transform.position ?? targetEnemy.transform.position));
        newBeam.GetComponent<AudioSource>().enabled = false;
        
        RevolverBeam childBeam = newBeam.GetComponent<RevolverBeam>();
        childBeam.sourceWeapon = _rb.sourceWeapon;
        childBeam.damage = _rb.damage + _damageStep;
        childBeam.alternateStartPoint = childBeam.transform.position;

        DesperadoBeam childDespBeam = newBeam.GetComponent<DesperadoBeam>();
        childDespBeam._ignoreEnemies.AddRange(_ignoreEnemies);

        StartCoroutine(DisableCollisionsTemp());
    }

    // disable collisions for one frame during raycasts so raycasts dont hit ignored enemies, godawful hack, TODO maybeeee fix if it causes issues down the line
    private IEnumerator DisableCollisionsTemp()
    {
        List<Collider> enabledColliders = new();
        
        foreach (EnemyIdentifier enemy in _ignoreEnemies)
        {
            foreach (Collider collider in enemy.GetComponentsInChildren<Collider>(true))
            {
                if (!collider.enabled)
                {
                    continue;
                }
                
                enabledColliders.Add(collider);
                collider.enabled = false;
            }
        }

        yield return null;
        
        foreach (Collider collider in enabledColliders)
        {
            collider.enabled = true;
        }
    }
}
