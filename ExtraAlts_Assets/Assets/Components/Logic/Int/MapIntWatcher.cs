using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logic
{
    [DefaultExecutionOrder(10)]
    public class MapIntWatcher : MapVarWatcher<int?>
    {
        [SerializeField] private IntWatchMode watchMode;
        [SerializeField] private UnityEventInt onConditionMetWithValue;
        [SerializeField] private int targetValue = 0;
        
        private void Update() { }
    }

    public enum IntWatchMode
    {
        GreaterThan,
        LessThan,
        EqualTo,
        NotEqualTo,
        AnyChange
    } 
    
    [Serializable] public sealed class UnityEventInt : UnityEvent<int> {}
}