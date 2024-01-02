using System.Collections.Generic;
using UnityEngine;

namespace NewBlood.IK
{
    public sealed class IKManager3D : MonoBehaviour
    {
        [SerializeField]
        List<Solver3D> m_Solvers = new List<Solver3D>();

        [Range(0, 1)]
        [SerializeField]
        float m_Weight = 1;

        public float weight
        {
            get => m_Weight;
            set => m_Weight = Mathf.Clamp01(value);
        }

        public List<Solver3D> solvers
        {
            get => m_Solvers;
        }

        public void AddSolver(Solver3D solver)
        {
            if (m_Solvers.Contains(solver))
                return;

            m_Solvers.Add(solver);
        }

        public void RemoveSolver(Solver3D solver)
        {
            m_Solvers.Remove(solver);
        }

        public void UpdateManager() { }
        
        void LateUpdate()
        {
            UpdateManager();
        }

        void FindChildSolvers() { }

    #if UNITY_EDITOR
        void OnValidate()
        {
            m_Weight = Mathf.Clamp01(m_Weight);
        }

        void Reset()
        {
            FindChildSolvers();
        }
    #endif
    }
}
