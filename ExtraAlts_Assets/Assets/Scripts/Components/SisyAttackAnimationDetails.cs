using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ULTRAKILL/Attack Animation Details")]
public class SisyAttackAnimationDetails : ScriptableObject
{
    [Header("Boulder")]
    public float minBoulderSpeed = 0.01f;
    public float boulderDistanceDivide = 100;
    public float maxBoulderSpeed = 10000000000;
    [FormerlySerializedAs("durationMulti")] public float finalDurationMulti = 1;

     
     
    [Header("Anim")]
    public float speedDistanceMulti = 1;
    [FormerlySerializedAs("minSpeedCap")] public float minAnimSpeedCap = 0.1f;
    [FormerlySerializedAs("maxSpeedCap")] public float maxAnimSpeedCap = 1;
}