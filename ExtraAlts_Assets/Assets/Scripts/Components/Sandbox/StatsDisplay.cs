using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sandbox
{
    public class SandboxStats
    {
        public int brushesBuilt;
        public int propsSpawned;
        public int enemiesSpawned;
        public float hoursSpend;
    }
    
    public class StatsDisplay : MonoBehaviour
    {
        [SerializeField] private Text textContent;

        private void OnEnable() { }
        private void Update() { }    }
}
