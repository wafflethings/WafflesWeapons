using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossfadeTracker : MonoSingleton<CrossfadeTracker>
{
    public List<Crossfade> actives = new List<Crossfade>();
}
