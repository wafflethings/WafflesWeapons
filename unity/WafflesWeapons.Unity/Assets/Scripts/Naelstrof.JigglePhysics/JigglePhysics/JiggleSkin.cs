using System;
using System.Collections.Generic;
using UnityEngine;

namespace JigglePhysics
{
	public class JiggleSkin : MonoBehaviour
	{
		[Serializable]
		public class JiggleZone
		{
			[SerializeField]
			[Tooltip("The transform from which the zone effects, this is used as the 'center'.")]
			private Transform target;

			[Tooltip("How large of a radius the zone should effect, in target-space meters. (Scaling the target will effect the radius.)")]
			public float radius;

			[Tooltip("The settings that the skin should update with, create them using the Create->JigglePhysics->Settings menu option.")]
			public JiggleSettingsBase jiggleSettings;

			[HideInInspector]
			private JigglePoint simulatedPoint;

			private bool initialized;

			public void PrepareSimulate()
			{
			}

			public void Initialize()
			{
			}

			public Transform GetTargetBone()
			{
				return null;
			}

			public void Simulate(Vector3 wind, double time)
			{
			}

			public void DeriveFinalSolve(float smoothing)
			{
			}

			public void DebugDraw()
			{
			}

			public float GetLossyScale()
			{
				return 0f;
			}

			public Vector3 GetPosition()
			{
				return default(Vector3);
			}

			public Vector3 GetSolve()
			{
				return default(Vector3);
			}

			public void OnDrawGizmosSelected()
			{
			}
		}

		[Tooltip("Enables interpolation for the simulation, this should be enabled unless you *really* need the simulation to only update on FixedUpdate.")]
		public bool interpolate;

		public List<JiggleZone> jiggleZones;

		[SerializeField]
		[Tooltip("The list of skins to send the deformation data too, they should have JiggleSkin-compatible materials!")]
		public List<SkinnedMeshRenderer> targetSkins;

		[Tooltip("An air force that is applied to the entire rig, this is useful to plug in some wind volumes from external sources.")]
		public Vector3 wind;

		[SerializeField]
		[Tooltip("Draws some simple lines to show what the simulation is doing. Generally this should be disabled.")]
		private bool debugDraw;

		private double accumulation;

		private List<Material> targetMaterials;

		private List<Vector4> packedVectors;

		private int jiggleInfoNameID;

		private const float smoothing = 1f;

		private void Awake()
		{
		}

		public void Initialize()
		{
		}

		public JiggleZone GetJiggleZone(Transform target)
		{
			return null;
		}

		public void Advance(float deltaTime)
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateMesh()
		{
		}

		private void FixedUpdate()
		{
		}

		private void OnValidate()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public Vector3 ApplyJiggle(Vector3 toPoint, float blend)
		{
			return default(Vector3);
		}
	}
}
