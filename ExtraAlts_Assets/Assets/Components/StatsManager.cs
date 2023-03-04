using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class StatsManager : MonoSingleton<StatsManager> {
    public GameObject debugCheckPoint;
    public int levelNumber;
    public bool timer;

    public int[] timeRanks;
    public int[] killRanks;
    public int[] styleRanks;

    public GameObject[] secretObjects;
    public AudioClip[] rankSounds;

    public void GetCheckPoint(Vector3 position) {}
    public void Restart() {}
    public void StartTimer() {}
    public void StopTimer() {}
    public void HideShit() {}
    public void SendInfo() {}
    public void MajorUsed() {}
    public void SecretFound(GameObject gob) {}
}
