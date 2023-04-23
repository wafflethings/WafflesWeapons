using UnityEngine;
using UnityEngine.UI;

public class RumbleKeyOptionEntry : MonoBehaviour
{
    public string key;
    public Text keyName;
    public Slider intensitySlider;
    public Slider durationSlider;

    public Button intensityWrapper;
    public Button durationWrapper;

    public GameObject durationContainer;
    
    public void ResetIntensity() { }    
    public void ResetDuration() { }    
    public void SetIntensity(float value) { }    
    public void SetDuration(float value) { }}