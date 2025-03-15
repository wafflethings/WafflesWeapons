using Sandbox.Arm;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using plog;

namespace Sandbox
{
	[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
	public class SandboxAlterMenu : MonoSingleton<SandboxAlterMenu>
	{
		private static readonly plog.Logger Log;

		[SerializeField]
		private GameObject shadow;

		[SerializeField]
		private GameObject menu;

		[Space]
		[SerializeField]
		private TMP_Text nameText;

		[Space]
		[SerializeField]
		private Toggle uniformSize;

		[SerializeField]
		private InputField sizeField;

		[SerializeField]
		private InputField sizeFieldX;

		[SerializeField]
		private InputField sizeFieldY;

		[SerializeField]
		private InputField sizeFieldZ;

		[Space]
		[SerializeField]
		private Toggle radianceEnabled;

		[SerializeField]
		private Slider radianceTier;

		[SerializeField]
		private Slider radianceHealth;

		[SerializeField]
		private Slider radianceDamage;

		[SerializeField]
		private Slider radianceSpeed;

		[Space]
		[SerializeField]
		private GameObject sizeContainer;

		[SerializeField]
		private GameObject uniformContainer;

		[SerializeField]
		private Toggle frozenCheckbox;

		[SerializeField]
		private Toggle disallowManipulationCheckbox;

		[SerializeField]
		private Toggle disallowFreezingCheckbox;

		[SerializeField]
		private GameObject splitContainer;

		[SerializeField]
		private GameObject enemyOptionsContainer;

		[SerializeField]
		private GameObject radianceSettings;

		[Space]
		[SerializeField]
		private GameObject scaleUpSound;

		[SerializeField]
		private GameObject scaleDownSound;

		[SerializeField]
		private GameObject scaleResetSound;

		[Space]
		[SerializeField]
		private AlterMenuElements elementManager;

		public SandboxSpawnableInstance editedObject;

		public AlterMode alterInstance;

		public Vector3 SafeSize(Vector3 originalSize)
		{
			return default(Vector3);
		}

		protected override void Awake()
		{
		}

		private void SetSizeX(string value)
		{
		}

		private void SetSizeY(string value)
		{
		}

		private void SetSizeZ(string value)
		{
		}

		private void SetSize(string value)
		{
		}

		public void SetJumpPadPower(float value)
		{
		}

		public void SetFrozen(bool frozen)
		{
		}

		public void SetDisallowManipulation(bool disallow)
		{
		}

		public void SetDisallowFreezing(bool disallow)
		{
		}

		public void SetRadianceTierSlider(float value)
		{
		}

		public void SetRadianceTier(float value)
		{
		}

		public void SetHealthBuffSlider(float value)
		{
		}

		public void SetHealthBuff(float value)
		{
		}

		public void SetDamageBuffSlider(float value)
		{
		}

		public void SetDamageBuff(float value)
		{
		}

		public void SetSpeedBuffSlider(float value)
		{
		}

		public void SetSpeedBuff(float value)
		{
		}

		public void ShowRadianceOptions(bool value)
		{
		}

		public void ShowUniformSizeMenu(bool value)
		{
		}

		public void DefaultSize()
		{
		}

		public void MultiplySize(float value)
		{
		}

		public void UpdateSizeValues()
		{
		}

		public void Show(SandboxSpawnableInstance prop, AlterMode instance)
		{
		}

		public void Close()
		{
		}

		private void Update()
		{
		}
	}
}
