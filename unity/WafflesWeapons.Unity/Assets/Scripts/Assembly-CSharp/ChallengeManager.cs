using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ChallengeManager : MonoSingleton<ChallengeManager>
{
	public GameObject challengePanel;

	public FinalRank fr;

	private bool completedCheck;

	private bool startCheckingForChallenge;

	public bool challengeDone;

	public bool challengeFailed;

	public bool challengeFailedPermanently;

	protected override void Awake()
	{
	}

	private new void OnEnable()
	{
	}

	public void ChallengeDone()
	{
	}

	public void ChallengeFailed()
	{
	}
}
