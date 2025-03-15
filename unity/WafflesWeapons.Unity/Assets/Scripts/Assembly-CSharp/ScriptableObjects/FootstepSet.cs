using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
	[CreateAssetMenu(fileName = "Footstep Set", menuName = "ULTRAKILL/FootstepSet")]
	public class FootstepSet : ScriptableObject
	{
		[Serializable]
		public class Footsteps
		{
			[field: SerializeField]
			public SurfaceType SurfaceType { get; private set; }

			[field: SerializeField]
			public AudioClip[] Clips { get; private set; }
		}

		[Serializable]
		public class EnviroGibs
		{
			[field: SerializeField]
			public SurfaceType SurfaceType { get; private set; }

			[field: SerializeField]
			public GameObject[] gibs { get; private set; }
		}

		[Serializable]
		public class EnviroGibParticles
		{
			[field: SerializeField]
			public SurfaceType SurfaceType { get; private set; }

			[field: SerializeField]
			public GameObject particle { get; private set; }
		}

		[Serializable]
		public class SlideParticles
		{
			[field: SerializeField]
			public SurfaceType SurfaceType { get; private set; }

			[field: SerializeField]
			public GameObject particle { get; private set; }
		}

		[Serializable]
		public class WallScrapeParticles
		{
			[field: SerializeField]
			public SurfaceType SurfaceType { get; private set; }

			[field: SerializeField]
			public GameObject particle { get; private set; }
		}

		[SerializeField]
		private Footsteps[] footsteps;

		[SerializeField]
		private EnviroGibs[] enviroGibs;

		[SerializeField]
		private EnviroGibParticles[] enviroGibParticles;

		[SerializeField]
		private SlideParticles[] slideParticles;

		[SerializeField]
		private WallScrapeParticles[] wallScrapeParticles;

		[NonSerialized]
		private Dictionary<SurfaceType, AudioClip[]> footstepsDictionary;

		[NonSerialized]
		private Dictionary<SurfaceType, GameObject[]> enviroGibsDictionary;

		[NonSerialized]
		private Dictionary<SurfaceType, GameObject> enviroGibParticleDictionary;

		[NonSerialized]
		private Dictionary<SurfaceType, GameObject> slideParticlesDictionary;

		[NonSerialized]
		private Dictionary<SurfaceType, GameObject> wallScrapeParticlesDictionary;

		[NonSerialized]
		private bool initialized;

		public bool TryGetFootstepClips(SurfaceType surfaceType, out AudioClip[] clips)
		{
			clips = null;
			return false;
		}

		public bool TryGetEnviroGibs(SurfaceType surfaceType, out GameObject[] enviroGibs)
		{
			enviroGibs = null;
			return false;
		}

		public bool TryGetEnviroGibParticle(SurfaceType surface, out GameObject particle)
		{
			particle = null;
			return false;
		}

		public bool TryGetSlideParticle(SurfaceType surface, out GameObject particle)
		{
			particle = null;
			return false;
		}

		public bool TryGetWallScrapeParticle(SurfaceType surface, out GameObject particle)
		{
			particle = null;
			return false;
		}

		private void Initialize()
		{
		}
	}
}
