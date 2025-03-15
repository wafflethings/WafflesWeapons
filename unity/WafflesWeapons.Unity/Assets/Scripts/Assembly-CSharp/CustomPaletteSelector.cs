using UnityEngine;
using UnityEngine.UI;

public class CustomPaletteSelector : MonoBehaviour
{
	[Space]
	[SerializeField]
	private GameObject menu;

	[SerializeField]
	private Transform container;

	[Space]
	[SerializeField]
	private Image templatePreviewImage;

	[SerializeField]
	private Text templateFileName;

	[SerializeField]
	private Button buttonTemplate;

	[Space]
	[SerializeField]
	private Image previewImage;

	private static string PalettePath => null;

	private static void Init()
	{
	}

	private void ResetMenu()
	{
	}

	private void RefreshCurrentPreview()
	{
	}

	public void ShowMenu()
	{
	}

	private void BuildMenu()
	{
	}

	private void SetGamePalette(Texture2D txt, string name)
	{
	}

	private static Texture2D LoadPalette(string name)
	{
		return null;
	}

	public static Texture2D LoadSavedPalette()
	{
		return null;
	}
}
