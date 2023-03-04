using UnityEngine;

public class TriggerSubtitle : MonoBehaviour
{
    [SerializeField] private string caption;
    [SerializeField] private bool activateOnEnableIfNoTrigger = true;

    public void PushCaption()
    {
        PushCaptionOverride(caption);
    }

    public void PushCaptionOverride(string caption)
    {
       
    }
}
