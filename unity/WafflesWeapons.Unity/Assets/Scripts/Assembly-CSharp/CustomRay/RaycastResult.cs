using System;
using UnityEngine;

namespace CustomRay
{
	public class RaycastResult : IComparable<RaycastResult>
	{
		public float distance;

		public Transform transform;

		public RaycastHit rrhit;

		public RaycastResult(RaycastHit hit)
		{
		}

		public int CompareTo(RaycastResult other)
		{
			return 0;
		}
	}
}
