using System;

[Serializable]
public class SandboxSaveData
{
	public string MapName;

	public string MapIdentifier;

	public int SaveVersion;

	public string GameVersion;

	public SavedBlock[] Blocks;

	public SavedProp[] Props;

	public SavedEnemy[] Enemies;
}
