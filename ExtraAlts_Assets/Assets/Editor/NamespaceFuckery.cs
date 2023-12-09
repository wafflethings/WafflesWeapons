using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NamespaceFuckery : EditorWindow
{
    public static string Original = "ULTRACRYPT.UI";
    public static string New = "ULTRACRYPT.UI.Elements";
    public static string ScriptName;


    [MenuItem("Tools/Namespace Changer")]
    public static void Init()
    {
        // Get existing open window or if none, make a new one:
        NamespaceFuckery window = (NamespaceFuckery)GetWindow(typeof(NamespaceFuckery));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("all of this code was written while sleep deprived and at 1am.\nabandon hope if you have to use this.", EditorStyles.boldLabel);
        GUILayout.Label("if you don't know exactly how this works (you aren't waffle :3) don't use this. you will likely break everything.");

        GUILayout.BeginHorizontal();
        GUILayout.Space(EditorGUI.indentLevel * 10); GUILayout.Label("Original namespace", GUILayout.Width(150));
        GUILayout.Space(10);
        GUILayout.Space(EditorGUI.indentLevel * 10); Original = GUILayout.TextField(Original);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Space(EditorGUI.indentLevel * 10); GUILayout.Label("New namespace", GUILayout.Width(150));
        GUILayout.Space(10);
        GUILayout.Space(EditorGUI.indentLevel * 10); New = GUILayout.TextField(New);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Space(EditorGUI.indentLevel * 10); GUILayout.Label("Script", GUILayout.Width(150));
        GUILayout.Space(10);
        GUILayout.Space(EditorGUI.indentLevel * 10); ScriptName = GUILayout.TextField(ScriptName);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("replace in current scene"))
        {
            DoShitScene();
        }

        if (GUILayout.Button("replace in assets"))
        {
            DoShit();
        }

        if (GUILayout.Button("replace in selected SOs"))
        {
            DoShitSo(Selection.GetFiltered<ScriptableObject>(SelectionMode.DeepAssets));
        }
    }

    public static void DoShit()
    {
        Dictionary<int, int> HashesToReplace = new Dictionary<int, int>();

        string[] guids = AssetDatabase.FindAssets("t:Prefab");

        List<GameObject> all = new List<GameObject>();
        foreach (string guid in guids)
        {
            GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guid));
            foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
            {
                all.Add(trans.gameObject);
            }
        }

        foreach (GameObject everything in all)
        {
            var comps = everything.GetComponents<Component>();
            if (comps != null && comps.Length > 0)
            {
                foreach (Component comp in comps)
                {
                    if (comp != null)
                    {
                        if (comp.GetType().Namespace != null)
                        {
                            if (comp.GetType().Namespace.Contains(Original))
                            {
                                Debug.Log($"there is a {comp.GetType().Namespace} on {everything.name}");

                                if (!HashesToReplace.ContainsKey(FileIDUtil.Compute(comp.GetType().Namespace, comp.GetType().Name)))
                                    HashesToReplace.Add(FileIDUtil.Compute(comp.GetType().Namespace, comp.GetType().Name), FileIDUtil.Compute(comp.GetType().Namespace.Replace(Original, New), comp.GetType().Name));
                            }
                        }
                    }
                }
            }
        }

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            string data = File.ReadAllText(path);

            foreach (int script in HashesToReplace.Keys)
            {
                while (data.Contains(script.ToString()))
                {
                    data = data.Replace(script.ToString(), HashesToReplace[script].ToString());
                }
            }

            File.WriteAllText(path, data);
        }
    }

    public static void DoShitScene()
    {
        Dictionary<int, int> HashesToReplace = new Dictionary<int, int>();
        List<GameObject> whar = new List<GameObject>();
        foreach (GameObject go in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
            {
                Debug.Log(trans.gameObject.name);
                whar.Add(trans.gameObject);
            }
        }

        foreach (GameObject everything in whar)
        {
            var comps = everything.GetComponents<Component>();
            if (comps != null && comps.Length > 0)
            {
                foreach (Component comp in comps)
                {
                    if (comp != null)
                    {
                        if (comp.GetType().Namespace != null)
                        {
                            Debug.Log(comp.GetType().Namespace);
                            if (comp.GetType().Namespace.Contains(Original))
                            {
                                Debug.Log($"there is a {comp.GetType().Namespace} on {everything.name}");

                                if (!HashesToReplace.ContainsKey(FileIDUtil.Compute(comp.GetType().Namespace, comp.GetType().Name)))
                                    HashesToReplace.Add(FileIDUtil.Compute(comp.GetType().Namespace, comp.GetType().Name), FileIDUtil.Compute(comp.GetType().Namespace.Replace(Original, New), comp.GetType().Name));
                            }
                        }
                    }
                }
            }
        }

        string data = File.ReadAllText(SceneManager.GetActiveScene().path);

        foreach (int script in HashesToReplace.Keys)
        {
            while (data.Contains(script.ToString()))
            {
                Debug.Log("CONTAINS!!!");
                data = data.Replace(script.ToString(), HashesToReplace[script].ToString());
            }
        }

        File.WriteAllText(SceneManager.GetActiveScene().path, data);
    }

    public static void DoShitSo(IEnumerable<ScriptableObject> sos)
    {
        foreach (ScriptableObject everything in sos)
        {
            if (everything.GetType().Namespace != null)
            {
                if (everything.GetType().Namespace.Contains(Original))
                {
                    Debug.Log("SO " + AssetDatabase.GetAssetPath(everything));
                    string data = File.ReadAllText(AssetDatabase.GetAssetPath(everything));
                    int original = FileIDUtil.Compute(everything.GetType().Namespace, everything.GetType().Name);
                    int newOne = FileIDUtil.Compute(everything.GetType().Namespace.Replace(Original, New), everything.GetType().Name);

                    while (data.Contains(original.ToString()))
                    {
                        Debug.Log("CONTAINS");
                        data = data.Replace(original.ToString(), newOne.ToString());
                    }

                    File.WriteAllText(AssetDatabase.GetAssetPath(everything), data);
                }
            }
        }
    }

    public class MD4 : HashAlgorithm
    {
        private uint _a;
        private uint _b;
        private uint _c;
        private uint _d;
        private uint[] _x;
        private int _bytesProcessed;

        public MD4()
        {
            _x = new uint[16];

            Initialize();
        }

        public override void Initialize()
        {
            _a = 0x67452301;
            _b = 0xefcdab89;
            _c = 0x98badcfe;
            _d = 0x10325476;

            _bytesProcessed = 0;
        }

        protected override void HashCore(byte[] array, int offset, int length)
        {
            ProcessMessage(Bytes(array, offset, length));
        }

        protected override byte[] HashFinal()
        {
            try
            {
                ProcessMessage(Padding());

                return new[] { _a, _b, _c, _d }.SelectMany(word => Bytes(word)).ToArray();
            }
            finally
            {
                Initialize();
            }
        }

        private void ProcessMessage(IEnumerable<byte> bytes)
        {
            foreach (byte b in bytes)
            {
                int c = _bytesProcessed & 63;
                int i = c >> 2;
                int s = (c & 3) << 3;

                _x[i] = (_x[i] & ~((uint)255 << s)) | ((uint)b << s);

                if (c == 63)
                {
                    Process16WordBlock();
                }

                _bytesProcessed++;
            }
        }

        private static IEnumerable<byte> Bytes(byte[] bytes, int offset, int length)
        {
            for (int i = offset; i < length; i++)
            {
                yield return bytes[i];
            }
        }

        private IEnumerable<byte> Bytes(uint word)
        {
            yield return (byte)(word & 255);
            yield return (byte)((word >> 8) & 255);
            yield return (byte)((word >> 16) & 255);
            yield return (byte)((word >> 24) & 255);
        }

        private IEnumerable<byte> Repeat(byte value, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return value;
            }
        }

        private IEnumerable<byte> Padding()
        {
            return Repeat(128, 1)
               .Concat(Repeat(0, ((_bytesProcessed + 8) & 0x7fffffc0) + 55 - _bytesProcessed))
               .Concat(Bytes((uint)_bytesProcessed << 3))
               .Concat(Repeat(0, 4));
        }

        private void Process16WordBlock()
        {
            uint aa = _a;
            uint bb = _b;
            uint cc = _c;
            uint dd = _d;

            foreach (int k in new[] { 0, 4, 8, 12 })
            {
                aa = Round1Operation(aa, bb, cc, dd, _x[k], 3);
                dd = Round1Operation(dd, aa, bb, cc, _x[k + 1], 7);
                cc = Round1Operation(cc, dd, aa, bb, _x[k + 2], 11);
                bb = Round1Operation(bb, cc, dd, aa, _x[k + 3], 19);
            }

            foreach (int k in new[] { 0, 1, 2, 3 })
            {
                aa = Round2Operation(aa, bb, cc, dd, _x[k], 3);
                dd = Round2Operation(dd, aa, bb, cc, _x[k + 4], 5);
                cc = Round2Operation(cc, dd, aa, bb, _x[k + 8], 9);
                bb = Round2Operation(bb, cc, dd, aa, _x[k + 12], 13);
            }

            foreach (int k in new[] { 0, 2, 1, 3 })
            {
                aa = Round3Operation(aa, bb, cc, dd, _x[k], 3);
                dd = Round3Operation(dd, aa, bb, cc, _x[k + 8], 9);
                cc = Round3Operation(cc, dd, aa, bb, _x[k + 4], 11);
                bb = Round3Operation(bb, cc, dd, aa, _x[k + 12], 15);
            }

            unchecked
            {
                _a += aa;
                _b += bb;
                _c += cc;
                _d += dd;
            }
        }

        private static uint ROL(uint value, int numberOfBits)
        {
            return (value << numberOfBits) | (value >> (32 - numberOfBits));
        }

        private static uint Round1Operation(uint a, uint b, uint c, uint d, uint xk, int s)
        {
            unchecked
            {
                return ROL(a + ((b & c) | (~b & d)) + xk, s);
            }
        }

        private static uint Round2Operation(uint a, uint b, uint c, uint d, uint xk, int s)
        {
            unchecked
            {
                return ROL(a + ((b & c) | (b & d) | (c & d)) + xk + 0x5a827999, s);
            }
        }

        private static uint Round3Operation(uint a, uint b, uint c, uint d, uint xk, int s)
        {
            unchecked
            {
                return ROL(a + (b ^ c ^ d) + xk + 0x6ed9eba1, s);
            }
        }
    }

    public static class FileIDUtil
    {
        public static int Compute(string Namespace, string Name)
        {
            string toBeHashed = "s\0\0\0" + Namespace + Name;

            using (HashAlgorithm hash = new MD4())
            {
                byte[] hashed = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(toBeHashed));

                int result = 0;

                for (int i = 3; i >= 0; --i)
                {
                    result <<= 8;
                    result |= hashed[i];
                }

                return result;
            }
        }
    }
}
