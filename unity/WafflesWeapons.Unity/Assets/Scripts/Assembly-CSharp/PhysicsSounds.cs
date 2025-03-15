using System;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class PhysicsSounds : MonoSingleton<PhysicsSounds>
{
	[Serializable]
	public struct PhysSounds
	{
		public AudioClip plastic;

		public AudioClip wood;

		public AudioClip stone;

		public AudioClip metal;

		public AudioClip fleshy;

		public AudioClip glass;

		public AudioClip grass;
	}

	public enum PhysMaterial
	{
		Plastic = 0,
		Wood = 1,
		Stone = 2,
		Metal = 3,
		Fleshy = 4,
		Glass = 5,
		Grass = 6
	}

	[SerializeField]
	private PhysSounds sounds;

	[SerializeField]
	private AudioSource template;

	public AudioClip ResolveSound(PhysMaterial material)
	{
		return null;
	}

	public void ImpactAt(Vector3 point, float magnitude, PhysMaterial material)
	{
	}
}
