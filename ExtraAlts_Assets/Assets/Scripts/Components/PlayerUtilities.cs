using Logic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerUtilities : MonoBehaviour
{
    public bool enableOutput;
    public string distanceTraveledMapVar;
    public string currentHealthVar;
    public string currentHardDamageVar;
    public string currentStyleScoreVar;
    public string currentTimeVar;
    public string currentKillCountVar;
    public string currentRankVar;

    public void Update() { }
    public void DisablePlayer() { }    
    public void EnablePlayer() { }
    public void FreezePlayer() { }
    public void UnfreezePlayer() { }
    public void FadeOutFallingWhoosh() { }
    public void FadeOutFallingWhooshCustomSpeed(float speed) { }
    public void RestoreFallingWhoosh() { }
    public void YesWeapon() { }    
    public void NoWeapon() { }    
    public void YesFist() { }    
    public void NoFist() { }    
    public void HealPlayer(int health) { }    
    public void HealPlayerSilent(int health) { }
    public void EmptyStamina() { }    
    public void FullStamina() { }
    public void ResetHardDamage() { }
    public void MaxCharges() { }
    public void DestroyHeldObject() { }
    public void PlaceHeldObject(ItemPlaceZone target) { }    
    public void ForceHoldObject(ItemIdentifier pickup) { }
    public void ParryFlash() { }
    public void QuitMap() { }
    public void FinishMap() { }    
    public void SetGravity(float gravity) { }    
    public void SetGravity(Vector3 gravity) { }    
    public void SetPlayerHealth(int health) { }    
    public void SetPlayerHardDamage(float damage) { }    
    public void SetPlayerStamina(float boostCharge) { }}

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerUtilities))]
public class PlayerUtilitiesEditor : Editor
{
    private SerializedProperty enableOutput;
    private SerializedProperty distanceTraveledMapVar;
    private SerializedProperty currentHealthVar;
    private SerializedProperty currentHardDamageVar;
    private SerializedProperty currentStyleScoreVar;
    private SerializedProperty currentTimeVar;
    private SerializedProperty currentKillCountVar;
    private SerializedProperty currentRankVar;
    
    private void OnEnable()
    {
        enableOutput = serializedObject.FindProperty("enableOutput");
        distanceTraveledMapVar = serializedObject.FindProperty("distanceTraveledMapVar");
        currentHealthVar = serializedObject.FindProperty("currentHealthVar");
        currentHardDamageVar = serializedObject.FindProperty("currentHardDamageVar");
        currentStyleScoreVar = serializedObject.FindProperty("currentStyleScoreVar");
        currentTimeVar = serializedObject.FindProperty("currentTimeVar");
        currentKillCountVar = serializedObject.FindProperty("currentKillCountVar");
        currentRankVar = serializedObject.FindProperty("currentRankVar");
    }
    
    public override void OnInspectorGUI()
    {
        GUILayout.Label("Player Utilities", EditorStyles.boldLabel);
        EditorStyles.label.wordWrap = true;
        GUILayout.Label("Note: You can call methods on this component from\nObjectActivator's events or ControllerPointer OnPressed events");
        GUILayout.Space(24);
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(enableOutput);
        if (enableOutput.boolValue)
        {
            EditorGUILayout.PropertyField(distanceTraveledMapVar);
            EditorGUILayout.LabelField("(Float)", EditorStyles.miniLabel);
            EditorGUILayout.Space(12);
            EditorGUILayout.PropertyField(currentHealthVar);
            EditorGUILayout.LabelField("(Int)", EditorStyles.miniLabel);
            EditorGUILayout.Space(12);
            EditorGUILayout.PropertyField(currentHardDamageVar);
            EditorGUILayout.LabelField("(Float)", EditorStyles.miniLabel);
            EditorGUILayout.Space(12);
            EditorGUILayout.PropertyField(currentStyleScoreVar);
            EditorGUILayout.LabelField("(Int)", EditorStyles.miniLabel);
            EditorGUILayout.Space(12);
            EditorGUILayout.PropertyField(currentTimeVar);
            EditorGUILayout.LabelField("(Float)", EditorStyles.miniLabel);
            EditorGUILayout.Space(12);
            EditorGUILayout.PropertyField(currentKillCountVar);
            EditorGUILayout.LabelField("(Int)", EditorStyles.miniLabel);
            EditorGUILayout.Space(12);
            EditorGUILayout.PropertyField(currentRankVar);
            EditorGUILayout.LabelField("(Float)", EditorStyles.miniLabel);
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif