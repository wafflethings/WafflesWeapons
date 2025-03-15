using UnityEngine;

namespace JigglePhysics
{
	public class JigglePoint
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

		private Vector3 position;

		private Transform transform;

		private Vector3 previousPosition;

		private double previousUpdateTime;

		private double updateTime;

		private Vector3 parentPosition;

		private Vector3 previousParentPosition;

		private PositionFrame currentTargetAnimatedBoneFrame;

		private PositionFrame lastTargetAnimatedBoneFrame;

		public Vector3 extrapolatedPosition;

		public JigglePoint(Transform transform)
		{
		}

		public void PrepareSimulate()
		{
		}

		private Vector3 GetTargetBonePosition(PositionFrame prev, PositionFrame next, double time)
		{
			return default(Vector3);
		}

		public void Simulate(JiggleSettingsBase jiggleSettings, Vector3 force, double time)
		{
		}

		public void SetNewPosition(Vector3 newPosition, double time)
		{
		}

		public void DeriveFinalSolvePosition(float smoothing)
		{
		}

		public Vector3 ConstrainSpring(Vector3 newPosition, float elasticity)
		{
			return default(Vector3);
		}

		public void DrawGizmos(Color color)
		{
		}

		public void DebugDraw(Color color)
		{
		}
	}
}
