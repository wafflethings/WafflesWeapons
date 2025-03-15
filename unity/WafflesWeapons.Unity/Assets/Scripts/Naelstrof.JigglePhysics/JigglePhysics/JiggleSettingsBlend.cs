using System.Collections.Generic;
using UnityEngine;

namespace JigglePhysics
{
	[CreateAssetMenu(fileName = "JiggleSettingsBlend", menuName = "JigglePhysics/Blend Settings", order = 1)]
	public class JiggleSettingsBlend : JiggleSettingsBase
	{
		[Tooltip("The list of jiggle settings to blend between.")]
		public List<JiggleSettings> blendSettings;

		[Range(0f, 1f)]
		[Tooltip("A value from 0 to 1 that linearly blends between all of the blendSettings.")]
		public float normalizedBlend;

		public override float GetParameter(JiggleSettingParameter parameter)
		{
			return 0f;
		}

		public override float GetRadius(float normalizedIndex)
		{
			return 0f;
		}
	}
}
