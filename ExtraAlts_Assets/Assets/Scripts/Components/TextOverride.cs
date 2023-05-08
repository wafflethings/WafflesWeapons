using UnityEngine;
using UnityEngine.UI;
using TMPro;

sealed class TextOverride : MonoBehaviour
{

    [TextArea]
    [SerializeField]
    string m_KeyboardText;

    [TextArea]
    [SerializeField]
    string m_GenericText;

    [TextArea]
    [SerializeField]
    string m_DualShockText;

    void Awake() { }
    void Update() { }
    void SetText(string value) { }}
