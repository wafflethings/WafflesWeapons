using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField] private bool instantiateOnEnable = true;
    [SerializeField] private GameObject source;
    [SerializeField] private InstantiateObjectMode mode = InstantiateObjectMode.Normal;
    [SerializeField] private bool removePreviousOnInstantiate = true;
    [SerializeField] private bool reParent = true;
    [SerializeField] private bool useOwnPosition = true;
    [SerializeField] private bool useOwnRotation = true;
    [SerializeField] private bool combineRotations = false;

    private void OnEnable() { }
    public void Instantiate() { }}

public enum InstantiateObjectMode { Normal, ForceEnable, ForceDisable }
