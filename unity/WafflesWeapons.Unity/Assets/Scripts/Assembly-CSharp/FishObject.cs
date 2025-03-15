using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Fish", menuName = "ULTRAKILL/Fish")]
public class FishObject : ScriptableObject
{
	public string fishName;

	public GameObject worldObject;

	[FormerlySerializedAs("pickup")]
	public ItemIdentifier customPickup;

	public Sprite icon;

	public Sprite blockedIcon;

	public bool canBeCooked;

	[TextArea]
	public string description;

	public float previewSizeMulti;

	public GameObject InstantiateWorld(Vector3 position = default(Vector3))
	{
		return null;
	}

	public GameObject InstantiateDumb()
	{
		return null;
	}
}
