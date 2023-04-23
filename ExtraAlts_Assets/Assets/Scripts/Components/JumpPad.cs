using Sandbox;
using UnityEngine;

public class JumpPad : MonoBehaviour, IAlter, IAlterOptions<float>
{
    public float force;

    public AudioClip launchSound;
    public AudioClip lightLaunchSound;

    public bool forceDirection;

    private void Start() { }
    public string alterKey {get;set;}    public string alterCategoryName {get;set;}    public bool allowOnlyOne {get;set;}
    public AlterOption<float>[] options {get;set;}}
