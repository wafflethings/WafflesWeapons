using UnityEngine;

namespace WafflesWeapons.Weapons.Railcannon.Virtuous;

public class VirtuousBeam : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _otherHitBeam;
    [SerializeField] private GameObject _enemyHitBeam;
    [SerializeField] private RevolverBeam _rb;
    private bool _hasHitGround;
    
    private void Awake()
    {
        _rb.AddOnAnyHit(OnBeamHitAny);
        _rb.AddOnEnemyHit(OnBeamHitEnemy);
    }

    private void OnBeamHitAny(RevolverBeam beam, GameObject hitObject)
    {
        if (_hasHitGround || _rb.hit.point == Vector3.zero) // i think when the hit is the default value
        {
            return;
        }

        _hasHitGround = true;
        GameObject virtueBeam = Instantiate(_otherHitBeam, _rb.hit.point, Quaternion.identity);
        virtueBeam.transform.up = _rb.hit.normal;
        virtueBeam.transform.position += virtueBeam.transform.up * _offset;
    }

    private void OnBeamHitEnemy(RevolverBeam beam, EnemyIdentifier enemy)
    {
        if (enemy.dead)
        {
            return;
        }
        
        GameObject virtueBeam = Instantiate(_enemyHitBeam, beam.hitList[beam.enemiesPierced].rrhit.point, Quaternion.identity);
        // virtueBeam.transform.up = Vector3.up;
        virtueBeam.transform.position += virtueBeam.transform.up * _offset;
    }
}
