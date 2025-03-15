using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

[BurstCompile]
internal struct CommandJob : IJobParticleSystemParallelFor
{
	public float4x4 transform;

	public NativeArray<RaycastCommand> raycasts;

	[ReadOnly]
	public NativeArray<RaycastHit> lastFrameHits;

	public QueryParameters parameters;

	public float deltaTime;

	public bool worldSpace;

	public Vector3 center;

	public void Execute(ParticleSystemJobData jobData, int i)
	{
	}
}
