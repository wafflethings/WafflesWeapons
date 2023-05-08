using System;
using UnityEngine;

namespace Sandbox
{
    [Serializable]
    public class EnemyRadianceConfig
    {
        public bool enabled;
        public float tier = 1;  

        public float damageBuff;
        public float speedBuff;
        public float healthBuff;

        public bool damageEnabled {get;set;}        public bool speedEnabled {get;set;}        public bool healthEnabled {get;set;}
        public EnemyRadianceConfig() {}
        public EnemyRadianceConfig(EnemyIdentifier enemyId) { }    }
}