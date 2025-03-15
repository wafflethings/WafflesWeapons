using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
	public class MapVarStringBuilder : MonoBehaviour
	{
		[Header("Input")]
		public StringPart[] stringParts;

		[Header("Output")]
		[SerializeField]
		private string stringVariableName;

		[SerializeField]
		private TextSetMethod textMethod;

		[SerializeField]
		private Text textTarget;

		[Header("Events")]
		[SerializeField]
		private bool buildOnEnable;

		[SerializeField]
		private bool buildOnUpdate;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		public void BuildString()
		{
		}
	}
}
