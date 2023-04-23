using UnityEngine;
using UnityEngine.UI;

public class RumbleSettingsMenu : MonoBehaviour
{
    [SerializeField] private RumbleKeyOptionEntry optionTemplate;
    [SerializeField] private Transform container;
    [SerializeField] private Button totalWrapper;
    [SerializeField] private Button quitButton;
    [SerializeField] private Slider totalSlider;

    private void Start() { }    
    public void ChangeMasterMulti(float value) { }    
    public void Show() { }}