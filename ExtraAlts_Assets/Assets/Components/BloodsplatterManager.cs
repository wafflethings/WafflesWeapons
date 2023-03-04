using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoreType
{
    Head,
    Limb,
    Body,
    Small,
    Splatter
}

public enum GibType
{
    Brain,
    Skull,
    Eye,
    Jaw,
    Gib
}

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class BloodsplatterManager : MonoSingleton<BloodsplatterManager>
{
    public GameObject head;
    public GameObject limb;
    public GameObject body;
    public GameObject small;
    public GameObject splatter;
    public GameObject underwater;
    public GameObject sand;

    public GameObject brainChunk;
    public GameObject skullChunk;
    public GameObject eyeball;
    public GameObject jawChunk;
    public GameObject[] gib;
}
