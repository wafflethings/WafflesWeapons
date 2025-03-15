using System;

[Serializable]
public struct UnscaledTimeSince
{
	private float time;

	public const int Now = 0;

	public static implicit operator float(UnscaledTimeSince ts)
	{
		return 0f;
	}

	public static implicit operator UnscaledTimeSince(float ts)
	{
		return default(UnscaledTimeSince);
	}
}
