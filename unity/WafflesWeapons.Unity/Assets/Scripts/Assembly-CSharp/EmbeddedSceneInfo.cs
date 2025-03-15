using UnityEngine;

[CreateAssetMenu]
public class EmbeddedSceneInfo : ScriptableObject
{
	[Tooltip("Special scenes cannot be normally loaded by the console.")]
	public string[] specialScenes;

	public string[] ranklessScenes;

	public IntermissionRelation[] intermissions;
}
