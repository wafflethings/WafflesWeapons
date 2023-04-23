using UnityEngine;
using UnityEngine.Serialization;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerLoadout : MonoBehaviour, IPlaceholdableComponent
{
    [FormerlySerializedAs("forceLoadout")] public bool forceStartLoadout;
    public ForcedLoadout loadout;
    
    public void SetLoadout()
    {
        // Dummy Tundra Code
    }

    public void WillReplace(GameObject oldObject, GameObject newObject, bool isSelfBeingReplaced)
    {
        // Dummy Tundra Code
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerLoadout))]
public class PlayerLoadoutEditor : Editor
{
    private SerializedProperty forceLoadout;
    private SerializedProperty loadout;
    
    private void OnEnable()
    {
        forceLoadout = serializedObject.FindProperty(nameof(PlayerLoadout.forceStartLoadout));
        loadout = serializedObject.FindProperty(nameof(PlayerLoadout.loadout));
    }
    
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        if (((PlayerLoadout)target).TryGetComponent<FirstRoomPrefab>(out _))
        {
            EditorGUILayout.PropertyField(forceLoadout);
        }
        
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("All Default")) SetAll(VariantOption.IfEquipped);
        if (GUILayout.Button("All On")) SetAll(VariantOption.ForceOn);
        if (GUILayout.Button("All Off")) SetAll(VariantOption.ForceOff);
        GUILayout.EndHorizontal();
        EditorGUILayout.PropertyField(loadout);
        
        serializedObject.ApplyModifiedProperties();
    }

    private void SetAll(VariantOption option)
    {
        SetAll(loadout.FindPropertyRelative("revolver"), option);
        SetAll(loadout.FindPropertyRelative("altRevolver"), option);
        SetAll(loadout.FindPropertyRelative("shotgun"), option);
        SetAll(loadout.FindPropertyRelative("nailgun"), option);
        SetAll(loadout.FindPropertyRelative("altNailgun"), option);
        SetAll(loadout.FindPropertyRelative("railcannon"), option);
        SetAll(loadout.FindPropertyRelative("arm"), option);
    }
    
    private void SetAll(SerializedProperty parent, VariantOption option)
    {
        parent.FindPropertyRelative("blueVariant").enumValueIndex = (int)option;
        if (parent.FindPropertyRelative("greenVariant") != null) parent.FindPropertyRelative("greenVariant").enumValueIndex = (int)option;
        parent.FindPropertyRelative("redVariant").enumValueIndex = (int)option;
        if (parent.FindPropertyRelative("goldVariant") != null) parent.FindPropertyRelative("goldVariant").enumValueIndex = (int)option;
    }
}
#endif

[System.Serializable]
public class ForcedLoadout
{
    public VariantSetting revolver;
    public VariantSetting altRevolver;
    public VariantSetting shotgun;
    public VariantSetting nailgun;
    public VariantSetting altNailgun;
    public VariantSetting railcannon;
    [Space] public ArmVariantSetting arm;
}

[System.Serializable]
public class VariantSetting
{
    public VariantOption blueVariant;
    public VariantOption greenVariant;
    public VariantOption redVariant;
}

[System.Serializable]
public class ArmVariantSetting
{
    public VariantOption blueVariant;
    public VariantOption redVariant;
    public VariantOption greenVariant;
}

public enum VariantOption { IfEquipped = 0, ForceOn = 1, ForceOff = 2 }