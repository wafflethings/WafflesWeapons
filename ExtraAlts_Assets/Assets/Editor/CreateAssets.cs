using System.IO;
using System.Reflection;
using AtlasLib.Weapons;
using UnityEditor;
using UnityEngine;
using WafflesWeapons.Assets;

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
    
    [MenuItem("Assets/Create/Waffle's Weapons/Weapon Assets")]
    public static void CreateWeaponAssets()
    {
        if (TryGetActiveFolderPath(out string path))
        {
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WeaponAssets>(), Path.Combine(path, "New Weapon Assets.asset"));
        }
    }
}
