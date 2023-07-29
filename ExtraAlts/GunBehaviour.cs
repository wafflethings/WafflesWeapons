using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WafflesWeapons
{
    public class GunBehaviour<T> : GunBehaviour where T : GunBehaviour<T>
    {
        public static List<T> Instances { get; private set; } = new List<T>();

        public void Awake()
        {
            Instances.Add((T)this);
        }

        private void OnDestroy()
        {
            Instances.Remove((T)this);
        }
    }

    public class GunBehaviour : MonoBehaviour
    {

    }
}
