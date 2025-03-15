using System.Runtime.CompilerServices;
using UnityEngine;

public static class ShaderProperties
{
	public static readonly int BaseMap;

	public static readonly int Color;

	public static readonly int MainTex;

	public static readonly int Cutoff;

	public static readonly int Glossiness;

	public static readonly int GlossMapScale;

	public static readonly int SmoothnessTextureChannel;

	public static readonly int Metallic;

	public static readonly int MetallicGlossMap;

	public static readonly int SpecularHighlights;

	public static readonly int GlossyReflections;

	public static readonly int BumpScale;

	public static readonly int BumpMap;

	public static readonly int Parallax;

	public static readonly int ParallaxMap;

	public static readonly int OcclusionStrength;

	public static readonly int OcclusionMap;

	public static readonly int EmissionColor;

	public static readonly int EmissionMap;

	public static readonly int DetailMask;

	public static readonly int DetailAlbedoMap;

	public static readonly int DetailNormalMapScale;

	public static readonly int DetailNormalMap;

	public static readonly int UVSec;

	public static readonly int Mode;

	public static readonly int SrcBlend;

	public static readonly int DstBlend;

	public static readonly int ZWrite;

	public static readonly int WorldSpaceCameraPos;

	public static readonly int ProjectionParams;

	public static readonly int ScreenParams;

	public static readonly int ZBufferParams;

	public static readonly int Time;

	public static readonly int SinTime;

	public static readonly int CosTime;

	public static readonly int LightColor0;

	public static readonly int WorldSpaceLightPos0;

	public static readonly int LightMatrix0;

	public static readonly int TextureSampleAdd;

	public static readonly int OpacScale;

	public static readonly int SurfaceType;

	public static readonly int SecondarySurfaceType;

	public static readonly int EnviroParticleColor;

	public static readonly int SecondaryEnviroParticleColor;

	public static int GetMainTexID(Material material)
	{
		return 0;
	}

	public static int PrefixedPropertyToID(string prefix = "", [CallerMemberName] string name = null)
	{
		return 0;
	}
}
