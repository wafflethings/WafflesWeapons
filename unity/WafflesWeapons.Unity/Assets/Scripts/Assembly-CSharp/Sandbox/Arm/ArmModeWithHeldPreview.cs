using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Sandbox.Arm
{
	public abstract class ArmModeWithHeldPreview : ISandboxArmMode
	{
		[CompilerGenerated]
		private sealed class _003CHandClosedAnimationThing_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ArmModeWithHeldPreview _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CHandClosedAnimationThing_003Ed__14(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		protected static readonly int Holding;

		protected static readonly int Punch;

		protected SandboxArm hostArm;

		protected SpawnableObject currentObject;

		protected GameObject heldPreview;

		public virtual string Name => null;

		public virtual bool CanOpenMenu => false;

		public virtual bool Raycast => false;

		public virtual string Icon => null;

		public virtual void OnEnable(SandboxArm arm)
		{
		}

		[IteratorStateMachine(typeof(_003CHandClosedAnimationThing_003Ed__14))]
		protected IEnumerator HandClosedAnimationThing()
		{
			return null;
		}

		public virtual void SetPreview(SpawnableObject obj)
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual void Update()
		{
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void OnPrimaryDown()
		{
		}

		public virtual void OnPrimaryUp()
		{
		}

		public virtual void OnSecondaryDown()
		{
		}

		public virtual void OnSecondaryUp()
		{
		}
	}
}
