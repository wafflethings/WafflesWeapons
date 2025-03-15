using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ULTRAKILL/Soundtrack Song Data")]
public class SoundtrackSong : ScriptableObject
{
	[Space]
	public Sprite icon;

	public string songName;

	public string levelName;

	[Header("Clips")]
	public AudioClip introClip;

	public List<AudioClip> clips;

	public int maxClipsIfNotRepeating;

	[SerializeReference]
	[PolymorphicField(typeof(UnlockCondition))]
	public List<UnlockCondition> conditions;

	public string extraLevelBit => null;
}
