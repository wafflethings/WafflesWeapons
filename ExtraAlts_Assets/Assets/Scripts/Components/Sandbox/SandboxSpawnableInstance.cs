using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sandbox
{
    public class SandboxSpawnableInstance : MonoBehaviour
    {
        public SpawnableObject sourceObject;
        public GameObject attachedParticles;
        public Collider collider;
        
        public bool uniformSize => transform.localScale.x == transform.localScale.y && transform.localScale.y == transform.localScale.z;
        public float defaultSize { get; private set; }
        public Vector3 normalizedSize => transform.localScale / defaultSize;
        
        public bool frozen;

        public virtual void SetSize(Vector3 size)
        {
            
        }
        
        public void SetSizeUniform(float size)
        {
           
        }

        public virtual void Pause(bool freeze = true)
        {
            if (freeze) frozen = true;
        }
        
        public virtual void Resume()
        {
            frozen = false;
        }
    }
}