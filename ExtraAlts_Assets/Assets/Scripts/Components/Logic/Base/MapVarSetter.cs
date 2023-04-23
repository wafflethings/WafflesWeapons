using System;
using UnityEngine;

namespace Logic
{
    public abstract class MapVarSetter : MonoBehaviour
    {
        public string variableName;
        public VariablePersistence persistence;
        public bool setOnEnable = true;
        public bool setEveryFrame = false;

        private void OnEnable() { }
        private void Update() { }
        public virtual void SetVar() { }    }
    
    public enum VariablePersistence
    {
        Session = 0, SavedAsMap = 1, SavedAsCampaign = 2
    }

    public enum VariableType
    {
        Bool = 0, Int = 1, String = 2, Float = 3,
    }
}