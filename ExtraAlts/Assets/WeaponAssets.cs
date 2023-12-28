using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace WafflesWeapons.Assets
{
    [Serializable]
    public class WeaponAssets : ScriptableObject
    {
        public string[] Keys;
        public Object[] Values;
        private Dictionary<string, Object> _assetDict = new();

        public T GetAsset<T>(string key) where T : Object
        {
            if (_assetDict.Count != Keys.Length)
            {
                for (int i = 0; i < Keys.Length; i++)
                {
                    _assetDict.Add(Keys[i], Values[i]);
                }
            }

            if (!_assetDict.ContainsKey(key))
            {
                throw new Exception($"WeaponAssets doesn't contain key {key}!");
            }

            return (T)_assetDict[key];
        }
    }
}
