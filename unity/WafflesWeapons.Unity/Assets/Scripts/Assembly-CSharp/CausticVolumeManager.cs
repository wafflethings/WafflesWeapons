using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class CausticVolumeManager : MonoSingleton<CausticVolumeManager>
{
	private struct CausticData
	{
		public Vector4 position_nearRadius;

		public Vector4 color_farRadius;
	}

	private List<CausticVolume> causticVolumes;

	private List<ObjectBoundsToShader> objects;

	private List<CausticData> causticDataArray;

	private ComputeBuffer causticVolumeBuffer;

	public bool isDirty;

	private void OnValidate()
	{
	}

	private new void OnDestroy()
	{
	}

	public void AddObject(ObjectBoundsToShader rendObj)
	{
	}

	public void RemoveObject(ObjectBoundsToShader rendObj)
	{
	}

	public void AddVolume(CausticVolume volume)
	{
	}

	public void RemoveVolume(CausticVolume volume)
	{
	}

	private void LateUpdate()
	{
	}

	private void UpdateCausticData()
	{
	}
}
