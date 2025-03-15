using UnityEngine;

namespace JigglePhysics
{
	public class JiggleSettingsBase : ScriptableObject
	{
		public enum JiggleSettingParameter
		{
			Gravity = 0,
			Friction = 1,
			AirFriction = 2,
			Blend = 3,
			AngleElasticity = 4,
			ElasticitySoften = 5,
			LengthElasticity = 6,
			RadiusMultiplier = 7
		}

		public virtual float GetParameter(JiggleSettingParameter parameter)
		{
			return 0f;
		}

		public virtual float GetRadius(float normalizedIndex)
		{
			return 0f;
		}
	}
}
