using System.Collections.Generic;
using UnityEngine;

namespace NewBlood.IK
{
    public sealed class FabrikSolver3D : Solver3D
    {
        public const float MinTolerance = .001f;

        public const int MinIterations = 1;

        [SerializeField]
        IKChain3D m_Chain = new IKChain3D();

        [SerializeField]
        [Range(MinIterations, 50)]
        int m_Iterations = 10;

        [SerializeField]
        [Range(MinTolerance, .1f)]
        float m_Tolerance = .01f;

        Vector3[] m_Positions;

        public int iterations
        {
            get => m_Iterations;
            set => m_Iterations = Mathf.Max(value, MinIterations);
        }

        public float tolerance
        {
            get => m_Tolerance;
            set => m_Tolerance = Mathf.Max(value, MinTolerance);
        }

        public override IKChain3D GetChain(int index)
        {
            return m_Chain;
        }

        protected override int GetChainCount()
        {
            return 1;
        }

        protected override void DoUpdateIK(List<Vector3> effectorPositions) { }

        // Implementations based on com.unity.2d.ik
        void Forward(Vector3 targetPosition, float[] lengths, Vector3[] positions) { }

        void Backward(Vector3 originPosition, float[] lengths, Vector3[] positions) { }
    }
}
