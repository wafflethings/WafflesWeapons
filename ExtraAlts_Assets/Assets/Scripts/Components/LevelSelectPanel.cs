using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelSelectPanel : MonoBehaviour
{
    public int levelNumber;
    public int levelNumberInLayer;

    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    public Image[] secretIcons;
    public Image challengeIcon;

    public bool forceOff;

    private void OnEnable() { }
    private void OnDisable() { }
    public void CheckScore() { }}
