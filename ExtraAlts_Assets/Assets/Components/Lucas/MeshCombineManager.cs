using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace LucasMeshCombine
{
    public class MeshCombineManager : MonoBehaviour
    {
        [SerializeField] private Shader[] allowedShadersToBatch;
        [SerializeField] private Shader atlasedShader;
        [SerializeField] private Texture2D textureAtlas;
    }
}