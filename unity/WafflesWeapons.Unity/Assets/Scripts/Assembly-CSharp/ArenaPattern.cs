using UnityEngine;

[CreateAssetMenu(menuName = "ULTRAKILL/Arena Pattern")]
public class ArenaPattern : ScriptableObject
{
	[TextArea(16, 16)]
	public string heights;

	[TextArea(16, 16)]
	public string prefabs;
}
