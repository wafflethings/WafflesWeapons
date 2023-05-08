using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    [SerializeField] Magnet magnet;
    public bool drill;
    public float damage;
    public AudioClip environmentHitSound;
    public AudioClip enemyHitSound;
    public AudioSource drillSound;
    public int drillHits;
    [SerializeField] GameObject breakEffect;

    private void Start() { }
    void SlowUpdate() { }
    private void Update() { }
    private void FixedUpdate() { }
    public void Punched() { }
    void DestroyIfNotHit() { }
    void MasterDestroy() { }
    public void DelayedDestroyIfOnCorpse() { }
    void DestroyIfOnCorpse() { }}
