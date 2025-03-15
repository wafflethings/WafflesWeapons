using System;

[Serializable]
public struct TimeSince
{
	private float time;

	public const int Now = 0;

	public static implicit operator float(TimeSince ts)
	{
		return 0f;
	}

	public static implicit operator TimeSince(float ts)
	{
		return default(TimeSince);
	}

	public new string ToString()
	{
		return null;
	}
}
