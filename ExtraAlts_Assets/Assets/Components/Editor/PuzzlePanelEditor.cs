using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(PuzzlePanel))]
public class PuzzlePanelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        var host = (PuzzlePanel)target;
        var selected = EditorGUILayout.Popup("Tile", (int)host.tileType, new string[] { "Empty", "Start", "End", "Fill", "Pit" });
        var color = EditorGUILayout.Popup("Tile", (int)host.tileColor, new string[] { "White", "Red", "Green", "Blue" });

        if (selected != (int)host.tileType)
        {
            if (host.currentPanel != null)
                DestroyImmediate(host.currentPanel);

            switch (selected)
            {
                case 1:
                    host.currentPanel = Instantiate(host.whiteSquare, host.transform);
                    break;
                case 2:
                    host.currentPanel = Instantiate(host.blackSquare, host.transform);
                    break;
                case 3:
                    host.currentPanel = Instantiate(host.fillSquare, host.transform);
                    break;
                case 4:
                    host.currentPanel = Instantiate(host.pitSquare, host.transform);
                    break;
            }

            host.tileType = (TileType)selected;
        }

        if (color != (int)host.tileColor)
        {
            Image[] imgs = host.GetComponentsInChildren<Image>();

            switch (color) {
                case 0:
                    foreach (Image img in imgs) if (img.gameObject != host.gameObject) img.color = Color.white;
                    break;
                case 1:
                    foreach (Image img in imgs) if (img.gameObject != host.gameObject) img.color = Color.red;
                    break;
                case 2:
                    foreach (Image img in imgs) if (img.gameObject != host.gameObject) img.color = Color.green;
                    break;
                case 3:
                    foreach (Image img in imgs) if (img.gameObject != host.gameObject) img.color = new Color(0, 0.25f, 1);
                    break;
            }

            host.tileColor = (TileColor)color;
        }
    }
}
