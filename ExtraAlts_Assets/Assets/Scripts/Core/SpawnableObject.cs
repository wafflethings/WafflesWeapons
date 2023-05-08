#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ULTRAKILL/Spawnable Object")]
public class SpawnableObject : ScriptableObject
{
    public string identifier;
    public SpawnableObjectDataType spawnableObjectType;
    public UnlockableType unlockableType;
    
    public string objectName;
    public string type;
    [TextArea] public string description;
    [TextArea] public string strategy;
    public GameObject gameObject;
    public GameObject preview;
    
    public string iconKey;
    public Sprite gridIcon;
    
    public Color backgroundColor;
    public EnemyType enemyType;
    public SpawnableType spawnableType;
    public Vector3 armOffset = Vector3.zero;
    [FormerlySerializedAs("rotationOffset")] public Vector3 armRotationOffset = Vector3.zero;
    public Vector3 menuOffset = Vector3.zero;
    public float spawnOffset = 0;
    public bool isWater;
    
    public enum SpawnableObjectDataType { Object = 0, Enemy = 1, /*EnemyNoSpawn = 2,*/ Tool = 3, Unlockable = 4 }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SpawnableObject))]
[CanEditMultipleObjects]
public class SpawnableObjectEditor : Editor
{
    private SerializedProperty identifier;
    private SerializedProperty spawnableObjectType;
    private SerializedProperty unlockableType;
    
    private SerializedProperty objectName;
    private SerializedProperty type;
    
    private SerializedProperty description;
    private SerializedProperty strategy;
    
    private SerializedProperty gameObject;
    private SerializedProperty preview;

    private SerializedProperty iconKey;
    private SerializedProperty gridIcon;
    
    private SerializedProperty backgroundColor;

    private SerializedProperty enemyType;
    private SerializedProperty spawnableType;

    private SerializedProperty armOffset;
    private SerializedProperty armRotationOffset;
    private SerializedProperty menuOffset;
    private SerializedProperty spawnOffset;
    private SerializedProperty isWater;

    private void OnEnable()
    {
        identifier = serializedObject.FindProperty("identifier");
        spawnableObjectType = serializedObject.FindProperty("spawnableObjectType");
        unlockableType = serializedObject.FindProperty("unlockableType");
        
        objectName = serializedObject.FindProperty("objectName");
        type = serializedObject.FindProperty("type");
        
        description = serializedObject.FindProperty("description");
        strategy = serializedObject.FindProperty("strategy");
        
        gameObject = serializedObject.FindProperty("gameObject");
        preview = serializedObject.FindProperty("preview");
        
        iconKey = serializedObject.FindProperty("iconKey");
        gridIcon = serializedObject.FindProperty("gridIcon");

        backgroundColor = serializedObject.FindProperty("backgroundColor");
        
        enemyType = serializedObject.FindProperty("enemyType");
        spawnableType = serializedObject.FindProperty("spawnableType");
        
        armOffset = serializedObject.FindProperty("armOffset");
        armRotationOffset = serializedObject.FindProperty("armRotationOffset");
        menuOffset = serializedObject.FindProperty("menuOffset");
        spawnOffset = serializedObject.FindProperty("spawnOffset");
        isWater = serializedObject.FindProperty("isWater");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.LabelField("Type", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(spawnableObjectType);
        if (spawnableObjectType.intValue == (int)SpawnableObject.SpawnableObjectDataType.Unlockable) EditorGUILayout.PropertyField(unlockableType);
        EditorGUILayout.Space();

        if (spawnableObjectType.intValue == (int) SpawnableObject.SpawnableObjectDataType.Enemy)
        {
            EditorGUILayout.LabelField("Naming", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(objectName);
            EditorGUILayout.PropertyField(type);
            EditorGUILayout.Space();
                
            EditorGUILayout.LabelField("Details", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(description);
            EditorGUILayout.PropertyField(strategy);
            EditorGUILayout.PropertyField(enemyType);
            EditorGUILayout.Space();
                
            EditorGUILayout.LabelField("Enemy Info Menu", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(menuOffset);
            EditorGUILayout.Space();
        }
        
        if (spawnableObjectType.intValue != (int) SpawnableObject.SpawnableObjectDataType.Tool)
        {
            EditorGUILayout.LabelField("Identifier", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(identifier);
            EditorGUILayout.Space();
        }
        
        
        
        EditorGUILayout.LabelField("Icons", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Priority: Icon Key > Grid Icon Sprite > Generic Fallback", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(iconKey);
        EditorGUILayout.PropertyField(gridIcon);
        EditorGUILayout.Space();

        if (spawnableObjectType.intValue != (int) SpawnableObject.SpawnableObjectDataType.Tool)
        {
            EditorGUILayout.LabelField("Object", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(gameObject);
            EditorGUILayout.PropertyField(preview);
            EditorGUILayout.Space();
        }

        EditorGUILayout.LabelField("Spawning", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(spawnableType);
        EditorGUILayout.PropertyField(backgroundColor);
        if (spawnableObjectType.intValue != (int) SpawnableObject.SpawnableObjectDataType.Tool)
        {
            EditorGUILayout.PropertyField(armOffset);
            EditorGUILayout.PropertyField(armRotationOffset);
            EditorGUILayout.PropertyField(spawnOffset);
            EditorGUILayout.PropertyField(isWater);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif

public enum SpawnableType { SimpleSpawn, Prop, BuildHand, MoveHand, DestroyHand, AlterHand }