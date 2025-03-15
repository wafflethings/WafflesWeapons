using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;

namespace NewBlood
{
	[InputControlLayout(displayName = "Legacy Input", stateType = typeof(LegacyInputState))]
	public class LegacyInput : InputDevice, IInputUpdateCallbackReceiver
	{
		private LegacyInputState state;

		private Dictionary<KeyCode, ButtonControl> controls;

		public static LegacyInput current { get; private set; }

		public ButtonControl backspaceKey { get; private set; }

		public ButtonControl tabKey { get; private set; }

		public ButtonControl clearKey { get; private set; }

		public ButtonControl returnKey { get; private set; }

		public ButtonControl pauseKey { get; private set; }

		public ButtonControl escapeKey { get; private set; }

		public ButtonControl spaceKey { get; private set; }

		public ButtonControl exclaimKey { get; private set; }

		public ButtonControl doubleQuoteKey { get; private set; }

		public ButtonControl hashKey { get; private set; }

		public ButtonControl dollarKey { get; private set; }

		public ButtonControl percentKey { get; private set; }

		public ButtonControl ampersandKey { get; private set; }

		public ButtonControl quoteKey { get; private set; }

		public ButtonControl leftParenKey { get; private set; }

		public ButtonControl rightParenKey { get; private set; }

		public ButtonControl asteriskKey { get; private set; }

		public ButtonControl plusKey { get; private set; }

		public ButtonControl commaKey { get; private set; }

		public ButtonControl minusKey { get; private set; }

		public ButtonControl periodKey { get; private set; }

		public ButtonControl slashKey { get; private set; }

		public ButtonControl alpha0Key { get; private set; }

		public ButtonControl alpha1Key { get; private set; }

		public ButtonControl alpha2Key { get; private set; }

		public ButtonControl alpha3Key { get; private set; }

		public ButtonControl alpha4Key { get; private set; }

		public ButtonControl alpha5Key { get; private set; }

		public ButtonControl alpha6Key { get; private set; }

		public ButtonControl alpha7Key { get; private set; }

		public ButtonControl alpha8Key { get; private set; }

		public ButtonControl alpha9Key { get; private set; }

		public ButtonControl colonKey { get; private set; }

		public ButtonControl semicolonKey { get; private set; }

		public ButtonControl lessKey { get; private set; }

		public ButtonControl equalsKey { get; private set; }

		public ButtonControl greaterKey { get; private set; }

		public ButtonControl questionKey { get; private set; }

		public ButtonControl atKey { get; private set; }

		public ButtonControl leftBracketKey { get; private set; }

		public ButtonControl backslashKey { get; private set; }

		public ButtonControl rightBracketKey { get; private set; }

		public ButtonControl caretKey { get; private set; }

		public ButtonControl underscoreKey { get; private set; }

		public ButtonControl backQuoteKey { get; private set; }

		public ButtonControl aKey { get; private set; }

		public ButtonControl bKey { get; private set; }

		public ButtonControl cKey { get; private set; }

		public ButtonControl dKey { get; private set; }

		public ButtonControl eKey { get; private set; }

		public ButtonControl fKey { get; private set; }

		public ButtonControl gKey { get; private set; }

		public ButtonControl hKey { get; private set; }

		public ButtonControl iKey { get; private set; }

		public ButtonControl jKey { get; private set; }

		public ButtonControl kKey { get; private set; }

		public ButtonControl lKey { get; private set; }

		public ButtonControl mKey { get; private set; }

		public ButtonControl nKey { get; private set; }

		public ButtonControl oKey { get; private set; }

		public ButtonControl pKey { get; private set; }

		public ButtonControl qKey { get; private set; }

		public ButtonControl rKey { get; private set; }

		public ButtonControl sKey { get; private set; }

		public ButtonControl tKey { get; private set; }

		public ButtonControl uKey { get; private set; }

		public ButtonControl vKey { get; private set; }

		public ButtonControl wKey { get; private set; }

		public ButtonControl xKey { get; private set; }

		public ButtonControl yKey { get; private set; }

		public ButtonControl zKey { get; private set; }

		public ButtonControl leftCurlyBracketKey { get; private set; }

		public ButtonControl pipeKey { get; private set; }

		public ButtonControl rightCurlyBracketKey { get; private set; }

		public ButtonControl tildeKey { get; private set; }

		public ButtonControl deleteKey { get; private set; }

		public ButtonControl keypad0Key { get; private set; }

		public ButtonControl keypad1Key { get; private set; }

		public ButtonControl keypad2Key { get; private set; }

		public ButtonControl keypad3Key { get; private set; }

		public ButtonControl keypad4Key { get; private set; }

		public ButtonControl keypad5Key { get; private set; }

		public ButtonControl keypad6Key { get; private set; }

		public ButtonControl keypad7Key { get; private set; }

		public ButtonControl keypad8Key { get; private set; }

		public ButtonControl keypad9Key { get; private set; }

		public ButtonControl keypadPeriodKey { get; private set; }

		public ButtonControl keypadDivideKey { get; private set; }

		public ButtonControl keypadMultiplyKey { get; private set; }

		public ButtonControl keypadMinusKey { get; private set; }

		public ButtonControl keypadPlusKey { get; private set; }

		public ButtonControl keypadEnterKey { get; private set; }

		public ButtonControl keypadEqualsKey { get; private set; }

		public ButtonControl upArrowKey { get; private set; }

		public ButtonControl downArrowKey { get; private set; }

		public ButtonControl rightArrowKey { get; private set; }

		public ButtonControl leftArrowKey { get; private set; }

		public ButtonControl insertKey { get; private set; }

		public ButtonControl homeKey { get; private set; }

		public ButtonControl endKey { get; private set; }

		public ButtonControl pageUpKey { get; private set; }

		public ButtonControl pageDownKey { get; private set; }

		public ButtonControl f1Key { get; private set; }

		public ButtonControl f2Key { get; private set; }

		public ButtonControl f3Key { get; private set; }

		public ButtonControl f4Key { get; private set; }

		public ButtonControl f5Key { get; private set; }

		public ButtonControl f6Key { get; private set; }

		public ButtonControl f7Key { get; private set; }

		public ButtonControl f8Key { get; private set; }

		public ButtonControl f9Key { get; private set; }

		public ButtonControl f10Key { get; private set; }

		public ButtonControl f11Key { get; private set; }

		public ButtonControl f12Key { get; private set; }

		public ButtonControl f13Key { get; private set; }

		public ButtonControl f14Key { get; private set; }

		public ButtonControl f15Key { get; private set; }

		public ButtonControl numlockKey { get; private set; }

		public ButtonControl capsLockKey { get; private set; }

		public ButtonControl scrollLockKey { get; private set; }

		public ButtonControl rightShiftKey { get; private set; }

		public ButtonControl leftShiftKey { get; private set; }

		public ButtonControl rightControlKey { get; private set; }

		public ButtonControl leftControlKey { get; private set; }

		public ButtonControl rightAltKey { get; private set; }

		public ButtonControl leftAltKey { get; private set; }

		public ButtonControl rightCommandKey { get; private set; }

		public ButtonControl leftCommandKey { get; private set; }

		public ButtonControl leftWindowsKey { get; private set; }

		public ButtonControl rightWindowsKey { get; private set; }

		public ButtonControl altGrKey { get; private set; }

		public ButtonControl helpKey { get; private set; }

		public ButtonControl printKey { get; private set; }

		public ButtonControl sysReqKey { get; private set; }

		public ButtonControl breakKey { get; private set; }

		public ButtonControl menuKey { get; private set; }

		public ButtonControl mouseButton0 { get; private set; }

		public ButtonControl mouseButton1 { get; private set; }

		public ButtonControl mouseButton2 { get; private set; }

		public ButtonControl mouseButton3 { get; private set; }

		public ButtonControl mouseButton4 { get; private set; }

		public ButtonControl mouseButton5 { get; private set; }

		public ButtonControl mouseButton6 { get; private set; }

		public ButtonControl joystickButton0 { get; private set; }

		public ButtonControl joystickButton1 { get; private set; }

		public ButtonControl joystickButton2 { get; private set; }

		public ButtonControl joystickButton3 { get; private set; }

		public ButtonControl joystickButton4 { get; private set; }

		public ButtonControl joystickButton5 { get; private set; }

		public ButtonControl joystickButton6 { get; private set; }

		public ButtonControl joystickButton7 { get; private set; }

		public ButtonControl joystickButton8 { get; private set; }

		public ButtonControl joystickButton9 { get; private set; }

		public ButtonControl joystickButton10 { get; private set; }

		public ButtonControl joystickButton11 { get; private set; }

		public ButtonControl joystickButton12 { get; private set; }

		public ButtonControl joystickButton13 { get; private set; }

		public ButtonControl joystickButton14 { get; private set; }

		public ButtonControl joystickButton15 { get; private set; }

		public ButtonControl joystickButton16 { get; private set; }

		public ButtonControl joystickButton17 { get; private set; }

		public ButtonControl joystickButton18 { get; private set; }

		public ButtonControl joystickButton19 { get; private set; }

		public ButtonControl joystick1Button0 { get; private set; }

		public ButtonControl joystick1Button1 { get; private set; }

		public ButtonControl joystick1Button2 { get; private set; }

		public ButtonControl joystick1Button3 { get; private set; }

		public ButtonControl joystick1Button4 { get; private set; }

		public ButtonControl joystick1Button5 { get; private set; }

		public ButtonControl joystick1Button6 { get; private set; }

		public ButtonControl joystick1Button7 { get; private set; }

		public ButtonControl joystick1Button8 { get; private set; }

		public ButtonControl joystick1Button9 { get; private set; }

		public ButtonControl joystick1Button10 { get; private set; }

		public ButtonControl joystick1Button11 { get; private set; }

		public ButtonControl joystick1Button12 { get; private set; }

		public ButtonControl joystick1Button13 { get; private set; }

		public ButtonControl joystick1Button14 { get; private set; }

		public ButtonControl joystick1Button15 { get; private set; }

		public ButtonControl joystick1Button16 { get; private set; }

		public ButtonControl joystick1Button17 { get; private set; }

		public ButtonControl joystick1Button18 { get; private set; }

		public ButtonControl joystick1Button19 { get; private set; }

		public ButtonControl joystick2Button0 { get; private set; }

		public ButtonControl joystick2Button1 { get; private set; }

		public ButtonControl joystick2Button2 { get; private set; }

		public ButtonControl joystick2Button3 { get; private set; }

		public ButtonControl joystick2Button4 { get; private set; }

		public ButtonControl joystick2Button5 { get; private set; }

		public ButtonControl joystick2Button6 { get; private set; }

		public ButtonControl joystick2Button7 { get; private set; }

		public ButtonControl joystick2Button8 { get; private set; }

		public ButtonControl joystick2Button9 { get; private set; }

		public ButtonControl joystick2Button10 { get; private set; }

		public ButtonControl joystick2Button11 { get; private set; }

		public ButtonControl joystick2Button12 { get; private set; }

		public ButtonControl joystick2Button13 { get; private set; }

		public ButtonControl joystick2Button14 { get; private set; }

		public ButtonControl joystick2Button15 { get; private set; }

		public ButtonControl joystick2Button16 { get; private set; }

		public ButtonControl joystick2Button17 { get; private set; }

		public ButtonControl joystick2Button18 { get; private set; }

		public ButtonControl joystick2Button19 { get; private set; }

		public ButtonControl joystick3Button0 { get; private set; }

		public ButtonControl joystick3Button1 { get; private set; }

		public ButtonControl joystick3Button2 { get; private set; }

		public ButtonControl joystick3Button3 { get; private set; }

		public ButtonControl joystick3Button4 { get; private set; }

		public ButtonControl joystick3Button5 { get; private set; }

		public ButtonControl joystick3Button6 { get; private set; }

		public ButtonControl joystick3Button7 { get; private set; }

		public ButtonControl joystick3Button8 { get; private set; }

		public ButtonControl joystick3Button9 { get; private set; }

		public ButtonControl joystick3Button10 { get; private set; }

		public ButtonControl joystick3Button11 { get; private set; }

		public ButtonControl joystick3Button12 { get; private set; }

		public ButtonControl joystick3Button13 { get; private set; }

		public ButtonControl joystick3Button14 { get; private set; }

		public ButtonControl joystick3Button15 { get; private set; }

		public ButtonControl joystick3Button16 { get; private set; }

		public ButtonControl joystick3Button17 { get; private set; }

		public ButtonControl joystick3Button18 { get; private set; }

		public ButtonControl joystick3Button19 { get; private set; }

		public ButtonControl joystick4Button0 { get; private set; }

		public ButtonControl joystick4Button1 { get; private set; }

		public ButtonControl joystick4Button2 { get; private set; }

		public ButtonControl joystick4Button3 { get; private set; }

		public ButtonControl joystick4Button4 { get; private set; }

		public ButtonControl joystick4Button5 { get; private set; }

		public ButtonControl joystick4Button6 { get; private set; }

		public ButtonControl joystick4Button7 { get; private set; }

		public ButtonControl joystick4Button8 { get; private set; }

		public ButtonControl joystick4Button9 { get; private set; }

		public ButtonControl joystick4Button10 { get; private set; }

		public ButtonControl joystick4Button11 { get; private set; }

		public ButtonControl joystick4Button12 { get; private set; }

		public ButtonControl joystick4Button13 { get; private set; }

		public ButtonControl joystick4Button14 { get; private set; }

		public ButtonControl joystick4Button15 { get; private set; }

		public ButtonControl joystick4Button16 { get; private set; }

		public ButtonControl joystick4Button17 { get; private set; }

		public ButtonControl joystick4Button18 { get; private set; }

		public ButtonControl joystick4Button19 { get; private set; }

		public ButtonControl joystick5Button0 { get; private set; }

		public ButtonControl joystick5Button1 { get; private set; }

		public ButtonControl joystick5Button2 { get; private set; }

		public ButtonControl joystick5Button3 { get; private set; }

		public ButtonControl joystick5Button4 { get; private set; }

		public ButtonControl joystick5Button5 { get; private set; }

		public ButtonControl joystick5Button6 { get; private set; }

		public ButtonControl joystick5Button7 { get; private set; }

		public ButtonControl joystick5Button8 { get; private set; }

		public ButtonControl joystick5Button9 { get; private set; }

		public ButtonControl joystick5Button10 { get; private set; }

		public ButtonControl joystick5Button11 { get; private set; }

		public ButtonControl joystick5Button12 { get; private set; }

		public ButtonControl joystick5Button13 { get; private set; }

		public ButtonControl joystick5Button14 { get; private set; }

		public ButtonControl joystick5Button15 { get; private set; }

		public ButtonControl joystick5Button16 { get; private set; }

		public ButtonControl joystick5Button17 { get; private set; }

		public ButtonControl joystick5Button18 { get; private set; }

		public ButtonControl joystick5Button19 { get; private set; }

		public ButtonControl joystick6Button0 { get; private set; }

		public ButtonControl joystick6Button1 { get; private set; }

		public ButtonControl joystick6Button2 { get; private set; }

		public ButtonControl joystick6Button3 { get; private set; }

		public ButtonControl joystick6Button4 { get; private set; }

		public ButtonControl joystick6Button5 { get; private set; }

		public ButtonControl joystick6Button6 { get; private set; }

		public ButtonControl joystick6Button7 { get; private set; }

		public ButtonControl joystick6Button8 { get; private set; }

		public ButtonControl joystick6Button9 { get; private set; }

		public ButtonControl joystick6Button10 { get; private set; }

		public ButtonControl joystick6Button11 { get; private set; }

		public ButtonControl joystick6Button12 { get; private set; }

		public ButtonControl joystick6Button13 { get; private set; }

		public ButtonControl joystick6Button14 { get; private set; }

		public ButtonControl joystick6Button15 { get; private set; }

		public ButtonControl joystick6Button16 { get; private set; }

		public ButtonControl joystick6Button17 { get; private set; }

		public ButtonControl joystick6Button18 { get; private set; }

		public ButtonControl joystick6Button19 { get; private set; }

		public ButtonControl joystick7Button0 { get; private set; }

		public ButtonControl joystick7Button1 { get; private set; }

		public ButtonControl joystick7Button2 { get; private set; }

		public ButtonControl joystick7Button3 { get; private set; }

		public ButtonControl joystick7Button4 { get; private set; }

		public ButtonControl joystick7Button5 { get; private set; }

		public ButtonControl joystick7Button6 { get; private set; }

		public ButtonControl joystick7Button7 { get; private set; }

		public ButtonControl joystick7Button8 { get; private set; }

		public ButtonControl joystick7Button9 { get; private set; }

		public ButtonControl joystick7Button10 { get; private set; }

		public ButtonControl joystick7Button11 { get; private set; }

		public ButtonControl joystick7Button12 { get; private set; }

		public ButtonControl joystick7Button13 { get; private set; }

		public ButtonControl joystick7Button14 { get; private set; }

		public ButtonControl joystick7Button15 { get; private set; }

		public ButtonControl joystick7Button16 { get; private set; }

		public ButtonControl joystick7Button17 { get; private set; }

		public ButtonControl joystick7Button18 { get; private set; }

		public ButtonControl joystick7Button19 { get; private set; }

		public ButtonControl joystick8Button0 { get; private set; }

		public ButtonControl joystick8Button1 { get; private set; }

		public ButtonControl joystick8Button2 { get; private set; }

		public ButtonControl joystick8Button3 { get; private set; }

		public ButtonControl joystick8Button4 { get; private set; }

		public ButtonControl joystick8Button5 { get; private set; }

		public ButtonControl joystick8Button6 { get; private set; }

		public ButtonControl joystick8Button7 { get; private set; }

		public ButtonControl joystick8Button8 { get; private set; }

		public ButtonControl joystick8Button9 { get; private set; }

		public ButtonControl joystick8Button10 { get; private set; }

		public ButtonControl joystick8Button11 { get; private set; }

		public ButtonControl joystick8Button12 { get; private set; }

		public ButtonControl joystick8Button13 { get; private set; }

		public ButtonControl joystick8Button14 { get; private set; }

		public ButtonControl joystick8Button15 { get; private set; }

		public ButtonControl joystick8Button16 { get; private set; }

		public ButtonControl joystick8Button17 { get; private set; }

		public ButtonControl joystick8Button18 { get; private set; }

		public ButtonControl joystick8Button19 { get; private set; }

		public bool TryGetButton(KeyCode key, out ButtonControl button)
		{
			button = null;
			return false;
		}

		public ButtonControl GetButton(KeyCode key)
		{
			return null;
		}

		public void OnUpdate()
		{
		}

		public override void MakeCurrent()
		{
		}

		protected override void FinishSetup()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void RuntimeInitialize()
		{
		}

		static LegacyInput()
		{
		}
	}
}
