using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ULTRAKILL.Cheats
{
	public class HideWeapons : ICheat
	{
		[CompilerGenerated]
		private sealed class _003CCoroutine_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HideWeapons _003C_003E4__this;

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
			public _003CCoroutine_003Ed__31(int _003C_003E1__state)
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

		private bool gunControlChanged;

		public static bool Active => false;

		private static HideWeapons Instance { get; set; }

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride { get; }

		public string ButtonDisabledOverride { get; }

		public string Icon { get; }

		public bool IsActive { get; private set; }

		public bool DefaultState => false;

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public void Enable(CheatsManager manager)
		{
		}

		public void Disable()
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CCoroutine_003Ed__31))]
		public IEnumerator Coroutine(CheatsManager manager)
		{
			return null;
		}
	}
}
