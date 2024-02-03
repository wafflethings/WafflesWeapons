using System;
using AtlasLib.Utils;
using UnityEngine;
using WafflesWeapons.Utils;

namespace WafflesWeapons.Weapons.DrillRocket.Behaviours;

public class UndergroundDrill : MonoBehaviour
{
    public GameObject DigEffect;
    public float DigInterval;
    public GameObject Explosion;
    public float StartSpeed = 5f;
    public float Acceleration = 1f;
    public float Jolt = 10f;
    private float _speed;
    private Rigidbody _rb;
    private UndergroundDrillState _state;
    private float _floorEnterYAngle;
    private float _offset;
    private float _digEffectTimer;
    private float _timeJumping;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _speed = StartSpeed;
    }

    private void FixedUpdate()
    {
        Acceleration += Time.deltaTime * Jolt;
        _speed += Time.deltaTime * Acceleration;
        
        if (Physics.Raycast(transform.position + (_state == UndergroundDrillState.InGround ? transform.up : Vector3.zero), 
                _state == UndergroundDrillState.InGround ? -transform.up : Vector3.down, out RaycastHit hit, 
                _state == UndergroundDrillState.InGround ? 100 : 1.5f, LayerMaskDefaults.Get(LMD.Environment)))
        {
            
            if (_state == UndergroundDrillState.InAir)
            {
                _state = UndergroundDrillState.InGround;
                //_offset = Vector3.Distance(transform.position, hit.point - hit.normal);
                transform.position = hit.point; // - hit.normal;
                _floorEnterYAngle = transform.rotation.eulerAngles.y;
            }

            if (_state != UndergroundDrillState.Jumping)
            {
                transform.up = hit.normal;
                transform.rotation *= Quaternion.Euler(0, _floorEnterYAngle, 0);
            }
            //Quaternion newRotation = transform.rotation;
            //transform.rotation = Quaternion.RotateTowards(oldRotation, newRotation, 720 * Time.deltaTime);
        }

        if (_state == UndergroundDrillState.InGround)
        {
            _rb.isKinematic = true;
            transform.position += Time.deltaTime * _speed * transform.forward;

            _digEffectTimer += Time.deltaTime;

            if (_digEffectTimer > DigInterval)
            {
                _digEffectTimer = 0;
                CreateDigEffect(hit.point, hit.normal);
            }
            
            GameObject nearestEnemy = UltrakillUtils.NearestEnemy(transform.position, 15f);
            Vector3 nearestEnemyWithoutY = new Vector3(nearestEnemy?.transform.position.x ?? 0, 0, nearestEnemy?.transform.position.z ?? 0);
            Vector3 positionWithoutY = new Vector3(transform.position.x, 0, transform.transform.position.z);
            if ((bool)nearestEnemy && Vector3.SqrMagnitude(positionWithoutY - nearestEnemyWithoutY) < 5*5)
            {
                transform.forward = nearestEnemyWithoutY - positionWithoutY;
                Jump();
            }
        }

        if (_state == UndergroundDrillState.Jumping)
        {
            _timeJumping += Time.deltaTime;
            if (_timeJumping > 0.25f && Physics.Raycast(transform.position, Vector3.down, 0.5f, LayerMaskDefaults.Get(LMD.Environment)))
            {
                Explode();
            }
            
            transform.rotation = Quaternion.Euler(_rb.velocity.normalized.y * -80, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }

    public void Jump()
    {
        Debug.Log("Jumping!!");
        GetComponent<CapsuleCollider>().enabled = false;
        _state = UndergroundDrillState.Jumping;
        _rb.isKinematic = false;
        _rb.AddForce((transform.up * 3500) + (transform.forward * 725));
        _rb.mass *= 2;
    }
    
    private void CreateDigEffect(Vector3 position, Vector3 normal)
    {
        GameObject effect = Instantiate(DigEffect);
        effect.transform.position = position;
        effect.transform.up = normal;
    }

    public void ExplodeWithFlash()
    {
        TimeController.Instance.ParryFlash();
        Explode();
    }
    
    public void Explode()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered {other.gameObject.name} on layer {other.gameObject.layer}");
        if (_state == UndergroundDrillState.Jumping && _timeJumping > 0.25f && LayerMaskDefaults.Get(LMD.Enemies).Contains(other.gameObject.layer))
        {
            Explode();
        }
    }
}
