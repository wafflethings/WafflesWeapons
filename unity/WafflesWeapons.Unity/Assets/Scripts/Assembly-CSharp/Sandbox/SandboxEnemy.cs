using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using plog;

namespace Sandbox
{
	public class SandboxEnemy : SandboxSpawnableInstance
	{
		[CompilerGenerated]
		private sealed class _003CGetEnemyComponents_003Ed__14 : IEnumerable<Component>, IEnumerable, IEnumerator<Component>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Component _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public SandboxEnemy _003C_003E4__this;

			private GameObject obj;

			public GameObject _003C_003E3__obj;

			private HashSet<Type>.Enumerator _003C_003E7__wrap1;

			private Component[] _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			Component IEnumerator<Component>.Current
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
			public _003CGetEnemyComponents_003Ed__14(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Component> IEnumerable<Component>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private static readonly plog.Logger Log;

		public EnemyIdentifier enemyId;

		public EnemyRadianceConfig radiance;

		private bool lastSpeedBuffState;

		private bool lastDamageBuffState;

		private bool lastHealthBuffState;

		private bool lastKinematicState;

		public override void Awake()
		{
		}

		public void RestoreRadiance(EnemyRadianceConfig config)
		{
		}

		public void UpdateRadiance()
		{
		}

		private void OnEnable()
		{
		}

		public SavedEnemy SaveEnemy()
		{
			return null;
		}

		public override void Pause(bool freeze = true)
		{
		}

		public override void Resume()
		{
		}

		[IteratorStateMachine(typeof(_003CGetEnemyComponents_003Ed__14))]
		private IEnumerable<Component> GetEnemyComponents(GameObject obj)
		{
			return null;
		}

		private void Update()
		{
		}
	}
}
