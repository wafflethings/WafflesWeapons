using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Physics = UnityEngine.Physics;

public class Magnet : MonoBehaviour
{
    public List<EnemyIdentifier> ignoredEids = new List<EnemyIdentifier>();
    public bool onEnemy;

    public List<Magnet> connectedMagnets = new List<Magnet>();
    public List<Rigidbody> sawblades = new List<Rigidbody>();
    public List<Rigidbody> rockets = new List<Rigidbody>();
    public float strength;

    [SerializeField] private float maxWeight = 10;

    private float maxWeightFinal
{get;}
    private void Start() { }
    public void Launch() { }
    public void ConnectMagnets(Magnet target) { }
    public void DisconnectMagnets(Magnet target) { }
    public void ExitEnemy(EnemyIdentifier eid) { }
    private void Update() { }}
