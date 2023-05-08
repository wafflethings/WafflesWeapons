using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshPrison : MonoBehaviour
{
    public Transform rotationBone;
    public Transform target;

    public bool altVersion;
    public Texture[] idleTextures;
    public Texture hurtTexture;
    public Texture attackTexture;
    [SerializeField] Renderer mainRenderer;

    public GameObject fleshDrone;
    public GameObject skullDrone;

    public List<DroneFlesh> currentDrones = new List<DroneFlesh>();
    public GameObject healingTargetEffect;
    public GameObject healingEffect;
    public GameObject insignia;

    public GameObject homingProjectile;

    public GameObject attackWindUp;

    public GameObject blackHole;
    
    private float maxDroneCooldown {get;set;}
    public UltrakillEvent onFirstHeal;

    void Awake() { }
     
    void Start() { }
     
    void Update() { }
    void SpawnFleshDrones() { }
    void StartHealing() { }
    void HealFromDrone() { }
    void HomingProjectileAttack() { }
    void SpawnInsignia() { }
    void SpawnBlackHole() { }
    public void ForceDronesOff() { }}
