using System;
using UnityEngine;
using UnityEngine.Events;

namespace Logic
{
    [DefaultExecutionOrder(10)]
    public class MapFloatWatcher : MapVarWatcher<float?>
    {
        [SerializeField] private FloatWatchMode watchMode;
        [SerializeField] private UnityEventFloat onConditionMetWithValue;
        [SerializeField] private float targetValue = 3f;

        private void OnEnable() { }        
        private void Update() { }
        protected override void ProcessEvent(float? value) { }
        protected override void CallEvents() { }    }

    public enum FloatWatchMode
    {
        GreaterThan,
        LessThan,
        EqualTo,
        NotEqualTo,
        AnyChange
    }
    
    [Serializable] public sealed class UnityEventFloat : UnityEvent<float> {}
}