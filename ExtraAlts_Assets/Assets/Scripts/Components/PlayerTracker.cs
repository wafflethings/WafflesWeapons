using UnityEngine;

public enum PlayerType
{
    FPS,
    Platformer
}

public enum PlatformerCameraType
{
    PlayerControlled,
    LevelControlled
}

public class PlayerTracker : MonoSingleton<PlayerTracker>
{
    public PlayerType playerType;

    public GameObject platformerPlayerPrefab;
    public PlatformerCameraType cameraType;
    public GameObject[] platformerFailSafes;

    void Start() { }
    public void ChangeToPlatformer() { }
    public void ChangeToPlatformer(bool ignorePreviousRotation = false) { }
    public void ChangeToFPS() { }
    void Initialize() { }
    void ChangeTargetParent(Transform toMove, Transform newParent, Vector3 offset = default(Vector3)) { }
    public void CheckPlayerType() { }
    public void LevelStart() { }}
