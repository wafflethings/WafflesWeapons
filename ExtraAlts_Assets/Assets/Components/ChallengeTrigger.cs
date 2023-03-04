using UnityEngine;

public enum ChallengeType
{
    Succeed,
    Fail
}

public class ChallengeTrigger : MonoBehaviour
{
    public ChallengeType type;
    [Tooltip("Check if cheat to disable enemies has been enabled (for 4-1)")]
    public bool checkForNoEnemies;

    public void Entered() {}
}
