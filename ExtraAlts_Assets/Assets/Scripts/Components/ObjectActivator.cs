using UnityEngine;

public class ObjectActivator : MonoBehaviour {

    public bool oneTime;
    public bool disableOnExit;
    public bool dontActivateOnEnable;
    public bool reactivateOnEnable;
    public bool forEnemies;
    public bool notIfEnemiesDisabled;
    public bool onlyIfPlayerIsAlive;
    public float delay;

    [Space(20)]
    public ObjectActivationCheck obac;
    public bool onlyCheckObacOnce;

    [Space(10)]
    public UltrakillEvent events;

    private void Start() { }
    private void Update() { }
    public void Activate() { }
    public void Deactivate() { }
    private void OnDisable() { }
    private void OnEnable() { }}
