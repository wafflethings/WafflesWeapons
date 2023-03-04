using System.Collections.Generic;
using UnityEngine;

public class FleshPrison : MonoBehaviour
{
    public Transform rotationBone;
    public Transform target;

    public Texture[] idleTextures;
    public Texture hurtTexture;
    public Texture attackTexture;

    public GameObject fleshDrone;
    public GameObject skullDrone;

    public List<DroneFlesh> currentDrones = new List<DroneFlesh>();
    public GameObject healingTargetEffect;
    public GameObject healingEffect;

    public GameObject insignia;

    public GameObject homingProjectile;

    public GameObject attackWindUp;

    public GameObject blackHole;

    void Update()
    {
        
    }
}