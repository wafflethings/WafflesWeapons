using UnityEngine;

namespace Logic
{
	public abstract class MapVarSetter : MonoBehaviour
	{
		public string variableName;

		public VariablePersistence persistence;

		public bool setOnEnable;

		public bool setEveryFrame;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		public virtual void SetVar()
		{
		}
	}
}
