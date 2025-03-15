using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class Arena : MonoBehaviour
{
    public Door[] doors;

    private void Awake()
    {
        var waves = GetWaves();
        AutoSetupWaves(waves);
        foreach (var activateNextWave in waves)
        {
            var enemies = GetEnemies(activateNextWave.transform);
            foreach (var enemy in enemies)
            {
                enemy.SetActive(false);
            }
        }
    }
    
    public ActivateNextWave[] GetWaves()
    {
        var waves = new List<ActivateNextWave>();
        foreach (Transform child in transform)
        {
            if (child.GetComponent<ActivateNextWave>()) waves.Add(child.GetComponent<ActivateNextWave>());
        }
        return waves.ToArray();
    }
    
    public static GameObject[] GetEnemies(Transform target)
    {
        var objs = new List<GameObject>();
        foreach (Transform o in target.transform)
        {
            objs.Add(o.gameObject);
        }

        return objs.ToArray();
    }
    
    public ActivateArena GetActivateArena()
    {
        return GetComponentInChildren<ActivateArena>();
    }
    
    private void ConfigureActivateArena(ActivateArena aa)
    {
        aa.doors = doors;
        var waves = GetWaves();
        if (waves.Length == 0) return;
        aa.enemies = Arena.GetEnemies(waves[0].transform);
    }

    private void ConfigureWaves(ActivateNextWave[] waves)
    {
        if (waves == null || waves.Length == 0) return;
        for (var index = 0; index < waves.Length; index++)
        {
            waves[index].CountEnemies();
            if (index < waves.Length - 1)
            {
                waves[index].nextEnemies = Arena.GetEnemies(waves[index + 1].transform);
            }
            waves[index].doors = new Door[] { };
            waves[index].lastWave = false;
        }

        waves[waves.Length - 1].doors = doors;
        waves[waves.Length - 1].lastWave = true;
    }

    public void AutoSetupWaves(ActivateNextWave[] waves)
    {
        ConfigureWaves(waves);
        ConfigureActivateArena(GetActivateArena());
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var properTargetDoor in doors)
        {
            Gizmos.color = new Color(1, 1, 0, 0.5f);
            Vector3? pointA = null;
            Vector3? pointB = null;

            var finalMax = Vector3.zero;
            var finalMin = Vector3.zero;

            GameObject realTarget;
            if (properTargetDoor.doorType == DoorType.Normal)
            {
                realTarget = properTargetDoor.transform.parent.gameObject;
            }
            else
            {
                realTarget = properTargetDoor.gameObject;
            }
            
            foreach (var componentsInChild in realTarget.GetComponentsInChildren<Renderer>())
            {
                var bounds = componentsInChild.bounds;

                var leastX = bounds.center.x - bounds.size.x;
                var mostX = bounds.center.x + bounds.size.x;
                var leastY = bounds.center.y - bounds.size.y;
                var mostY = bounds.center.y + bounds.size.y;
                var leastZ = bounds.center.z - bounds.size.z;
                var mostZ = bounds.center.z + bounds.size.z;

                if (pointA == null)
                {
                    finalMin = new Vector3(leastX, leastY, leastZ);
                    finalMax = new Vector3(mostX, mostY, mostZ);
                    pointB = new Vector3(finalMax.x - finalMin.x, finalMax.y - finalMin.y, finalMax.z - finalMin.z);
                    pointA = new Vector3(leastX + pointB.Value.x/2, leastY + pointB.Value.y/2, leastZ + pointB.Value.z/2);
                    
                }
                else
                {
                    if (leastX < finalMin.x) finalMin.x = leastX;
                    if (finalMax.x < mostX) finalMax.x = mostX;
                    if (leastY < finalMin.y) finalMin.y = leastY;
                    if (finalMax.y < mostY) finalMax.y = mostY;
                    if (leastZ < finalMin.z) finalMin.z = leastZ;
                    if (finalMax.z < mostZ) finalMax.z = mostZ;
                }
            }

            pointB = new Vector3(finalMax.x - finalMin.x, finalMax.y - finalMin.y, finalMax.z - finalMin.z);
            pointA = new Vector3(finalMin.x + pointB.Value.x/2, finalMin.y + pointB.Value.y/2, finalMin.z + pointB.Value.z/2);

            Gizmos.color = new Color(1, 1, 0, 1f);
            Gizmos.DrawWireCube(pointA.Value, pointB.Value * 0.75f);
            Gizmos.color = new Color(1, 1, 0, 0.15f);
            Gizmos.DrawCube(pointA.Value, pointB.Value * 0.75f);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Arena))]
public class ArenaEditor : Editor
{
    private SerializedProperty doors;
    private Arena properTarget;

    private void OnEnable()
    {
        properTarget = (Arena) target;
        doors = serializedObject.FindProperty("doors");
    }

    private bool HasGoreZone()
    {
        return properTarget.GetComponentInChildren<GoreZone>();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        if (!HasGoreZone())
        {
            if (GUILayout.Button("Setup GoreZone"))
            {
                Undo.RecordObject(properTarget.gameObject, "GoreZone");
                var gz = properTarget.gameObject.AddComponent<GoreZone>();
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            }
            GUILayout.Space(15);
        }

        if (!properTarget.GetActivateArena())
        {
            if (GUILayout.Button("Create Start Trigger"))
            {
                var startTrigger = new GameObject("Start Trigger");
                Undo.RecordObject(startTrigger, "Create Start Trigger Job");
                startTrigger.transform.parent = properTarget.transform;
                startTrigger.transform.SetAsFirstSibling();
                startTrigger.transform.localPosition = Vector3.zero;
                startTrigger.transform.localScale = Vector3.one * 5;
                startTrigger.layer = 16;
                var renderer = startTrigger.AddComponent<MeshRenderer>();
                var triggerMat = (Material)AssetDatabase.LoadAssetAtPath("Assets/Common/Materials/Dev/Trigger.mat", typeof(Material));
                if (triggerMat) renderer.material = triggerMat;
                var meshFilter = startTrigger.AddComponent<MeshFilter>();
                meshFilter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
                var col = startTrigger.AddComponent<BoxCollider>();
                col.isTrigger = true;
                var activateArena = startTrigger.AddComponent<ActivateArena>();
                Selection.activeObject = startTrigger;
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            }
            GUILayout.Space(15);
        }

        EditorGUILayout.PropertyField(doors);
        if (GUILayout.Button("Reload Enemies and Doors"))
        {
            properTarget.AutoSetupWaves(properTarget.GetWaves());
            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }
        GUILayout.Space(15);

        var waves = properTarget.GetWaves();
        foreach (var wave in waves)
        {
            GUILayout.BeginHorizontal();
            GUI.enabled = false;
            EditorGUILayout.ObjectField(wave.gameObject, typeof(GameObject), true);
            GUI.enabled = true;
            if (GUILayout.Button("Remove"))
            {
                Undo.RecordObject(wave.gameObject, "Remove Wave");
                DestroyImmediate(wave.gameObject);
                properTarget.AutoSetupWaves(properTarget.GetWaves());
                EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            }
            GUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add Wave"))
        {
            var newWaveObject = new GameObject($"Wave {waves.Length + 1}");
            Undo.RecordObject(newWaveObject, "New Wave");
            newWaveObject.transform.parent = properTarget.transform;
            newWaveObject.transform.localPosition = Vector3.zero;
            newWaveObject.transform.localScale = Vector3.one;
            properTarget.AutoSetupWaves(properTarget.GetWaves());

            EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif