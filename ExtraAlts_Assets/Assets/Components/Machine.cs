using UnityEngine;
using UnityEngine.Events;

public class Machine : MonoBehaviour
{
    public float health;
    public bool limp;
    public GameObject chest;
    public AudioClip[] hurtSounds;
    public Material deadMaterial;
    public SkinnedMeshRenderer smr;
    public AudioClip deathSound;
    public AudioClip scream;
    public bool bigKill;
    public bool parryable;
    public bool partiallyParryable;
    public GameObject[] destroyOnDeath;
    public Machine symbiote;
    public bool grounded;
    public bool knockedBack;
    public bool overrideFalling;
    public float brakes;
    public float juggleWeight;
    public bool falling;
    public bool noFallDamage;
    public bool dontDie;
    public bool dismemberment;
    public bool specialDeath;
    public UnityEvent onDeath;

    public void KnockBack(Vector3 force)
    {
        
    }

    public void StopKnockBack()
    {
        
    }

    public void GoLimp()
    {
        
    }
}
