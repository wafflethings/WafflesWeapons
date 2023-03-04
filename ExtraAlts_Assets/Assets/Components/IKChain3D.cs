using System;
using UnityEngine;

namespace NewBlood.IK
{
    [Serializable]
    public sealed class IKChain3D
    {
        [SerializeField]
        Transform m_EffectorTransform;

        [SerializeField]
        Transform m_TargetTransform;

        [SerializeField]
        int m_TransformCount;

        [SerializeField]
        Transform[] m_Transforms;

        [SerializeField]
        Quaternion[] m_DefaultLocalRotations;

        [SerializeField]
        Quaternion[] m_StoredLocalRotations;
    }
}
