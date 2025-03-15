using System;
using System.Collections.Generic;
using UnityEngine;

namespace JigglePhysics
{
	public class JiggleRigBuilder : MonoBehaviour
	{
		[Serializable]
		public class JiggleRig
		{
			[SerializeField]
			[Tooltip("The root bone from which an individual JiggleRig will be constructed. The JiggleRig encompasses all children of the specified root.")]
			private Transform rootTransform;

			[Tooltip("The settings that the rig should update with, create them using the Create->JigglePhysics->Settings menu option.")]
			public JiggleSettingsBase jiggleSettings;

			[SerializeField]
			[Tooltip("The list of transforms to ignore during the jiggle. Each bone listed will also ignore all the children of the specified bone.")]
			private List<Transform> ignoredTransforms;

			[SerializeField]
			private List<Collider> colliders;

			private bool initialized;

			[HideInInspector]
			private List<JiggleBone> simulatedPoints;

			public Transform GetRootTransform()
			{
				return null;
			}

			public JiggleRig(Transform rootTransform, JiggleSettingsBase jiggleSettings, ICollection<Transform> ignoredTransforms)
			{
			}

			public void PrepareBone()
			{
			}

			public void Simulate(Vector3 wind, double time)
			{
			}

			public void Initialize()
			{
			}

			public void DeriveFinalSolve()
			{
			}

			public void Pose(bool debugDraw)
			{
			}

			public void PrepareTeleport()
			{
			}

			public void FinishTeleport()
			{
			}

			public void OnDrawGizmos()
			{
			}

			private static void CreateSimulatedPoints(ICollection<JiggleBone> outputPoints, ICollection<Transform> ignoredTransforms, Transform currentTransform, JiggleBone parentJiggleBone)
			{
			}
		}

		[Tooltip("Enables interpolation for the simulation, this should be enabled unless you *really* need the simulation to only update on FixedUpdate.")]
		public bool interpolate;

		public List<JiggleRig> jiggleRigs;

		[Tooltip("An air force that is applied to the entire rig, this is useful to plug in some wind volumes from external sources.")]
		public Vector3 wind;

		[Tooltip("Draws some simple lines to show what the simulation is doing. Generally this should be disabled.")]
		[SerializeField]
		private bool debugDraw;

		private const float smoothing = 1f;

		private double accumulation;

		private void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void Advance(float deltaTime)
		{
		}

		public JiggleRig GetJiggleRig(Transform rootTransform)
		{
			return null;
		}

		private void LateUpdate()
		{
		}

		private void FixedUpdate()
		{
		}

		public void PrepareTeleport()
		{
		}

		public void FinishTeleport()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
