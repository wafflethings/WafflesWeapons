using System;
using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Weapons.Railcannon.Virtuous;

public class VirtuousVirtueInsignia : MonoBehaviour
{
    [SerializeField] private float _playerLaunchForce = 200;
    [SerializeField] private float _enemyLaunchForce = 1000;
    [SerializeField] private VirtueInsignia _insignia;
    private GameObject _holder;
    private List<Component> _alreadyHit = new(10);
    private GameObject? _sourceWeapon;

    public void SetSourceWeapon(GameObject sourceWeapon) => _sourceWeapon = sourceWeapon;
    
    private void Awake()
    {
        _holder = new GameObject();
        _holder.transform.position = transform.position;
        _insignia.target = new EnemyTarget(_holder.transform);
    }

    private void OnDestroy()
    {
        Destroy(_holder);
    }
    
    // reimplementation of the one in VirtueInsignia because i cba to transpile
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NewMovement>() && !_alreadyHit.Contains(NewMovement.Instance))
        {
            _alreadyHit.Add(NewMovement.Instance);
            NewMovement.Instance.LaunchFromPoint(NewMovement.Instance.transform.position, _playerLaunchForce, 5);
            NewMovement.Instance.GetHurt(_insignia.damage, true);
        }

        EnemyIdentifier? enemy = other.GetComponent<EnemyIdentifier>() ?? other.GetComponent<EnemyIdentifierIdentifier>()?.eid;
        if (enemy != null && !_alreadyHit.Contains(enemy))
        {
            _alreadyHit.Add(enemy);
            
            if (enemy.TryGetComponent(out Rigidbody rb))
            {
                rb.AddExplosionForce(_enemyLaunchForce, transform.position, 10);
            }
            
            enemy.DeliverDamage(enemy.gameObject, Vector3.zero, enemy.transform.position, _insignia.damage / 10f, false, sourceWeapon: _sourceWeapon);
            enemy.SimpleDamage(_insignia.damage / 10f);
        }

        if (other.TryGetComponent(out Flammable flammable) && !flammable.playerOnly)
        {
            flammable.Burn(10f);
        }
    }
}
