using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ChallengeManager : MonoSingleton<ChallengeManager> {
    public GameObject challengePanel;
    public FinalRank fr;
    public bool challengeDone;

    public void ChallengeDone()
{}}
