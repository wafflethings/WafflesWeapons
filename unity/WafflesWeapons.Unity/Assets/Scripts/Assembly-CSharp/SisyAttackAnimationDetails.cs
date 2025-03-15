using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ULTRAKILL/Attack Animation Details")]
public class SisyAttackAnimationDetails : ScriptableObject
{
	[Header("Boulder")]
	public float minBoulderSpeed;

	public float boulderDistanceDivide;

	public float maxBoulderSpeed;

	[FormerlySerializedAs("durationMulti")]
	public float finalDurationMulti;

	[Header("Anim")]
	public float speedDistanceMulti;

	[FormerlySerializedAs("minSpeedCap")]
	public float minAnimSpeedCap;

	[FormerlySerializedAs("maxSpeedCap")]
	public float maxAnimSpeedCap;
}
