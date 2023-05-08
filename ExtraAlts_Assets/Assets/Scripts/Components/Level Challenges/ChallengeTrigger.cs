using UnityEngine;

public enum ChallengeType
{
    Succeed,
    Fail
}

public class ChallengeTrigger : MonoBehaviour
{
    public ChallengeType type;
    public bool checkForNoEnemies;  
    public bool evenIfPlayerDead;

    private void Start() { }
    public void Entered() { }}
