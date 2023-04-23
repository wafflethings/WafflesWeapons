using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using MeshCombineSet = System.Collections.Generic.List<LucasMeshCombine.MeshCombineData>;

namespace LucasMeshCombine
{
    public class MeshCombineManager : MonoBehaviour
    {
        [SerializeField] private Shader[] allowedShadersToBatch;
        [SerializeField] private Shader atlasedShader;
        [SerializeField] private Texture2D textureAtlas;

        public Shader[] AllowedShadersToBatch {get;set;}        public HashSet<MeshRenderer> ProcessedMeshRenderers {get;set;}
        public void AddCombineDatas(List<MeshCombineData> meshCombineDatas) { }        
        private void Start() { }    }
}