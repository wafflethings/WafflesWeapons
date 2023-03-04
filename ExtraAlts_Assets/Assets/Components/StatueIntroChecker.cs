using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class StatueIntroChecker : MonoSingleton<StatueIntroChecker>
{
    public bool beenSeen;
}
