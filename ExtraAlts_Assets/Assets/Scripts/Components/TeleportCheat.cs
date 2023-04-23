using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TeleportCheat : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate;
    [SerializeField] private Color checkpointColor;
    [SerializeField] private Color roomColor;

    private void Start() { }
    private void Update() { }
    class TeleportTarget
    {
        public string overrideName;
        public CheckPoint checkpoint;
        public FirstRoomPrefab firstRoom;
        public Transform target;
    }
}