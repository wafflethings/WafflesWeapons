using System;
using System.Collections.Generic;
using System.Linq;
using plog;
using Sandbox;
using ULTRAKILL.Cheats;
using UnityEngine;
using UnityEngine.ProBuilder;

public static class SandboxUtils
{    public static void StripForPreview(Transform target, Material newMaterial = null, bool first = true)
    {
        Component[] components = target.GetComponents<Component>();
        int i;
        if (first)
        {
            Canvas[] componentsInChildren = target.GetComponentsInChildren<Canvas>(true);
            for (i = 0; i < componentsInChildren.Length; i++)
            {
                UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
            }
            List<Component> list = new List<Component>();
            list.AddRange(target.GetComponentsInChildren<Joint>(true));
            list.AddRange(target.GetComponentsInChildren<Sisyphus>(true));
            list.AddRange(target.GetComponentsInChildren<AudioDistortionFilter>(true));
            list.AddRange(target.GetComponentsInChildren<AudioHighPassFilter>(true));
            list.AddRange(target.GetComponentsInChildren<AudioLowPassFilter>(true));
            list.AddRange(target.GetComponentsInChildren<ProBuilderMesh>(true));
            foreach (Component obj in list)
            {
                UnityEngine.Object.Destroy(obj);
            }
        }
        BoxCollider boxCollider;
        if (!first && (target.GetComponent<RemoveOnTime>() || target.GetComponent<SpawnEffect>() || (target.TryGetComponent<BoxCollider>(out boxCollider) && boxCollider.isTrigger)))
        {
            UnityEngine.Object.Destroy(target.gameObject);
            return;
        }
        Component[] array = components;
        i = 0;
        while (i < array.Length)
        {
            Component component = array[i];
            if (!newMaterial)
            {
                goto IL_126;
            }
            Renderer renderer = component as Renderer;
            if (renderer == null)
            {
                goto IL_126;
            }
            renderer.materials = SandboxUtils.ToMaterialArray(newMaterial, renderer.materials.Length);
        IL_165:
            i++;
            continue;
        IL_126:
            if (!(component as Transform) && !(component as MeshFilter) && !(component as MeshRenderer) && !(component as SkinnedMeshRenderer))
            {
                UnityEngine.Object.Destroy(component);
                goto IL_165;
            }
            goto IL_165;
        }
        foreach (object obj2 in target.transform)
        {
            SandboxUtils.StripForPreview((Transform)obj2, newMaterial, false);
        }
    }
    public static SandboxSpawnableInstance GetProp(GameObject from, bool ignoreManipulationBlock = false)
    {
        SandboxSpawnableInstance sandboxSpawnableInstance = from.GetComponent<SandboxSpawnableInstance>();
        if (sandboxSpawnableInstance && !sandboxSpawnableInstance.enabled)
        {
            return null;
        }
        if (!sandboxSpawnableInstance)
        {
            SandboxPropPart component = from.GetComponent<SandboxPropPart>();
            if (component && component.parent)
            {
                sandboxSpawnableInstance = component.parent;
            }
        }
        if (!sandboxSpawnableInstance)
        {
            EnemyIdentifierIdentifier component2 = from.GetComponent<EnemyIdentifierIdentifier>();
            if (component2 && component2.eid)
            {
                sandboxSpawnableInstance = component2.eid.GetComponent<SandboxSpawnableInstance>();
                if (sandboxSpawnableInstance == null)
                {
                    sandboxSpawnableInstance = component2.eid.GetComponentInParent<SandboxSpawnableInstance>();
                }
            }
        }
        if (!sandboxSpawnableInstance)
        {
            EnemyIdentifier component3 = from.GetComponent<EnemyIdentifier>();
            if (component3)
            {
                sandboxSpawnableInstance = component3.GetComponentInParent<SandboxSpawnableInstance>();
            }
        }
        if (sandboxSpawnableInstance != null && sandboxSpawnableInstance.enabled && sandboxSpawnableInstance.collider != null && (!sandboxSpawnableInstance.disallowManipulation || ignoreManipulationBlock))
        {
            return sandboxSpawnableInstance;
        }
        return null;
    }
    public static void SetLayerDeep(Transform target, int layer)
    {
        target.gameObject.layer = layer;
        foreach (object obj in target.transform)
        {
            Transform transform = (Transform)obj;
            SandboxUtils.SetLayerDeep(transform, layer);
            OutdoorsChecker outdoorsChecker;
            if (transform.TryGetComponent<OutdoorsChecker>(out outdoorsChecker))
            {
                outdoorsChecker.CancelInvoke("SlowUpdate");
                outdoorsChecker.enabled = false;
            }
        }
    }
    private static Material[] ToMaterialArray(Material material, int length)
    {
        return Enumerable.Repeat<Material>(material, length).ToArray<Material>();
    }
    public static Vector3 SnapPos(Vector3 pos)
    {
        return SandboxUtils.SnapPos(pos, Vector3.zero, 0.5f);
    }
    public static Vector3 SnapPos(Vector3 pos, Vector3 offset, float snapDensity = 0.5f)
    {
        Vector3 vector = pos;
        vector *= snapDensity;
        vector = new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
        vector = new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
        vector /= snapDensity;
        vector += offset;
        return vector;
    }
    public static Vector3 SnapRotation(Vector3 rot)
    {
        float d = 45f;
        rot /= d;
        rot = new Vector3(Mathf.Round(rot.x), Mathf.Round(rot.y), Mathf.Round(rot.z));
        rot *= d;
        return rot;
    }
    public static Mesh GenerateProceduralMesh(Vector3 size, bool simple)
    {
        Vector3 zero = Vector3.zero;
        float num = 0.25f;
        float num2 = 1f;
        float num3 = size.x * size.y * size.z;
        if (num3 > 5000000f)
        {
            num *= 0.5f;
            num2 *= 2f;
        }
        if (num3 > 50000000f)
        {
            num *= 0.25f;
            num2 *= 4f;
        }
        if (num3 > 500000000f)
        {
            num *= 0.125f;
            num2 *= 8f;
        }
        Vector3 vector = size * num;
        List<Vector3> list = new List<Vector3>();
        List<int> list2 = new List<int>();
        List<Vector2> list3 = new List<Vector2>();
        if (simple)
        {
            Vector3 vector2 = zero;
            Vector3 vector3 = new Vector3(size.x, zero.y, zero.z);
            Vector3 vector4 = new Vector3(zero.x, size.y, zero.z);
            Vector3 vector5 = new Vector3(size.x, size.y, zero.z);
            Vector3 vector6 = new Vector3(zero.x, zero.y, size.z);
            Vector3 vector7 = new Vector3(size.x, zero.y, size.z);
            Vector3 vector8 = new Vector3(zero.x, size.y, size.z);
            SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
            {
                vector3,
                vector2,
                vector4,
                vector5
            }, true, new Vector2?(Vector2.zero), new Vector2?(new Vector2(size.x, size.y)), 0.05f);
            SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
            {
                vector7,
                vector3,
                vector5,
                size
            }, true, new Vector2?(Vector2.zero), new Vector2?(new Vector2(size.z, size.y)), 0.05f);
            SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
            {
                vector2,
                vector6,
                vector8,
                vector4
            }, true, new Vector2?(Vector2.zero), new Vector2?(new Vector2(size.z, size.y)), 0.05f);
            SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
            {
                vector6,
                vector7,
                size,
                vector8
            }, true, new Vector2?(Vector2.zero), new Vector2?(new Vector2(size.x, size.y)), 0.05f);
            SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
            {
                vector5,
                vector4,
                vector8,
                size
            }, true, new Vector2?(Vector2.zero), new Vector2?(new Vector2(size.x, size.z)), 0.05f);
            SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
            {
                vector7,
                vector6,
                vector2,
                vector3
            }, true, new Vector2?(Vector2.zero), new Vector2?(new Vector2(size.x, size.z)), 0.05f);
        }
        else
        {
            float num4 = 1f / num;
            int num5 = 0;
            while ((float)num5 < vector.x)
            {
                int num6 = 0;
                while ((float)num6 < vector.y)
                {
                    Vector3 vector9 = new Vector3(SandboxUtils.PolyClamp(zero.x, size.x, (float)num5, num4), SandboxUtils.PolyClamp(zero.y, size.y, (float)num6, num4), num4);
                    Vector3 vector10 = zero + new Vector3((float)num5, (float)num6, 0f) * num4;
                    Vector3 vector11 = vector10 + new Vector3(vector9.x, 0f, 0f);
                    Vector3 vector12 = vector10 + new Vector3(0f, vector9.y, 0f);
                    Vector3 vector13 = vector10 + new Vector3(vector9.x, vector9.y, 0f);
                    SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
                    {
                        vector11,
                        vector10,
                        vector12,
                        vector13
                    }, true, new Vector2?(new Vector2((float)num5, (float)num6)), new Vector2?(new Vector2(vector9.x, vector9.y) / num4), num2);
                    vector10 = new Vector3(zero.x, zero.y, size.z) + new Vector3((float)num5, (float)num6, 0f) * num4;
                    vector11 = vector10 + new Vector3(vector9.x, 0f, 0f);
                    vector12 = vector10 + new Vector3(0f, vector9.y, 0f);
                    vector13 = vector10 + new Vector3(vector9.x, vector9.y, 0f);
                    SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
                    {
                        vector10,
                        vector11,
                        vector13,
                        vector12
                    }, true, new Vector2?(new Vector2((float)num5 - vector9.x / num4, (float)num6)), new Vector2?(new Vector2(vector9.x, vector9.y) / num4), num2);
                    num6++;
                }
                int num7 = 0;
                while ((float)num7 < vector.z)
                {
                    Vector3 vector14 = new Vector3(SandboxUtils.PolyClamp(zero.x, size.x, (float)num5, num4), num4, SandboxUtils.PolyClamp(zero.z, size.z, (float)num7, num4));
                    Vector3 vector15 = new Vector3(zero.x, size.y, zero.z) + new Vector3((float)num5, 0f, (float)num7) * num4;
                    Vector3 vector16 = vector15 + new Vector3(vector14.x, 0f, 0f);
                    Vector3 vector17 = vector15 + new Vector3(0f, 0f, vector14.z);
                    Vector3 vector18 = vector15 + new Vector3(vector14.x, 0f, vector14.z);
                    SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
                    {
                        vector16,
                        vector15,
                        vector17,
                        vector18
                    }, true, new Vector2?(new Vector2((float)num5, (float)num7)), new Vector2?(new Vector2(vector14.x, vector14.z) / num4), num2);
                    vector15 = zero + new Vector3((float)num5, 0f, (float)num7) * num4;
                    vector16 = vector15 + new Vector3(vector14.x, 0f, 0f);
                    vector17 = vector15 + new Vector3(0f, 0f, vector14.z);
                    vector18 = vector15 + new Vector3(vector14.x, 0f, vector14.z);
                    SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
                    {
                        vector15,
                        vector16,
                        vector18,
                        vector17
                    }, true, new Vector2?(new Vector2((float)num5 - vector14.x / num4, (float)num7)), new Vector2?(new Vector2(vector14.x, vector14.z) / num4), num2);
                    num7++;
                }
                num5++;
            }
            int num8 = 0;
            while ((float)num8 < vector.z)
            {
                int num9 = 0;
                while ((float)num9 < vector.y)
                {
                    Vector3 vector19 = new Vector3(num4, SandboxUtils.PolyClamp(zero.y, size.y, (float)num9, num4), SandboxUtils.PolyClamp(zero.z, size.z, (float)num8, num4));
                    Vector3 vector20 = zero + new Vector3(0f, (float)num9, (float)num8) * num4;
                    Vector3 vector21 = vector20 + new Vector3(0f, 0f, vector19.z);
                    Vector3 vector22 = vector20 + new Vector3(0f, vector19.y, 0f);
                    Vector3 vector23 = vector20 + new Vector3(0f, vector19.y, vector19.z);
                    SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
                    {
                        vector20,
                        vector21,
                        vector23,
                        vector22
                    }, true, new Vector2?(new Vector2((float)num8 - vector19.z / num4, (float)num9)), new Vector2?(new Vector2(vector19.z, vector19.y) / num4), num2);
                    vector20 = new Vector3(size.x, zero.y, zero.z) + new Vector3(0f, (float)num9, (float)num8) * num4;
                    vector21 = vector20 + new Vector3(0f, 0f, vector19.z);
                    vector22 = vector20 + new Vector3(0f, vector19.y, 0f);
                    vector23 = vector20 + new Vector3(0f, vector19.y, vector19.z);
                    SandboxUtils.AddFaceToMesh(ref list, ref list2, ref list3, new Vector3[]
                    {
                        vector21,
                        vector20,
                        vector22,
                        vector23
                    }, true, new Vector2?(new Vector2((float)num8, (float)num9)), new Vector2?(new Vector2(vector19.z, vector19.y) / num4), num2);
                    num9++;
                }
                num8++;
            }
        }
        Mesh mesh = new Mesh();
        mesh.vertices = list.ToArray();
        mesh.triangles = list2.ToArray();
        mesh.uv = list3.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.RecalculateBounds();
        return mesh;
    }
    public static void AddFaceToMesh(ref List<Vector3> vertices, ref List<int> tris, ref List<Vector2> uvs, Vector3[] quadPoints, bool repeatUVs = false, Vector2? uvCords = null, Vector2? uvSizeMod = null, float uvScaleOverride = 1f)
    {
        if (quadPoints.Length < 4)
        {
            throw new Exception("Missing quad points");
        }
        Vector2 a = Vector2.zero;
        if (uvCords != null)
        {
            a = uvCords.Value;
        }
        Vector2 vector = Vector2.one;
        if (uvSizeMod != null)
        {
            vector = uvSizeMod.Value;
        }
        int count = vertices.Count;
        vertices.AddRange(new Vector3[]
        {
            quadPoints[0],
            quadPoints[1],
            quadPoints[2],
            quadPoints[3]
        });
        uvs.AddRange(new Vector2[]
        {
            (a + new Vector2(vector.x, 0f)) * uvScaleOverride,
            a * uvScaleOverride,
            (a + new Vector2(0f, vector.y)) * uvScaleOverride,
            (a + vector) * uvScaleOverride
        });
        tris.AddRange(new int[]
        {
            count,
            count + 1,
            count + 2,
            count + 2,
            count + 3,
            count
        });
    }
    public static float PolyClamp(float a, float b, float i, float units)
    {
        float num = a + i * units;
        float num2 = num + units;
        if (num2 > b)
        {
            return num2 - num - (num2 - b);
        }
        return units;
    }
    public static void SmallerBigger(Vector3 a, Vector3 b, out Vector3 smaller, out Vector3 bigger)
    {
        smaller = new Vector3((a.x > b.x) ? b.x : a.x, (a.y > b.y) ? b.y : a.y, (a.z > b.z) ? b.z : a.z);
        bigger = new Vector3((a.x > b.x) ? a.x : b.x, (a.y > b.y) ? a.y : b.y, (a.z > b.z) ? a.z : b.z);
    }
    public static GameObject CreateFinalBlock(SpawnableObject proceduralTemplate, Vector3 position, Vector3 size, bool liquid = false)
    {
        if (SandboxArmDebug.DebugActive)
        {
            SandboxUtils.Log.Info(string.Format("Creating block {0}", size), null, null, null);
        }
        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(proceduralTemplate.gameObject);
        gameObject.transform.position = position;
        BrushBlock component = gameObject.GetComponent<BrushBlock>();
        component.sourceObject = proceduralTemplate;
        component.DataSize = size;
        Mesh mesh = SandboxUtils.GenerateProceduralMesh(size, liquid);
        SandboxProp component2 = gameObject.GetComponent<SandboxProp>();
        component2.sourceObject = proceduralTemplate;
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        BoxCollider boxCollider = component.OverrideCollider ? component.OverrideCollider : gameObject.GetComponent<BoxCollider>();
        boxCollider.size = size;
        boxCollider.center = boxCollider.size / 2f;
        if (liquid)
        {
            GameObject gameObject2 = new GameObject("LiquidTrigger");
            gameObject2.layer = LayerMask.NameToLayer("SandboxGrabbable");
            gameObject2.transform.parent = gameObject.transform;
            gameObject2.transform.localPosition = Vector3.zero;
            gameObject2.transform.localRotation = Quaternion.identity;
            gameObject2.transform.localScale = Vector3.one;
            BoxCollider boxCollider2 = gameObject2.AddComponent<BoxCollider>();
            boxCollider2.isTrigger = true;
            boxCollider2.size = size;
            boxCollider2.center = boxCollider.size / 2f;
            component.WaterTrigger = boxCollider2;
            gameObject2.AddComponent<SandboxPropPart>().parent = component2;
        }
        return gameObject;
    }
    private static readonly plog.Logger Log = new plog.Logger("SandboxUtils");
    public const float SnapGrid = 0.5f;
    private const float MeshDensity = 0.25f;
    private const float UvScale = 1f;
    private const float PreviewBlockUvScale = 0.05f;
}
