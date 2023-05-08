using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMelee : MonoBehaviour
{
    public bool harmless;
    public bool damaging;
    public TrailRenderer tr;
    public bool track;
    public float coolDown;

    public Zombie zmb;
    public GameObject swingSound;

    public LayerMask lmask;
    public Material originalMaterial;
    public Material biteMaterial;

     
    void Start () {}	
	 
	void Update () {}
    private void OnEnable() { }
    private void OnDisable() { }
    private void FixedUpdate() { }
    public void Swing() { }
    public void SwingEnd() { }
    public void DamageStart() { }
    public void DamageEnd() { }
    public void StopTracking() { }
    public void CancelAttack() { }
    public void TrackTick() { }
    public void MouthClose() { }
    void MouthOpen() { }}
