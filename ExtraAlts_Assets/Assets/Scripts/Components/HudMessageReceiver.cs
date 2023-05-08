using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class HudMessageReceiver : MonoSingleton<HudMessageReceiver>
{

    private void Start() { }
    public void SendHudMessage(string newmessage, string newinput = "", string newmessage2 = "", int delay = 0, bool silent = false) { }
    public void ClearMessage() { }}
