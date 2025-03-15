using UnityEngine;

public static class LayerMaskDefaults
{
	public static bool IsMatchingLayer(int otherLayer, LMD layerMask)
	{
		return false;
	}

	public static LayerMask Get(LMD lmd)
	{
		return default(LayerMask);
	}
}
