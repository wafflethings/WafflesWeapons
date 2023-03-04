using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logic
{
    [DefaultExecutionOrder(10)]
    public class MapBoolWatcher : MapVarWatcher<bool?>
    {
        [SerializeField] private BoolWatchMode watchMode;
        [SerializeField] private UnityEventBool onConditionMetWithValue;

        
        private void Update() { }
    }

    public enum BoolWatchMode
    {
        IsTrue,
        IsFalse,
        IsFalseOrNull,
        AnyValue
    }
    
    [Serializable]
    public sealed class UnityEventBool : UnityEvent<bool> {}
}