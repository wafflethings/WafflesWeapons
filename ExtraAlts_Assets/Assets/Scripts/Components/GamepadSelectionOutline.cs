using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GamepadSelectionOutline : MonoBehaviour
{

    [SerializeField]
    Image image;
    [SerializeField]
    private float scrollSpeedPixelsPerSecond = 800;
    [SerializeField]
    Vector2 outlineSize = new Vector2(4, 4);

    void Update() { }
    void EnsureVisibility(ScrollRect scrollRect, RectTransform child, bool instantScroll = false) { }}
