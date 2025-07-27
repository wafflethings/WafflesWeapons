using UnityEngine;

namespace WafflesWeapons.Weapons.Shotguns.Singularity;

public class SingularityImpulse : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _maxLifetime;
    private float _size;
    private float _lifetime;

    public void SetSize(float size) => _size = size;
    
    private void Update()
    {
        _lifetime += Time.deltaTime;
        transform.localScale = Vector3.one * (_curve.Evaluate(_lifetime / _maxLifetime) * _size);
    }
}
