using UnityEngine;

namespace JigglePhysics
{
	[CreateAssetMenu(fileName = "JiggleSettings", menuName = "JigglePhysics/Settings", order = 1)]
	public class JiggleSettings : JiggleSettingsBase
	{
		[SerializeField]
		[Range(0f, 2f)]
		[Tooltip("How much gravity to apply to the simulation, it is a multiplier of the Physics.gravity setting.")]
		private float gravityMultiplier;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("How much mechanical friction to apply, this is specifically how quickly oscillations come to rest.")]
		private float friction;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("How much air friction to apply, this is how much jiggled objects should get dragged behind during movement. Or how *thick* the air is.")]
		private float airFriction;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("How much of the simulation should be expressed. A value of 0 would make the jiggle have zero effect. A value of 1 gives the full movement as intended.")]
		private float blend;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("How much angular force to apply in order to push the jiggled object back to rest.")]
		private float angleElasticity;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("How much to allow free bone motion before engaging elasticity.")]
		private float elasticitySoften;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("How much linear force to apply in order to keep the jiggled object at the correct length. Squash and stretch!")]
		private float lengthElasticity;

		[SerializeField]
		[Tooltip("How much radius points have, only used for collisions. Set to 0 to disable collisions")]
		private float radiusMultiplier;

		[SerializeField]
		private AnimationCurve radiusCurve;

		public override float GetParameter(JiggleSettingParameter parameter)
		{
			return 0f;
		}

		public void SetParameter(JiggleSettingParameter parameter, float value)
		{
		}

		public override float GetRadius(float normalizedIndex)
		{
			return 0f;
		}
	}
}
