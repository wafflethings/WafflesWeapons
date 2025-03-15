using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class ThreadedParticleCollision : MonoBehaviour
{
	public ParticleSystem particles;

	public Bloodsplatter bloodsplatter;

	public NativeArray<RaycastCommand> raycasts;

	public NativeArray<RaycastHit> results;

	private CommandJob commandJob;

	private JobHandle handle;

	private List<Vector4> customData;

	private BloodsplatterManager bsm;

	private static Matrix4x4 identityMatrix;

	public event Action<NativeSlice<RaycastHit>> collisionEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Step(float dt)
	{
	}

	private void OnDestroy()
	{
	}
}
