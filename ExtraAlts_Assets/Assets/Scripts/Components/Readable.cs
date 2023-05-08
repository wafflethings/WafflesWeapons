using System;
using UnityEngine;

public class Readable : MonoBehaviour
{
    [SerializeField] [TextArea(3, 12)] private string content;
    [SerializeField] private bool instantScan;

    public void PickUp() { }
    public void PutDown() { }}
