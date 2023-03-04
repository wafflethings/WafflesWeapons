using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomTextures : MonoBehaviour
{
    [SerializeField] private GameObject textureButtonTemplate;
    [SerializeField] private GameObject folderIconTemplate;
    [SerializeField] private GameObject backButton;
    [SerializeField] private Transform texturesGrid;
    [SerializeField] private Material[] gridMaterials;
    [SerializeField] private OutdoorLightMaster olm;
    [SerializeField] private Material skyMaterial;
    [SerializeField] private Texture defaultGlow;
    [SerializeField] private Text pageText;
    [SerializeField] private Texture[] defaultGridTextures;
    [SerializeField] private Texture defaultEmission;
    [SerializeField] private Texture[] defaultSkyboxes;

    [SerializeField] private GameObject gridWrapper;
    [SerializeField] private Image gridBtnFrame;
    [SerializeField] private Image skyboxBtnFrame;
    [SerializeField] private Image emissionBtnFrame;
    private string TexturesPath => Path.Combine(Directory.GetParent(Application.dataPath).FullName, "CyberGrind", "Textures");
    [SerializeField] private Image baseBtnFrame;
    [SerializeField] private Image topBtnFrame;
    [SerializeField] private Image topRowBtnFrame;

    [SerializeField] private Slider glowSlider;

    public void SetEditMode(int m)
{}
    public void SetGridEditMode(int num)
{}
    public void NextPage()
{}
    public void PreviousPage()
{}
    public void OpenDirectory(string dir)
{}
    public void GoUpTheHierarchy()
{}
    public void SetTexture(string key)
{}
    public void SetGlowIntensity()
{}
    public void BuildButtons()
{}
    public void RemoveCustomPrefs()
{}
    public void ResetTexture()
{}
    enum EditMode { None = 0, Grid = 1, Skybox = 2, Emission = 3 }
}
