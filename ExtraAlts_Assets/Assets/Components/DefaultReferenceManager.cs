using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class DefaultReferenceManager : MonoSingleton<DefaultReferenceManager>
{
    public GameObject wetParticle;
}
