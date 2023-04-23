using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sandbox
{
    public class AlterMenuElements : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [Header("Templates")]
        [SerializeField] private GameObject titleTemplate;
        [SerializeField] private GameObject boolRowTemplate;
        [SerializeField] private GameObject floatRowTemplate;
        
        public void CreateTitle(string name) { }
        public void CreateBoolRow(string name, bool initialState, Action<bool> callback) { }        
        public void CreateFloatRow(string name, float initialState, Action<float> callback) { }
        public void Reset() { }    }
}