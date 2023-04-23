using Sandbox;
using UnityEngine;

public class Breakable : MonoBehaviour, IAlter, IAlterOptions<bool>
{
    public bool unbreakable;
    public bool weak;
    public bool precisionOnly;
    public bool interrupt;
    public bool playerOnly;
    public bool accurateExplosionsOnly;
    [Space(10)]
    public GameObject breakParticle;
    public bool particleAtBoundsCenter;
    [Space(10)]
    public bool crate;
    public int bounceHealth;
    public GameObject crateCoin;
    public int coinAmount;
    public bool protectorCrate;
    [Space(10)]
    public GameObject[] activateOnBreak;
    public GameObject[] destroyOnBreak;
    public UltrakillEvent destroyEvent;

    void Start() { }
    public void Bounce() { }
    void Update() { }    
    public void Break() { }
    public bool allowOnlyOne {get;set;}    public string alterKey {get;set;}    public string alterCategoryName {get;set;}
    public AlterOption<bool>[] options {get;set;}}
