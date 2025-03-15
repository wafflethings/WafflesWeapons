using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NewBlood.Interop
{
	public struct PPtr<T> : IEquatable<PPtr<T>>, IComparable<PPtr<T>>, IComparable where T : UnityEngine.Object
	{
		private int m_InstanceID;

		private static readonly string s_TypeString;

		public readonly bool IsValid => false;

		public PPtr(T o)
		{
			m_InstanceID = 0;
		}

		public PPtr(int instanceID)
		{
			m_InstanceID = 0;
		}

		public void SetInstanceID(int instanceID)
		{
		}

		public readonly int GetInstanceID()
		{
			return 0;
		}

		public readonly T ForceLoadPtr()
		{
			return null;
		}

		public override readonly bool Equals(object obj)
		{
			return false;
		}

		public readonly bool Equals(PPtr<T> other)
		{
			return false;
		}

		public readonly int CompareTo(object obj)
		{
			return 0;
		}

		public readonly int CompareTo(PPtr<T> other)
		{
			return 0;
		}

		public override readonly int GetHashCode()
		{
			return 0;
		}

		public override readonly string ToString()
		{
			return null;
		}

		public static implicit operator T(PPtr<T> p)
		{
			return null;
		}

		public static bool operator ==(PPtr<T> p1, PPtr<T> p2)
		{
			return false;
		}

		public static bool operator !=(PPtr<T> p1, PPtr<T> p2)
		{
			return false;
		}

		public static bool operator <(PPtr<T> p1, PPtr<T> p2)
		{
			return false;
		}

		public static bool operator >(PPtr<T> p1, PPtr<T> p2)
		{
			return false;
		}

		public static bool operator <=(PPtr<T> p1, PPtr<T> p2)
		{
			return false;
		}

		public static bool operator >=(PPtr<T> p1, PPtr<T> p2)
		{
			return false;
		}
	}
}
