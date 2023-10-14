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
    public static class BezierCurve //https://faramira.com/implement-bezier-curve-using-csharp-in-unity/
    {
        // a look up table for factorials. Capped to 16.
        private static float[] _factorial = new float[]
        {
            1.0f,
            1.0f,
            2.0f,
            6.0f,
            24.0f,
            120.0f,
            720.0f,
            5040.0f,
            40320.0f,
            362880.0f,
            3628800.0f,
            39916800.0f,
            479001600.0f,
            6227020800.0f,
            87178291200.0f,
            1307674368000.0f,
            20922789888000.0f,
        };

        private static float Binomial(int n, int i)
        {
            float ni;
            float a1 = _factorial[n];
            float a2 = _factorial[i];
            float a3 = _factorial[n - i];
            ni = a1 / (a2 * a3);
            return ni;
        }

        private static float Bernstein(int n, int i, float t)
        {
            float t_i = Mathf.Pow(t, i);
            float t_n_minus_i = Mathf.Pow((1 - t), (n - i));

            float basis = Binomial(n, i) * t_i * t_n_minus_i;
            return basis;
        }

        public static List<Vector3> PointList3(List<Vector3> controlPoints, float interval = 0.01f)
        {
            int N = controlPoints.Count - 1;
            if (N > 16)
            {
                Debug.Log("You have used more than 16 control points. " +
                  "The maximum control points allowed is 16.");
                controlPoints.RemoveRange(16, controlPoints.Count - 16);
            }

            List<Vector3> points = new List<Vector3>();
            for (float t = 0.0f; t <= 1.0f + interval - 0.0001f; t += interval)
            {
                Vector3 p = new Vector3();
                for (int i = 0; i < controlPoints.Count; ++i)
                {
                    Vector3 bn = Bernstein(N, i, t) * controlPoints[i];
                    p += bn;
                }
                points.Add(p);
            }

            return points;
        }
    }

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
            return Assembly.GetCallingAssembly().Location.Substring(0, Assembly.GetCallingAssembly().Location.LastIndexOf(Path.DirectorySeparatorChar));
        }
    }

    public static class UnityUtils
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

        public static bool Contains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
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
