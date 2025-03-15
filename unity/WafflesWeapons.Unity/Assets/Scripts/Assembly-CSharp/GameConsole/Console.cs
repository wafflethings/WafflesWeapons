using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using plog;
using plog.Handlers;
using plog.Models;
using plog.unity.Handlers;

namespace GameConsole
{
	[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
	public class Console : MonoSingleton<Console>, plog.Handlers.ILogHandler
	{
		[Serializable]
		public class AutocompletePanel
		{
			public TMP_Text text;

			public Image background;
		}

		[CompilerGenerated]
		private sealed class _003CFadeBlockerIn_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Console _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFadeBlockerIn_003Ed__76(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public static readonly plog.Logger Log;

		public bool pinned;

		public bool consoleOpen;

		public List<ConsoleLog> logs;

		public readonly HashSet<Level> logLevelFilter;

		private int logLevelCount;

		public int errorCount;

		public int warningCount;

		public int infoCount;

		private readonly List<LogLine> logLinePool;

		[SerializeField]
		private GameObject consoleContainer;

		[SerializeField]
		private CanvasGroup consoleBlocker;

		[SerializeField]
		private TMP_InputField consoleInput;

		[Space]
		[SerializeField]
		private LogLine logLine;

		[SerializeField]
		private GameObject logContainer;

		[Space]
		[SerializeField]
		private GameObject scroller;

		[SerializeField]
		private TMP_Text scrollText;

		[SerializeField]
		private TMP_Text openBindText;

		[SerializeField]
		private AutocompletePanel[] autocompletePanels;

		[Space]
		public ErrorBadge errorBadge;

		[Space]
		[SerializeField]
		private GameObject[] hideOnPin;

		[SerializeField]
		private GameObject[] hideOnPinNoReopen;

		[SerializeField]
		private Image[] backgrounds;

		[SerializeField]
		private CanvasGroup masterGroup;

		[Space]
		public ConsoleWindow consoleWindow;

		private const int MaxLogLines = 20;

		private bool openedDuringPause;

		private OptionsManager rememberedOptionsManager;

		public readonly Dictionary<string, ICommand> recognizedCommands;

		public readonly HashSet<Type> registeredCommandTypes;

		private bool logsDirty;

		private int scrollState;

		private UnscaledTimeSince timeSincePgHeld;

		private UnscaledTimeSince timeSinceScrollTick;

		private List<string> commandHistory;

		private int commandHistoryIndex;

		public Action onError;

		public Binds binds;

		private List<string> suggestions;

		private int selectedSuggestionIndex;

		private int suggestionStartIndex;

		private PconAdapter pconAdapter;

		private UnityProxy unityProxyHandler;

		public static bool IsOpen => false;

		public bool ExtractStackTraces { get; private set; }

		private List<ConsoleLog> filteredLogs => null;

		protected override void Awake()
		{
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
		}

		private void InitializePLog()
		{
		}

		private void HandleUnityLog(string message, string stacktrace, LogType type)
		{
		}

		public Log HandleRecord(plog.Logger source, Log log)
		{
			return null;
		}

		public static void RefreshPLogConfiguration()
		{
		}

		public void StartPCon()
		{
		}

		public void UpdateDisplayString()
		{
		}

		public bool CheatBlocker()
		{
			return false;
		}

		public void RegisterCommands(IEnumerable<ICommand> commands)
		{
		}

		public void RegisterCommand(ICommand command)
		{
		}

		public void Clear()
		{
		}

		private void IncrementCounters(Level type)
		{
		}

		public void UpdateFilters(bool showErrors, bool showWarnings, bool showLogs)
		{
		}

		public void SetForceStackTraceExtraction(bool value)
		{
		}

		public string[] Parse(string text)
		{
			return null;
		}

		private void ProcessUserInput(string text)
		{
		}

		public void ProcessInput(string text)
		{
		}

		private void ScrollUp()
		{
		}

		private void ScrollDown()
		{
		}

		private void DefaultDevConsoleOff()
		{
		}

		private void Update()
		{
		}

		private void UpdateScroller()
		{
		}

		[IteratorStateMachine(typeof(_003CFadeBlockerIn_003Ed__76))]
		private IEnumerator FadeBlockerIn()
		{
			return null;
		}

		private void SelectSuggestion(int newIndex, bool wrap = false)
		{
		}

		private void ShowSuggestions(int selected)
		{
		}

		private void FindSuggestions(string value)
		{
		}

		private void InsertLog(Log log)
		{
		}

		private void RepopulateLogs()
		{
		}
	}
}
