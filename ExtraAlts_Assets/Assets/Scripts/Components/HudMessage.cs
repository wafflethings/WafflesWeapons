using UnityEngine;
using UnityEngine.UI;

public class HudMessage : MonoBehaviour
{
    public bool timed;
    public bool deactivating;
    public bool notOneTime;
    public bool dontActivateOnTriggerEnter;
    public bool silent;
    public bool deactiveOnTriggerExit;
    public string message;
    public string input;
    public string message2;

    public string playerPref;

    private string PlayerPref
{get;}
    public float timerTime = 5;

    private void Start() { }
    private void OnEnable() { }
    private void Update() { }
    void OnTriggerExit(Collider other) { }
    public void PlayMessage(bool hasToBeEnabled = false) { }
    public void ChangeMessage(string newMessage) { }}
