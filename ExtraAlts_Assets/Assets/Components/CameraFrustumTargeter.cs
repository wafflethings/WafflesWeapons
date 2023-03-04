using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class CameraFrustumTargeter : MonoSingleton<CameraFrustumTargeter>
{

    public Collider CurrentTarget { get; private set; }

    public bool IsAutoAimed { get; private set; }

    public static bool IsEnabled
    {
        get => PlayerPrefs.GetInt("AutoAim", 0) != 0;
        set => PlayerPrefs.SetInt("AutoAim", value ? 1 : 0);
    }

    [SerializeField] RectTransform crosshair;

    [SerializeField] LayerMask mask;

    [SerializeField] LayerMask occlusionMask;

    [SerializeField] float maximumRange = 1000f;

    // Percentage of one half of the screen that defines the autoaim zone
    [SerializeField] float maxHorAim = 1f;
}
