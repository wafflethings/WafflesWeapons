using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class DebugUI : MonoSingleton<DebugUI>
{
    [SerializeField] private GameObject rumbleContainer;
    [SerializeField] private RectTransform rumbleIconTransform;
    [SerializeField] private Image rumbleImage;
    [SerializeField] private Slider rumbleIntensityBar;

    private void Update() { }}
