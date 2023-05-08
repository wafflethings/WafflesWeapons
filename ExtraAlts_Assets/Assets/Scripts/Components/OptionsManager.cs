using System.Linq;
using Logic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class OptionsManager : MonoSingleton<OptionsManager>
{

    public bool mainMenu;
    public bool inIntro;

    public bool frozen;
    
    public bool previousWeaponState;

     
    protected override void Awake() { }
    void Start() { }
     
    void Update() { }
    public void Pause() { }
    public void UnPause() { }
    public void Freeze() { }
    public void UnFreeze() { }
    public void RestartCheckpoint() { }
    public void RestartMission() { }
    public void OpenOptions() { }
    public void CloseOptions() { }
    public void QuitMission() { }
    public void QuitGame() { }
    public void ChangeLevel(string levelname) { }
    public void ChangeLevelAbrupt(string scene) { }
    public void ChangeLevelWithPosition(string levelname) { }
    public void SetChangeLevelPosition(bool noPosition) { }}
