using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SubtitledAudioSource : MonoBehaviour
{
    [SerializeField] private SubtitleData subtitles;
    [SerializeField] private bool distanceAware;

    private void OnEnable() { }    
     
    
     

    private void Update() { }
    [Serializable]
    public class SubtitleData
    {
        public SubtitleDataLine[] lines;
    }

    [Serializable]
    public class SubtitleDataLine
    {
        public string subtitle;
        public float time;
    }
}
