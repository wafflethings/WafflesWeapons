using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox
{
	public class AlterMenuElements : MonoBehaviour
	{
		public enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		[SerializeField]
		private TooltipManager tooltipManager;

		[SerializeField]
		private Transform container;

		[Header("Templates")]
		[SerializeField]
		private GameObject titleTemplate;

		[SerializeField]
		private GameObject boolRowTemplate;

		[SerializeField]
		private GameObject floatRowTemplate;

		[SerializeField]
		private AlterMenuVector3Field vector3RowTemplate;

		[SerializeField]
		private GameObject dropdownRowTemplate;

		private readonly List<int> createdRows;

		private readonly Dictionary<int, Vector3> vector3ValueStore;

		public void CreateTitle(string name)
		{
		}

		public void CreateBoolRow(string name, bool initialState, Action<bool> callback, string tooltipMessage = null)
		{
		}

		public void CreateFloatRow(string name, float initialState, Action<float> callback, IConstraints constraints = null, string tooltipMessage = null)
		{
		}

		public void CreateVector3Row(string name, Vector3 initialState, Action<Vector3> callback, string tooltipMessage = null)
		{
		}

		public void UpdateVector3Value(int id, float value, Axis axis)
		{
		}

		public void CreateEnumRow(string name, int initialState, Action<int> callback, Type type, string tooltipMessage = null)
		{
		}

		public void Reset()
		{
		}

		private void CreateTooltip(GameObject row, string message)
		{
		}
	}
}
