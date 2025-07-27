using UnityEngine;

namespace WafflesWeapons.Weapons.Shotguns.Singularity;

public class SingularityTendril : MonoBehaviour
{
    [SerializeField] private float _stillTime = 0.125f;
    [SerializeField] private float _fadeTime = 0.125f;
    [SerializeField] private LineRenderer[] _lrs;
    private Transform? _ball;
    private Transform? _target;
    private float[] _initialWidths;
    private float _lifetime = 0;

    public void SetPositions(Transform ball, GameObject target)
    {
        _ball = ball;
        _target ??= target.GetComponent<EnemyIdentifier>()?.weakPoint?.transform ?? target.transform;
    }

    private void Start()
    {
        _initialWidths = new float[_lrs.Length];

        for (int i = 0; i < _lrs.Length; i++)
        {
            _initialWidths[i] = _lrs[i].widthMultiplier;
        }
    }

    private void Update()
    {
        _lifetime += Time.deltaTime;
        
        if (_target == null || _ball == null || _lifetime > (_stillTime + _fadeTime))
        {
            Destroy(gameObject);
            return;
        }
        
        transform.LookAt(_target);
        
        for (int i = 0; i < _lrs.Length; i++)
        {
            LineRenderer lr = _lrs[i];
            lr.SetPositions([_target.transform.position, _ball.transform.position]);
            
            if (_lifetime < _stillTime)
            {
                continue;
            }
            
            lr.widthMultiplier = (1 - ((_lifetime - _stillTime) / _fadeTime)) * _initialWidths[i];
        }
    }
}
