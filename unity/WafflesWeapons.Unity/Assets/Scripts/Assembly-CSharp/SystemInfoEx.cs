using UnityEngine;

public static class SystemInfoEx
{
	public static bool supportsComputeShaders { get; private set; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void Initialize()
	{
	}
}
