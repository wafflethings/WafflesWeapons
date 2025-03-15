using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.PersistAutoInstance)]
public class RumbleManager : MonoSingleton<RumbleManager>
{
	public readonly Dictionary<RumbleKey, PendingVibration> pendingVibrations;

	private List<RumbleKey> discardedKeys;

	private static readonly Dictionary<RumbleKey, float> rumbleDurations;

	public static readonly Dictionary<RumbleKey, float> rumbleIntensities;

	public static readonly Dictionary<RumbleKey, string> fullNames;

	public float currentIntensity { get; private set; }

	public PendingVibration SetVibration(RumbleKey key)
	{
		return null;
	}

	public PendingVibration SetVibrationTracked(RumbleKey key, GameObject tracked)
	{
		return null;
	}

	public void StopVibration(RumbleKey key)
	{
	}

	public void StopAllVibrations()
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}

	public float ResolveDuration(RumbleKey key)
	{
		return 0f;
	}

	public float ResolveDefaultDuration(RumbleKey key)
	{
		return 0f;
	}

	public float ResolveIntensity(RumbleKey key)
	{
		return 0f;
	}

	public float ResolveDefaultIntensity(RumbleKey key)
	{
		return 0f;
	}

	public static string ResolveFullName(RumbleKey key)
	{
		return null;
	}
}
