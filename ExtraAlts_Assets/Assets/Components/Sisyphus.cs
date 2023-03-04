using System.Collections;
using UnityEngine;
using NewBlood.IK;
using UnityEngine.AI;

[RequireComponent(typeof(Solver3D))]
public class Sisyphus : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Solver3D m_Solver;

    [SerializeField]
    Animator anim;

    [SerializeField]
    Transform m_Boulder;

    [SerializeField] 
    private Collider boulderCol;

    [SerializeField]
    PhysicalShockwave m_ShockwavePrefab;
    [SerializeField] GameObject explosion;

    [SerializeField] private GameObject rubble;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private ParticleSystem swingParticle;
    [SerializeField] private AudioSource swingAudio;

    public bool stationary;
    
    [SerializeField] private AudioClip[] attackVoices;
    [SerializeField] private AudioClip stompVoice;
    [SerializeField] private AudioClip deathVoice;

    [SerializeField] private Transform[] legs;
    [SerializeField] private Transform armature;
    
    [SerializeField] private GameObject attackFlash;

    enum AttackType
    {
        OverheadSlam,
        HorizontalSwing,
        Stab,
        AirStab,
    }

    public void Death() { }

    public void StompExplosion() { }
}
