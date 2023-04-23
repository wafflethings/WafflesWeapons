using System;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "New Fish Database", menuName = "ULTRAKILL/FishDB")]
public class FishDB : ScriptableObject
{
    public string fullName;
    public Color symbolColor = Color.white;
    public GameObject fishGhostPrefab;
    public FishDescriptor[] foundFishes;

    public void SetupWater(Water water) { }}

[Serializable]
public class FishDescriptor
{
    public FishObject fish;
    public int chance = 1;
    
}

#if UNITY_EDITOR
[CustomEditor(typeof(FishDB))]
public class FishDBEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var db = (FishDB) target;
        GUILayout.Label("Fish Pool Preview:");
        if (db.foundFishes == null) return;
        GUILayout.BeginHorizontal();
        for (var i = 0; i < db.foundFishes.Length; i++)
        {
            var fish = db.foundFishes[i];
            GUI.color = i % 2 == 0 ? Color.white : Color.gray;
            for (var j = 0; j < fish.chance; j++)
            {
                GUILayout.Button(i.ToString());
            }
        }

        GUILayout.EndHorizontal();
    }
}
#endif