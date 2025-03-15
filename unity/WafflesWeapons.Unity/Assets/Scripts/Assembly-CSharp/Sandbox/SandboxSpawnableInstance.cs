using System;
using System.Collections.Generic;
using UnityEngine;
using plog;

namespace Sandbox
{
	public class SandboxSpawnableInstance : MonoBehaviour
	{
		private static readonly plog.Logger Log;

		public SpawnableObject sourceObject;

		public GameObject attachedParticles;

		public Collider collider;

		[NonSerialized]
		public bool alwaysFrozen;

		[NonSerialized]
		public Rigidbody rigidbody;

		public bool frozen;

		public bool disallowManipulation;

		public bool disallowFreezing;

		public bool uniformSize => false;

		public Vector3 defaultSize { get; private set; }

		public Vector3 normalizedSize => default(Vector3);

		public virtual void Awake()
		{
		}

		public virtual void SetSize(Vector3 size)
		{
		}

		public void SetSizeUniform(float size)
		{
		}

		public void BaseSave(ref SavedGeneric saveObject)
		{
		}

		public virtual void Pause(bool freeze = true)
		{
		}

		public virtual void Resume()
		{
		}

		public void ApplyAlterOptions(IEnumerable<AlterOption> requestedOptions)
		{
		}
	}
}
