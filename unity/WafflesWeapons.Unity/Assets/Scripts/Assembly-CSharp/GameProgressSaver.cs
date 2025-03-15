public static class GameProgressSaver
{
	public enum WeaponCustomizationType
	{
		Revolver = 0,
		Shotgun = 1,
		Nailgun = 2,
		Railcannon = 3,
		RocketLauncher = 4
	}

	public static int currentSlot;

	private static int lastTotalSecrets;

	private static bool initialized;

	private static readonly string[] SlotIgnoreFiles;

	public static string BaseSavePath => null;

	public static string SavePath => null;

	private static string currentDifficultyPath => null;

	private static string customSavesDir => null;

	private static string customCampaignsDir => null;

	private static string generalProgressPath => null;

	private static string cyberGrindHighScorePath => null;

	private static string currentCustomLevelProgressPath => null;

	public static string customMapsPath => null;

	private static string resolveCurrentLevelPath => null;

	private static string DifficultySavePath(int diff)
	{
		return null;
	}

	private static string CustomLevelProgressPath(string uuid)
	{
		return null;
	}

	private static string LevelProgressPath(int lvl)
	{
		return null;
	}

	public static void SetSlot(int slot)
	{
	}

	public static void CreateSaveDirs(bool forceCustom = false)
	{
	}

	public static void WipeSlot(int slot)
	{
	}

	private static SaveSlotMenu.SlotData GetDirectorySlotData(string path)
	{
		return null;
	}

	public static SaveSlotMenu.SlotData[] GetSlots()
	{
		return null;
	}

	private static void PrepareFs()
	{
	}

	public static void MergeRootWithSlotOne(bool keepRoot)
	{
	}

	private static void SafeMove(string source, string target)
	{
	}

	private static object ReadFile(string path)
	{
		return null;
	}

	private static void WriteFile(string path, object data)
	{
	}

	private static RankData GetRankData(bool returnNull, int lvl = -1)
	{
		return null;
	}

	private static RankData GetRankData(int lvl = -1)
	{
		return null;
	}

	private static RankData GetRankData(out string path, int lvl = -1, bool returnNull = false)
	{
		path = null;
		return null;
	}

	public static RankData GetCustomRankData(string uuid)
	{
		return null;
	}

	private static GameProgressData GetGameProgress(int difficulty = -1)
	{
		return null;
	}

	private static GameProgressData GetGameProgress(out string path, int difficulty = -1)
	{
		path = null;
		return null;
	}

	public static void ChallengeComplete()
	{
	}

	public static void SaveProgress(int levelNum)
	{
	}

	public static void SaveRank()
	{
	}

	public static RankData GetRank(bool returnNull, int lvl = -1)
	{
		return null;
	}

	public static void SecretFound(int secretNum)
	{
	}

	public static int GetProgress(int difficulty)
	{
		return 0;
	}

	public static RankData GetRank(int levelNumber, bool returnNull = false)
	{
		return null;
	}

	public static void SetPrime(int level, int state)
	{
	}

	public static int GetPrime(int difficulty, int level)
	{
		return 0;
	}

	public static void SetEncoreProgress(int levelNum)
	{
	}

	public static int GetEncoreProgress(int difficulty)
	{
		return 0;
	}

	public static GameProgressMoneyAndGear GetGeneralProgress()
	{
		return null;
	}

	public static void AddGear(string gear)
	{
	}

	public static int CheckGear(string gear)
	{
		return 0;
	}

	public static void AddMoney(int money)
	{
	}

	public static void UnlockWeaponCustomization(WeaponCustomizationType weapon)
	{
	}

	public static bool HasWeaponCustomization(WeaponCustomizationType weapon)
	{
		return false;
	}

	public static int GetMoney()
	{
		return 0;
	}

	public static void SetTutorial(bool beat)
	{
	}

	public static bool GetTutorial()
	{
		return false;
	}

	public static void SetIntro(bool seen)
	{
	}

	public static bool GetIntro()
	{
		return false;
	}

	public static void SetClashModeUnlocked(bool unlocked)
	{
	}

	public static bool GetClashModeUnlocked()
	{
		return false;
	}

	public static void SetGhostDroneModeUnlocked(bool unlocked)
	{
	}

	public static bool GetGhostDroneModeUnlocked()
	{
		return false;
	}

	public static void SetUnlockable(UnlockableType unlockable, bool state)
	{
	}

	public static UnlockableType[] GetUnlockables()
	{
		return null;
	}

	public static void SetBestiary(EnemyType enemy, int state)
	{
	}

	public static int[] GetBestiary()
	{
		return null;
	}

	public static void SetLimboSwitch(int switchNum)
	{
	}

	public static bool GetLimboSwitch(int switchNum)
	{
		return false;
	}

	public static void SetShotgunSwitch(int switchNum)
	{
	}

	public static bool GetShotgunSwitch(int switchNum)
	{
		return false;
	}

	public static int GetSecretMission(int missionNumber)
	{
		return 0;
	}

	public static void FoundSecretMission(int missionNumber)
	{
	}

	public static void SetSecretMission(int missionNumber)
	{
	}

	public static int GetTotalSecretsFound()
	{
		return 0;
	}

	private static CyberRankData GetCyberRankData()
	{
		return null;
	}

	public static CyberRankData GetBestCyber()
	{
		return null;
	}

	public static void SetBestCyber(FinalCyberRank fcr)
	{
	}

	public static void ResetBestCyber()
	{
	}
}
