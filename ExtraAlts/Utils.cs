using BepInEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace WafflesWeapons
{
    public static class PathUtils
    {
        public static string GameDirectory()
        {
            string path = Application.dataPath;
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                path = Utility.ParentDirectory(path, 2);
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                path = Utility.ParentDirectory(path, 1);
            }

            return path;
        }

        public static string ModDirectory()
        {
            // return Path.Combine(GameDirectory(), @"BepInEx\UMM Mods");
            return Path.Combine(GameDirectory(), "BepInEx", "plugins");
        }

        public static string ModPath()
        {
            return Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf(Path.DirectorySeparatorChar));
        }
    }

    public static class GameObjectUtils
    {
        public static GameObject ChildByName(this GameObject from, string name)
        {
            List<GameObject> children = new List<GameObject>();
            int count = 0;
            while (count < from.transform.childCount)
            {
                children.Add(from.transform.GetChild(count).gameObject);
                count++;
            }

            if (count == 0)
            {
                return null;
            }

            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].name == name)
                {
                    return children[i];
                }
            }
            return null;
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
    }

    public class UltrakillUtils
    {
        public static GameObject NearestEnemy(Vector3 point, float maxDistance, EnemyIdentifier exclude = null)
        {
            float max = maxDistance;
            GameObject nearestEnemy = null;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<EnemyIdentifier>() != null && !enemy.GetComponent<EnemyIdentifier>().dead && 
                    enemy.GetComponent<EnemyIdentifier>() != exclude &&Vector3.Distance(point, enemy.transform.position) < max)
                {
                    max = Vector3.Distance(point, enemy.transform.position);
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }

        public static Vector3 NearestEnemyPoint(Vector3 point, float maxDistance, EnemyIdentifier exclude = null)
        {
            float max = maxDistance;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Transform enemyFinal = null;

            foreach (GameObject enemy in enemies)
            {
                EnemyIdentifier eid = enemy.GetComponent<EnemyIdentifier>();
                Transform enemyTransform = null;

                if (eid != null && !eid.dead && eid != exclude && Vector3.Distance(point, enemy.transform.position) < max)
                {
                    if (eid.weakPoint != null && eid.weakPoint.activeInHierarchy)
                    {
                        enemyTransform = eid.weakPoint.transform;
                    }
                    else
                    {
                        EnemyIdentifierIdentifier eidid = eid.GetComponentInChildren<EnemyIdentifierIdentifier>();
                        if (eidid != null)
                        {
                            enemyTransform = eidid.transform;
                        }
                        else
                        {
                            enemyTransform = enemy.transform;
                        }
                    }

                    max = Vector3.Distance(point, enemyTransform.position);
                    enemyFinal = enemyTransform;
                }
            }

            return (enemyFinal != null ? enemyFinal.position : point);
        }
    }
}
