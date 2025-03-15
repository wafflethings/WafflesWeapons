using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ULTRAKILL.Cheats
{
	public class Noclip : ICheat
	{
		[CompilerGenerated]
		private sealed class _003CCoroutine_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Noclip _003C_003E4__this;

			private Vector3 _003ClastDirection_003E5__2;

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
			public _003CCoroutine_003Ed__24(int _003C_003E1__state)
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

		private Rigidbody rb;

		private KeepInBounds kib;

		private VerticalClippingBlocker vcb;

		private Transform camera;

		public string LongName => null;

		public string Identifier => null;

		public string ButtonEnabledOverride => null;

		public string ButtonDisabledOverride => null;

		public string Icon => null;

		public bool DefaultState => false;

		public StatePersistenceMode PersistenceMode => default(StatePersistenceMode);

		public bool IsActive { get; private set; }

		public void Enable(CheatsManager manager)
		{
		}

		public void Disable()
		{
		}

		[IteratorStateMachine(typeof(_003CCoroutine_003Ed__24))]
		public IEnumerator Coroutine(CheatsManager manager)
		{
			return null;
		}

		private Vector3 UpdateTick()
		{
			return default(Vector3);
		}
	}
}
