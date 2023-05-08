using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    SkullBlue,
    SkullRed,
    SkullGreen,
    Readable,
    Torch,
    Soap,
    CustomKey1,
    CustomKey2,
    CustomKey3
};

public class ItemIdentifier : MonoBehaviour
{
    public bool infiniteSource = false;
    public bool pickedUp;
    public bool reverseTransformSettings;
    public Vector3 putDownPosition;
    public Vector3 putDownRotation;
    public Vector3 putDownScale = Vector3.one;

    public GameObject pickUpSound;

    public ItemType itemType;

    public bool noHoldingAnimation;

    public UltrakillEvent onPickUp;
    public UltrakillEvent onPutDown;

    void PickUp() { }
    void PutDown() { }}
