using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WafflesWeapons.Components
{
    public class GunBehaviour<T> : GunBehaviour where T : GunBehaviour<T>
    {
        public static List<T> Instances
        {
            get
            {
                _instances.RemoveAll(x => x == null);
                return _instances;
            }

            private set
            {
                _instances = value;
            }
        }
        private static List<T> _instances = new List<T>();

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
