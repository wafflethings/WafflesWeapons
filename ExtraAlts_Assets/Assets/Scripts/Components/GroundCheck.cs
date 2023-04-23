using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool slopeCheck;
    public bool onGround = false;
    public bool touchingGround = false;
    public bool canJump = false;
    public bool heavyFall;
    public GameObject shockwave;
    public bool enemy;
    public float superJumpChance;
    public float extraJumpChance;
    
    public int forcedOff;

    private void Start() { }
    void OnEnable() { }
    void OnDisable() { }
    private void Update() { }
    void FixedUpdate() { }
    void BounceOnWater(Collider other) { }
    public void ForceOff() { }
    public void StopForceOff() { }}