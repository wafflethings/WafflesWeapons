using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ULTRAKILL.Cheats
{
	public class InvincibleEnemies : ICheat
	{
		[CompilerGenerated]
		private sealed class _003CCoroutine_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InvincibleEnemies _003C_003E4__this;

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
			public _003CCoroutine_003Ed__26(int _003C_003E1__state)
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

		private static InvincibleEnemies _lastInstance;

		public static bool Enabled => false;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride { get; }

		public string ButtonDisabledOverride { get; }

		public string Icon => null;

		public bool IsActive { get; private set; }

		public bool DefaultState { get; }

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public void Enable(CheatsManager manager)
		{
		}

		public void Disable()
		{
		}

		[IteratorStateMachine(typeof(_003CCoroutine_003Ed__26))]
		public IEnumerator Coroutine(CheatsManager manager)
		{
			return null;
		}

		private void Update()
		{
		}
	}
}
