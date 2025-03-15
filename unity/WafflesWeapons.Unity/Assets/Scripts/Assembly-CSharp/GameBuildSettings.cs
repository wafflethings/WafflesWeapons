using System;

[Serializable]
public class GameBuildSettings
{
	public string startScene;

	public bool noTutorial;

	private static GameBuildSettings _instance;

	public static GameBuildSettings Default => null;

	public static GameBuildSettings Agony => null;

	public static GameBuildSettings SandboxOnly => null;

	public static GameBuildSettings GetInstance()
	{
		return null;
	}
}
