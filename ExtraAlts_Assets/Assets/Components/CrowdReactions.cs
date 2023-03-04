using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class CrowdReactions : MonoSingleton<CrowdReactions>
{
    public AudioClip cheer;
    public AudioClip cheerLong;
    public AudioClip aww;

    public void React(AudioClip clip)
{}}
