using UnityEngine;
using System.Runtime.CompilerServices;

public static class ShaderProperties
{
    public static readonly int BaseMap = PrefixedPropertyToID();

    public static readonly int Color = PrefixedPropertyToID();

    public static readonly int MainTex = PrefixedPropertyToID();

    public static readonly int Cutoff = PrefixedPropertyToID();

    public static readonly int Glossiness = PrefixedPropertyToID();

    public static readonly int GlossMapScale = PrefixedPropertyToID();

    public static readonly int SmoothnessTextureChannel = PrefixedPropertyToID();

    public static readonly int Metallic = PrefixedPropertyToID();

    public static readonly int MetallicGlossMap = PrefixedPropertyToID();

    public static readonly int SpecularHighlights = PrefixedPropertyToID();

    public static readonly int GlossyReflections = PrefixedPropertyToID();

    public static readonly int BumpScale = PrefixedPropertyToID();

    public static readonly int BumpMap = PrefixedPropertyToID();

    public static readonly int Parallax = PrefixedPropertyToID();

    public static readonly int ParallaxMap = PrefixedPropertyToID();

    public static readonly int OcclusionStrength = PrefixedPropertyToID();

    public static readonly int OcclusionMap = PrefixedPropertyToID();

    public static readonly int EmissionColor = PrefixedPropertyToID();

    public static readonly int EmissionMap = PrefixedPropertyToID();

    public static readonly int DetailMask = PrefixedPropertyToID();

    public static readonly int DetailAlbedoMap = PrefixedPropertyToID();

    public static readonly int DetailNormalMapScale = PrefixedPropertyToID();

    public static readonly int DetailNormalMap = PrefixedPropertyToID();

    public static readonly int UVSec = PrefixedPropertyToID();

    public static readonly int Mode = PrefixedPropertyToID();

    public static readonly int SrcBlend = PrefixedPropertyToID();

    public static readonly int DstBlend = PrefixedPropertyToID();

    public static readonly int ZWrite = PrefixedPropertyToID();

    public static readonly int WorldSpaceCameraPos = PrefixedPropertyToID();

    public static readonly int ProjectionParams = PrefixedPropertyToID();

    public static readonly int ScreenParams = PrefixedPropertyToID();

    public static readonly int ZBufferParams = PrefixedPropertyToID();

    public static readonly int Time = PrefixedPropertyToID();

    public static readonly int SinTime = PrefixedPropertyToID();

    public static readonly int CosTime = PrefixedPropertyToID();

    public static readonly int LightColor0 = PrefixedPropertyToID();

    public static readonly int WorldSpaceLightPos0 = PrefixedPropertyToID();

    public static readonly int LightMatrix0 = PrefixedPropertyToID();

    public static readonly int TextureSampleAdd = PrefixedPropertyToID();

    /// <summary>SRP uses _BaseTex instead of _MainTex. This function aids in abstracting away this difference.</summary>
    public static int GetMainTexID(Material material) => material.HasProperty(BaseMap) ? BaseMap : MainTex;

    /// <summary>Convenience method for calling <see cref="Shader.PropertyToID(string)"/> based on the field name.</summary>
    public static int PrefixedPropertyToID(string prefix = "", [CallerMemberName] string name = null)
    {
        if (!name.StartsWith("_"))
            prefix += '_';

        return Shader.PropertyToID(prefix + name);
    }
}
