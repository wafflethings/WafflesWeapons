using System.Collections.Generic;
using UnityEngine;

namespace WafflesWeapons.Utils
{
    public static class UnityUtils
    {
        public static GameObject GetChild(this GameObject from, string name)
        {
            return from.transform.Find(name).gameObject;
        }

        public static List<GameObject> FindSceneObjects(string sceneName)
        {
            List<GameObject> objs = new List<GameObject>();
            foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (obj.scene.name == sceneName)
                {
                    objs.Add(obj);
                }
            }

            return objs;
        }

        public static List<GameObject> ChildrenList(this GameObject from)
        {
            List<GameObject> children = new List<GameObject>();
            int count = 0;
            while (count < from.transform.childCount)
            {
                children.Add(from.transform.GetChild(count).gameObject);
                count++;
            }

            return children;
        }

        public static bool Contains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
    }
}
