
using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class AdditionalMapDetails : MonoSingleton<AdditionalMapDetails>
{
    public bool hasAuthorLinks;
    public AuthorLink[] authorLinks;
}

[Serializable]
public class AuthorLink
{
    public LinkPlatform platform;
    public string username;
    public string displayName;
    [Header("Optional")]
    public string description;
}

public enum LinkPlatform { YouTube, Twitter, Twitch, Steam, SoundCloud, Bandcamp, KoFi, Patreon, PayPalMe }

#if UNITY_EDITOR
[CustomEditor(typeof(AdditionalMapDetails))]
public class AdditionalMapDetailsEditor : Editor
{
    SerializedProperty hasAuthorLinks;
    SerializedProperty authorLinks;
    
    public void OnEnable()
    {
        hasAuthorLinks = serializedObject.FindProperty("hasAuthorLinks");
        authorLinks = serializedObject.FindProperty("authorLinks");
    }
    
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(hasAuthorLinks);

        if (hasAuthorLinks.boolValue)
        {
            EditorGUILayout.LabelField("Links will be shown at the end of the level.");
            EditorGUILayout.PropertyField(authorLinks);
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}
#endif