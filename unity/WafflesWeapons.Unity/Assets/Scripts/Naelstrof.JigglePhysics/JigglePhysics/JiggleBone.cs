using System.Collections.Generic;
using UnityEngine;

namespace JigglePhysics
{
	public class JiggleBone
	{
		private struct PositionFrame
		{
			public Vector3 position;

			public double time;

			public PositionFrame(Vector3 position, double time)
			{
				this.position = default(Vector3);
				this.time = 0.0;
			}
		}

		private static SphereCollider sphereCollider;

		private PositionFrame currentTargetAnimatedBoneFrame;

		private PositionFrame lastTargetAnimatedBoneFrame;

		private Vector3 currentFixedAnimatedBonePosition;

		public JiggleBone parent;

		public JiggleBone child;

		private Quaternion boneRotationChangeCheck;

		private Vector3 bonePositionChangeCheck;

		public Quaternion lastValidPoseBoneRotation;

		private Vector3 lastValidPoseBoneLocalPosition;

		private float normalizedIndex;

		public Transform transform;

		private double updateTime;

		private double previousUpdateTime;

		public Vector3 position;

		public Vector3 previousPosition;

		public Vector3 preTeleportPosition;

		private Vector3 extrapolatedPosition;

		private float GetLengthToParent()
		{
			return 0f;
		}

		private Vector3 GetTargetBonePosition(PositionFrame prev, PositionFrame next, double time)
		{
			return default(Vector3);
		}

		public JiggleBone(Transform transform, JiggleBone parent, Vector3 position)
		{
		}

		public void CalculateNormalizedIndex()
		{
		}

		public void Simulate(JiggleSettingsBase jiggleSettings, Vector3 wind, double time, ICollection<Collider> colliders)
		{
		}

		public void CacheAnimationPosition()
		{
		}

		public Vector3 ConstrainLength(Vector3 newPosition, float elasticity)
		{
			return default(Vector3);
		}

		public void PrepareTeleport()
		{
		}

		public void FinishTeleport()
		{
		}

		public Vector3 ConstrainAngle(Vector3 newPosition, float elasticity, float elasticitySoften)
		{
			return default(Vector3);
		}

		public void SetNewPosition(Vector3 newPosition, double time)
		{
		}

		public static Vector3 NextPhysicsPosition(Vector3 newPosition, Vector3 previousPosition, Vector3 localSpaceVelocity, float deltaTime, float gravityMultiplier, float friction, float airFriction)
		{
			return default(Vector3);
		}

		public void DebugDraw(Color simulateColor, Color targetColor, bool interpolated)
		{
		}

		public Vector3 DeriveFinalSolvePosition(Vector3 offset, float smoothing)
		{
			return default(Vector3);
		}

		public void PrepareBone()
		{
		}

		public void OnDrawGizmos(JiggleSettingsBase jiggleSettings)
		{
		}

		public void PoseBone(float blend)
		{
		}
	}
}
