using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct UIActions
	{
		private InputActions m_Wrapper;

		public InputAction Navigate => null;

		public InputAction Submit => null;

		public InputAction Cancel => null;

		public InputAction Point => null;

		public InputAction Click => null;

		public InputAction ScrollWheel => null;

		public InputAction MiddleClick => null;

		public InputAction RightClick => null;

		public InputAction TrackedDevicePosition => null;

		public InputAction TrackedDeviceOrientation => null;

		public InputAction ScrollSublist => null;

		public InputAction Pause => null;

		public bool enabled => false;

		public UIActions(InputActions wrapper)
		{
			m_Wrapper = null;
		}

		public InputActionMap Get()
		{
			return null;
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public static implicit operator InputActionMap(UIActions set)
		{
			return null;
		}

		public void AddCallbacks(IUIActions instance)
		{
		}

		private void UnregisterCallbacks(IUIActions instance)
		{
		}

		public void RemoveCallbacks(IUIActions instance)
		{
		}

		public void SetCallbacks(IUIActions instance)
		{
		}
	}

	public struct MovementActions
	{
		private InputActions m_Wrapper;

		public InputAction Move => null;

		public InputAction Look => null;

		public InputAction Dodge => null;

		public InputAction Slide => null;

		public InputAction Jump => null;

		public bool enabled => false;

		public MovementActions(InputActions wrapper)
		{
			m_Wrapper = null;
		}

		public InputActionMap Get()
		{
			return null;
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public static implicit operator InputActionMap(MovementActions set)
		{
			return null;
		}

		public void AddCallbacks(IMovementActions instance)
		{
		}

		private void UnregisterCallbacks(IMovementActions instance)
		{
		}

		public void RemoveCallbacks(IMovementActions instance)
		{
		}

		public void SetCallbacks(IMovementActions instance)
		{
		}
	}

	public struct FistActions
	{
		private InputActions m_Wrapper;

		public InputAction Punch => null;

		public InputAction ChangeFist => null;

		public InputAction PunchFeedbacker => null;

		public InputAction PunchKnuckleblaster => null;

		public InputAction Hook => null;

		public bool enabled => false;

		public FistActions(InputActions wrapper)
		{
			m_Wrapper = null;
		}

		public InputActionMap Get()
		{
			return null;
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public static implicit operator InputActionMap(FistActions set)
		{
			return null;
		}

		public void AddCallbacks(IFistActions instance)
		{
		}

		private void UnregisterCallbacks(IFistActions instance)
		{
		}

		public void RemoveCallbacks(IFistActions instance)
		{
		}

		public void SetCallbacks(IFistActions instance)
		{
		}
	}

	public struct WeaponActions
	{
		private InputActions m_Wrapper;

		public InputAction PrimaryFire => null;

		public InputAction SecondaryFire => null;

		public InputAction NextVariation => null;

		public InputAction PreviousVariation => null;

		public InputAction Revolver => null;

		public InputAction Shotgun => null;

		public InputAction Nailgun => null;

		public InputAction Railcannon => null;

		public InputAction RocketLauncher => null;

		public InputAction SpawnerArm => null;

		public InputAction NextWeapon => null;

		public InputAction PreviousWeapon => null;

		public InputAction LastUsedWeapon => null;

		public InputAction WheelLook => null;

		public InputAction VariationSlot1 => null;

		public InputAction VariationSlot2 => null;

		public InputAction VariationSlot3 => null;

		public bool enabled => false;

		public WeaponActions(InputActions wrapper)
		{
			m_Wrapper = null;
		}

		public InputActionMap Get()
		{
			return null;
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public static implicit operator InputActionMap(WeaponActions set)
		{
			return null;
		}

		public void AddCallbacks(IWeaponActions instance)
		{
		}

		private void UnregisterCallbacks(IWeaponActions instance)
		{
		}

		public void RemoveCallbacks(IWeaponActions instance)
		{
		}

		public void SetCallbacks(IWeaponActions instance)
		{
		}
	}

	public struct HUDActions
	{
		private InputActions m_Wrapper;

		public InputAction Stats => null;

		public bool enabled => false;

		public HUDActions(InputActions wrapper)
		{
			m_Wrapper = null;
		}

		public InputActionMap Get()
		{
			return null;
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public static implicit operator InputActionMap(HUDActions set)
		{
			return null;
		}

		public void AddCallbacks(IHUDActions instance)
		{
		}

		private void UnregisterCallbacks(IHUDActions instance)
		{
		}

		public void RemoveCallbacks(IHUDActions instance)
		{
		}

		public void SetCallbacks(IHUDActions instance)
		{
		}
	}

	public interface IUIActions
	{
		void OnNavigate(InputAction.CallbackContext context);

		void OnSubmit(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnPoint(InputAction.CallbackContext context);

		void OnClick(InputAction.CallbackContext context);

		void OnScrollWheel(InputAction.CallbackContext context);

		void OnMiddleClick(InputAction.CallbackContext context);

		void OnRightClick(InputAction.CallbackContext context);

		void OnTrackedDevicePosition(InputAction.CallbackContext context);

		void OnTrackedDeviceOrientation(InputAction.CallbackContext context);

		void OnScrollSublist(InputAction.CallbackContext context);

		void OnPause(InputAction.CallbackContext context);
	}

	public interface IMovementActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnDodge(InputAction.CallbackContext context);

		void OnSlide(InputAction.CallbackContext context);

		void OnJump(InputAction.CallbackContext context);
	}

	public interface IFistActions
	{
		void OnPunch(InputAction.CallbackContext context);

		void OnChangeFist(InputAction.CallbackContext context);

		void OnPunchFeedbacker(InputAction.CallbackContext context);

		void OnPunchKnuckleblaster(InputAction.CallbackContext context);

		void OnHook(InputAction.CallbackContext context);
	}

	public interface IWeaponActions
	{
		void OnPrimaryFire(InputAction.CallbackContext context);

		void OnSecondaryFire(InputAction.CallbackContext context);

		void OnNextVariation(InputAction.CallbackContext context);

		void OnPreviousVariation(InputAction.CallbackContext context);

		void OnRevolver(InputAction.CallbackContext context);

		void OnShotgun(InputAction.CallbackContext context);

		void OnNailgun(InputAction.CallbackContext context);

		void OnRailcannon(InputAction.CallbackContext context);

		void OnRocketLauncher(InputAction.CallbackContext context);

		void OnSpawnerArm(InputAction.CallbackContext context);

		void OnNextWeapon(InputAction.CallbackContext context);

		void OnPreviousWeapon(InputAction.CallbackContext context);

		void OnLastUsedWeapon(InputAction.CallbackContext context);

		void OnWheelLook(InputAction.CallbackContext context);

		void OnVariationSlot1(InputAction.CallbackContext context);

		void OnVariationSlot2(InputAction.CallbackContext context);

		void OnVariationSlot3(InputAction.CallbackContext context);
	}

	public interface IHUDActions
	{
		void OnStats(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_UI;

	private List<IUIActions> m_UIActionsCallbackInterfaces;

	private readonly InputAction m_UI_Navigate;

	private readonly InputAction m_UI_Submit;

	private readonly InputAction m_UI_Cancel;

	private readonly InputAction m_UI_Point;

	private readonly InputAction m_UI_Click;

	private readonly InputAction m_UI_ScrollWheel;

	private readonly InputAction m_UI_MiddleClick;

	private readonly InputAction m_UI_RightClick;

	private readonly InputAction m_UI_TrackedDevicePosition;

	private readonly InputAction m_UI_TrackedDeviceOrientation;

	private readonly InputAction m_UI_ScrollSublist;

	private readonly InputAction m_UI_Pause;

	private readonly InputActionMap m_Movement;

	private List<IMovementActions> m_MovementActionsCallbackInterfaces;

	private readonly InputAction m_Movement_Move;

	private readonly InputAction m_Movement_Look;

	private readonly InputAction m_Movement_Dodge;

	private readonly InputAction m_Movement_Slide;

	private readonly InputAction m_Movement_Jump;

	private readonly InputActionMap m_Fist;

	private List<IFistActions> m_FistActionsCallbackInterfaces;

	private readonly InputAction m_Fist_Punch;

	private readonly InputAction m_Fist_ChangeFist;

	private readonly InputAction m_Fist_PunchFeedbacker;

	private readonly InputAction m_Fist_PunchKnuckleblaster;

	private readonly InputAction m_Fist_Hook;

	private readonly InputActionMap m_Weapon;

	private List<IWeaponActions> m_WeaponActionsCallbackInterfaces;

	private readonly InputAction m_Weapon_PrimaryFire;

	private readonly InputAction m_Weapon_SecondaryFire;

	private readonly InputAction m_Weapon_NextVariation;

	private readonly InputAction m_Weapon_PreviousVariation;

	private readonly InputAction m_Weapon_Revolver;

	private readonly InputAction m_Weapon_Shotgun;

	private readonly InputAction m_Weapon_Nailgun;

	private readonly InputAction m_Weapon_Railcannon;

	private readonly InputAction m_Weapon_RocketLauncher;

	private readonly InputAction m_Weapon_SpawnerArm;

	private readonly InputAction m_Weapon_NextWeapon;

	private readonly InputAction m_Weapon_PreviousWeapon;

	private readonly InputAction m_Weapon_LastUsedWeapon;

	private readonly InputAction m_Weapon_WheelLook;

	private readonly InputAction m_Weapon_VariationSlot1;

	private readonly InputAction m_Weapon_VariationSlot2;

	private readonly InputAction m_Weapon_VariationSlot3;

	private readonly InputActionMap m_HUD;

	private List<IHUDActions> m_HUDActionsCallbackInterfaces;

	private readonly InputAction m_HUD_Stats;

	private int m_KeyboardMouseSchemeIndex;

	private int m_GamepadSchemeIndex;

	public InputActionAsset asset { get; }

	public InputBinding? bindingMask
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes => default(ReadOnlyArray<InputControlScheme>);

	public IEnumerable<InputBinding> bindings => null;

	public UIActions UI => default(UIActions);

	public MovementActions Movement => default(MovementActions);

	public FistActions Fist => default(FistActions);

	public WeaponActions Weapon => default(WeaponActions);

	public HUDActions HUD => default(HUDActions);

	public InputControlScheme KeyboardMouseScheme => default(InputControlScheme);

	public InputControlScheme GamepadScheme => default(InputControlScheme);

	public void Dispose()
	{
	}

	public bool Contains(InputAction action)
	{
		return false;
	}

	public IEnumerator<InputAction> GetEnumerator()
	{
		return null;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return null;
	}

	public void Enable()
	{
	}

	public void Disable()
	{
	}

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return null;
	}

	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		action = null;
		return 0;
	}
}
