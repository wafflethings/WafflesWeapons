using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class ClimbStep : MonoSingleton<ClimbStep>
{

    void Awake() { }
    void Start() { }
    void FixedUpdate() { }
    void OnCollisionStay(Collision collisionInfo) { }
     

}
