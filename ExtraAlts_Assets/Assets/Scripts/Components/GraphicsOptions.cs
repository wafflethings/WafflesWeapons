using UnityEngine;
using UnityEngine.UI;

 
[ConfigureSingleton(SingletonFlags.NoAutoInstance)]
public class GraphicsOptions : MonoSingleton<GraphicsOptions>
{
    public Dropdown pixelization;
    public Slider textureWarping;
    public Dropdown vertexWarping;
    public Dropdown colorCompression;
    public Toggle vSync;
    public Slider dithering;
    public Toggle colorPalette;

	 
	void Start() { }
	public void ApplyPalette(Texture2D palette) { }
	public void PCPreset() { }
    public void PSXPreset() { }
	public void Initialize() { }
    public void Pixelization(int stuff) { }
    public void TextureWarping(float stuff) { }
    public void VertexWarping(int stuff) { }
    public void ColorCompression(int stuff) { }
	public void Dithering(float stuff) { }
	public void VSync(bool stuff) { }	
	public void ColorPalette(bool stuff) { }}
