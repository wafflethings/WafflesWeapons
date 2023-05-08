#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace DitzelGames.FastIK
{
    /// <summary>
    /// Fabrik IK Solver
    /// </summary>
    [DefaultExecutionOrder(int.MaxValue)]
    public class FastIKFabric : MonoBehaviour
    {
        /// <summary>
        /// Chain length of bones
        /// </summary>
        public int chainLength = 2;

        /// <summary>
        /// Target the chain should bent to
        /// </summary>
        public Transform target;
        public Transform pole;

        /// <summary>
        /// Solver iterations per update
        /// </summary>
        [Header("Solver Parameters")]
        public int iterations = 10;

        /// <summary>
        /// Distance when the solver stops
        /// </summary>
        public float delta = 0.001f;

        /// <summary>
        /// Strength of going back to the start position.
        /// </summary>
        [Range(0, 1)]
        public float snapBackStrength = 1f;


         
        void Awake() { }
        void Init() { }
         
        void LateUpdate() { }
        void OnDrawGizmos() { }
    }
}