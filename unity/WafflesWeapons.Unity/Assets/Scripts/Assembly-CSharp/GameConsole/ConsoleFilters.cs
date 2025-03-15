using UnityEngine;

namespace GameConsole
{
	public class ConsoleFilters : MonoBehaviour
	{
		[SerializeField]
		private float defaultOpacity;

		[SerializeField]
		private float hiddenOpacity;

		[Space]
		[SerializeField]
		private FilterButton errorsFilter;

		[SerializeField]
		private FilterButton warningsFilter;

		[SerializeField]
		private FilterButton logsFilter;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void TogglePopup()
		{
		}

		private void UpdateFilters()
		{
		}

		public void ToggleErrorFiltering()
		{
		}

		public void ToggleWarningFiltering()
		{
		}

		public void ToggleLogFiltering()
		{
		}
	}
}
