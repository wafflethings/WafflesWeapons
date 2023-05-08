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

        List<Vector3> m_TargetPositions = new List<Vector3>();

        public int chainCount => GetChainCount();

        public bool constrainRotation
        {
            get => m_ConstrainRotation;
            set => m_ConstrainRotation = value;
        }

        public bool solveFromDefaultPose
        {
            get => m_SolveFromDefaultPose;
            set => m_SolveFromDefaultPose = value;
        }

        public bool isValid
        {
            get
            {
                for (int i = 0; i < chainCount; i++)
                {
                    if (!GetChain(i).isValid)
                        return false;
                }

                return DoValidate();
            }
        }

        public bool allChainsHaveTargets
        {
            get
            {
                for (int i = 0; i < chainCount; i++)
                {
                    if (GetChain(i).target == null)
                        return false;
                }

                return true;
            }
        }

        public float weight
        {
            get => m_Weight;
            set => m_Weight = Mathf.Clamp01(value);
        }

        public void UpdateIK(float globalWeight) { }

        public void UpdateIK(List<Vector3> positions, float globalWeight) { }

        public void Initialize() { }

        public abstract IKChain3D GetChain(int index);

        protected abstract int GetChainCount();

        protected abstract void DoUpdateIK(List<Vector3> effectorPositions);

        protected virtual bool DoValidate() { return true; }

        protected virtual void DoInitialize() { }

        protected virtual void DoPrepare() { }

        protected virtual Transform GetRootTransform()
        {
            return null;
        }

        protected virtual void OnValidate() { }

        void Prepare() { }

        void PrepareEffectorPositions() { }

        void StoreLocalRotations() { }

        void BlendFKToIK(float finalWeight) { }
    }
}
