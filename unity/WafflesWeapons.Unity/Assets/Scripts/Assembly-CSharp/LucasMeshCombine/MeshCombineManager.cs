using System.Collections.Generic;
using UnityEngine;

namespace LucasMeshCombine
{
	public class MeshCombineManager : MonoBehaviour
	{
		[SerializeField]
		private Shader[] allowedShadersToBatch;

		[SerializeField]
		private Shader atlasedShader;

		[SerializeField]
		private Texture2D textureAtlas;

		private readonly Dictionary<Mesh, Vector4[]> oldMeshUvs;

		private readonly List<List<MeshCombineData>> combineSets;

		private readonly List<Texture2D> textures;

		private readonly HashSet<MeshRenderer> processedMeshRenderers;

		private readonly List<Mesh> createdMeshes;

		private readonly List<GameObject> createdObjects;

		private Material combinedMeshMaterial;

		public static MeshCombineManager Instance { get; private set; }

		public Shader[] AllowedShadersToBatch => null;

		public HashSet<MeshRenderer> ProcessedMeshRenderers => null;

		public void AddCombineDatas(List<MeshCombineData> meshCombineDatas)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
