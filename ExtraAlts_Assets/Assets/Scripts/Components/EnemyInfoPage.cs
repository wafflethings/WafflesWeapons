using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoPage : ListComponent<EnemyInfoPage>
{
    [SerializeField] private Text enemyPageTitle;
    [SerializeField] private Text enemyPageContent;
    [SerializeField] private Transform enemyPreviewWrapper;
    [Space] [SerializeField] private Transform enemyList;
    [SerializeField] private GameObject buttonTemplate;
    [SerializeField] private Image buttonTemplateBackground;
    [SerializeField] private Image buttonTemplateForeground;
    [SerializeField] private Sprite lockedSprite;
    [Space]
    
     
     
    [SerializeField] private SpawnableObjectsDatabase objects;

    private void Start() { }
    public void UpdateInfo() { }
    void SwapLayers(Transform target, int layer) { }
    public void DisplayInfo() { }
    public void UndisplayInfo() { }}
