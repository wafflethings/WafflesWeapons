using System;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
	private readonly struct StuckObject
	{
		public readonly Rigidbody rigidbody;

		private readonly float _maxAngularVelocity;

		private readonly RigidbodyInterpolation _interpolation;

		public void UndoPropertyModifications()
		{
		}

		public StuckObject(Rigidbody instance)
		{
			rigidbody = null;
			_maxAngularVelocity = 0f;
			_interpolation = default(RigidbodyInterpolation);
		}
	}

	[SerializeField]
	private float _suckStrength;

	[SerializeField]
	private float _stuckDistance;

	[SerializeField]
	private Transform _suckPoint;

	[SerializeField]
	private BoxCollider _suckBox;

	[SerializeField]
	private AudioSource _consumeSound;

	[SerializeField]
	private AudioSource _suckSound;

	[SerializeField]
	private ParticleSystem _suckSystem;

	[SerializeField]
	private ParticleSystem _blowSystem;

	private ArraySegment<Collider> _colliders;

	private bool _isSucking;

	private bool _isBlowing;

	private StuckObject _stuckObject;

	private Vector3 _lastCameraRotation;

	private bool musicStarted;

	[SerializeField]
	private GameObject music;

	[Header("Sound Effects")]
	[SerializeField]
	private AudioClip suckStartSound;

	[SerializeField]
	private AudioClip suckLoopSound;

	[SerializeField]
	private AudioClip suckStopSound;

	[SerializeField]
	private AudioClip suckStuckSound;

	[SerializeField]
	private AudioClip suckStuckLoopSound;

	[SerializeField]
	private AudioClip blowStartSound;

	[SerializeField]
	private AudioClip blowLoopSound;

	[SerializeField]
	private AudioClip blowStopSound;

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void UpdateInput()
	{
	}

	private void UpdateStuckObject()
	{
	}

	private void UpdateColliders()
	{
	}

	private void SuckObjects()
	{
	}

	private void StopCorkPull()
	{
	}

	private void StartVacuuming()
	{
	}

	private void StopVacuuming()
	{
	}

	private void StartBlowing()
	{
	}

	private void StopBlowing()
	{
	}

	private void SetStuckObject(Rigidbody rigidbody)
	{
	}
}
