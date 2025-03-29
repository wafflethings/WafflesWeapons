using System.IO;
using System.Reflection;
using AtlasLib.Weapons;
using UnityEditor;
using UnityEngine;

public class CreateAssets
{
    public static bool TryGetActiveFolderPath(out string path)
    {
        MethodInfo tryGetActiveFolderPath = typeof(ProjectWindowUtil).GetMethod("TryGetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);

        object[] args = { null };
        bool found = (bool)tryGetActiveFolderPath.Invoke(null, args);
        path = (string)args[0];

        return found;
    }

    [MenuItem("Assets/Create/Atlas/Weapon Info")]
    public static void CreateWeaponInfo()
    {
        if (TryGetActiveFolderPath(out string path))
        {
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WeaponInfo>(), Path.Combine(path, "New Weapon Info.asset"));
        }
    }
    
    [MenuItem("Assets/Create/Atlas/Ts")]
    public static void CreateTs()
    {
        if (TryGetActiveFolderPath(out string path))
        {
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<Ts>(), Path.Combine(path, "New Ts.asset"));
        }
    }
}