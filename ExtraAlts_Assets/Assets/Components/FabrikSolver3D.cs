using System.Collections.Generic;
using UnityEngine;

namespace NewBlood.IK
{
    public sealed class FabrikSolver3D : Solver3D
    {
        public const float MinTolerance = .001f;

        public const int MinIterations = 1;

        [SerializeField] IKChain3D m_Chain = new IKChain3D();

        [SerializeField] [Range(MinIterations, 50)]
        int m_Iterations = 10;

        [SerializeField] [Range(MinTolerance, .1f)]
        float m_Tolerance = .01f;
    }
}
