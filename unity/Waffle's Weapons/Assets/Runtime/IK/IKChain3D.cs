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

        float[] m_Lengths;

        public bool isValid
        {
            get
            {
                if (m_EffectorTransform == null)
                    return false;

                if (m_TransformCount == 0)
                    return false;

                if (m_Transforms == null || m_Transforms.Length != m_TransformCount)
                    return false;

                if (m_DefaultLocalRotations == null || m_DefaultLocalRotations.Length != m_TransformCount)
                    return false;

                if (m_StoredLocalRotations == null || m_StoredLocalRotations.Length != m_TransformCount)
                    return false;

                if (m_Transforms[0] == null)
                    return false;

                if (m_Transforms[m_TransformCount - 1] != m_EffectorTransform)
                    return false;

                if (m_TargetTransform != null && IKUtility.IsDescendantOf(m_TargetTransform, m_Transforms[0], m_TransformCount))
                    return false;

                return true;
            }
        }

        public int transformCount
        {
            get => m_TransformCount;
        }

        public Transform effector
        {
            get => m_EffectorTransform;
            set => m_EffectorTransform = value;
        }

        public Transform target
        {
            get => m_TargetTransform;
            set => m_TargetTransform = value;
        }

        public Transform[] transforms
        {
            get => m_Transforms;
        }

        public Transform rootTransform
        {
            get
            {
                if (m_TransformCount == 0)
                    return null;

                if (m_Transforms == null || m_Transforms.Length != m_TransformCount)
                    return null;

                return m_Transforms[0];
            }
        }

        public float[] lengths
        {
            get
            {
                if (isValid)
                {
                    PrepareLengths();
                    return m_Lengths;
                }

                return null;
            }
        }

        public void Initialize() { }

        public void RestoreDefaultPose(bool targetRotationIsConstrained) { }

        public void StoreLocalRotations() { }

        public void BlendFKToIK(float finalWeight, bool targetRotationIsConstrained) { }

        void PrepareLengths() { }
    }
}
