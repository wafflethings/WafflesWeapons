using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodsplatter : MonoBehaviour {
    public List<ParticleCollisionEvent> collisionEvents;
    public GameObject bloodStain;

    public Sprite[] sprites;
    public int hpAmount;

    public bool hpOnParticleCollision;

    public bool halfChance;
    public bool ready = false;
    public bool underwater;

    void Start() { }
    void OnParticleCollision(GameObject other) { }
    void DestroyIt() { }
    void DestroyCollider() { }
    public void GetReady() { }}
