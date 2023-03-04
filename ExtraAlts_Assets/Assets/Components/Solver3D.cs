using System.Collections.Generic;
using UnityEngine;

namespace NewBlood.IK
{
    public abstract class Solver3D : MonoBehaviour
    {
        [SerializeField]
        bool m_ConstrainRotation = true;

        [SerializeField]
        bool m_SolveFromDefaultPose = true;

        [Range(0, 1)]
        [SerializeField]
        float m_Weight = 1;
    }
}
