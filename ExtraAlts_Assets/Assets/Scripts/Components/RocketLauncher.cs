using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour
{
    public int variation;
    public GameObject rocket;
    public GameObject clunkSound;
    public float rateOfFire;

    public Transform shootPoint;
    public GameObject muzzleFlash;

    [SerializeField] Image timerMeter;
    [SerializeField] RectTransform timerArm;
    [SerializeField] Image[] variationColorables;

    [Header("Freeze variation")]
    [SerializeField] AudioSource timerFreezeSound;
    [SerializeField] AudioSource timerUnfreezeSound;
    [SerializeField] AudioSource timerTickSound;
    [SerializeField] AudioSource timerWindupSound;

    [Header("Cannonball variation")]
    public Rigidbody cannonBall;
    [SerializeField] AudioSource chargeSound;

     
    void Start() { }
    private void OnEnable() { }
    private void OnDisable() { }
    void OnDestroy() { }
     
    void Update() { }
    public void Shoot() { }
    public void ShootCannonball() { }
    public void FreezeRockets() { }
    public void UnfreezeRockets() { }    
    public void Clunk(float pitch) { }}
