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

        private void OnEnable() { }        
        private void Update() { }
        protected override void ProcessEvent(int? value) { }
        protected override void CallEvents() { }    }

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
