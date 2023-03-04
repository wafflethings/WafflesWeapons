using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CustomPatterns : MonoBehaviour
{
    
    private string PatternsPath => Path.Combine(Directory.GetParent(Application.dataPath).FullName, "CyberGrind", "Patterns");
    
    [SerializeField] private AnimationCurve colorCurve;
    [SerializeField] private Texture2D parsingErrorTexture;
    [SerializeField] private GameObject buttonTemplate;
    [SerializeField] private GameObject packButtonTemplate;
    [SerializeField] private Transform grid;
    [SerializeField] private Text stateButtonText;
    [SerializeField] private Text pageText;

    public GameObject enableWhenCustom;

    public void Toggle()
{}
    public void SaveEnabledPatterns()
{}
    public void LoadEnabledPatterns()
{}
    public void BuildButtons()
{}    
    public void NextPage()
{}
    public void PreviousPage()
{}
    public void OpenEditor()
{}}
