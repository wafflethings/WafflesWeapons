using System;
using UnityEngine;

namespace Train
{
	[Serializable]
	public class TrackCurveSettings
	{
		[HideInInspector]
		public PathInterpolation curve;

		[HideInInspector]
		public Transform handle;

		[HideInInspector]
		[Range(1f, 90f)]
		public float angle;

		[HideInInspector]
		public bool flipCurve;
	}
}
