using UnityEngine;

public class TriggerSubtitle : MonoBehaviour
{
    [SerializeField] [TextArea] private string caption;
    [SerializeField] private bool activateOnEnableIfNoTrigger = true;

    private void OnEnable() { }
    public void PushCaption() { }
    public void PushCaptionOverride(string caption) { }}
