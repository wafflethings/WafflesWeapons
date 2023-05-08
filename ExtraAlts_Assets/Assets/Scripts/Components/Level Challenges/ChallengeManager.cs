using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ChallengeManager : MonoSingleton<ChallengeManager> {
    public GameObject challengePanel;
    public FinalRank fr;
    public bool challengeDone;
    public bool challengeFailed;

	 
	protected override void Awake () {}
    private void OnEnable() { }
    public void ChallengeDone() { }
    public void ChallengeFailed() { }}
