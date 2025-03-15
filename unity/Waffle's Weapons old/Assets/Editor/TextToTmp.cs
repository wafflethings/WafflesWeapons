﻿//https://gist.github.com/NicholasSheehan/0c5b690e246e72b7f5558c64b83c2150, edits from me :3
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

class TextToTmp : EditorWindow
{
    public static TMP_FontAsset font;
    [MenuItem("Ultracrypt Extensions/Other/Replace Text Component With Text Mesh Pro")]
    public static void Init()
    {
        GetWindow<TextToTmp>().Show();
    }

    void OnGUI()
    {
        GUILayout.Label("waffle text => tmp replacer :3", EditorStyles.boldLabel);

        font = EditorGUILayout.ObjectField("font asset", font, typeof(TMP_FontAsset), false) as TMP_FontAsset;

        if (GUILayout.Button("replace all"))
        {
            Replace();
        }
    }

    static void Replace()
    {
        GameObject[] selectedObjects = Selection.gameObjects.Where(
            go => !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave)).ToArray();

        Undo.RecordObjects(selectedObjects, "Replace Text Component with Text Mesh Pro Component");

        foreach (var selectedObject in selectedObjects)
        {
            Debug.Log("GAMEOBJECT " + selectedObject.name);
            foreach (Text textComp in selectedObject.GetComponentsInChildren<Text>(true))
            {
                Debug.Log("TEXT " + textComp.name);
                GameObject go = textComp.gameObject;
                var textSizeDelta = textComp.rectTransform.sizeDelta;
                //text component is still alive in memory, so the settings are still intact
                Undo.DestroyObjectImmediate(textComp);

                var tmp = Undo.AddComponent<TextMeshProUGUI>(go);

                tmp.text = textComp.text;

                tmp.fontSize = textComp.fontSize;

                var fontStyle = textComp.fontStyle;
                switch (fontStyle)
                {
                    case FontStyle.Normal:
                        tmp.fontStyle = FontStyles.Normal;
                        break;
                    case FontStyle.Bold:
                        tmp.fontStyle = FontStyles.Bold;
                        break;
                    case FontStyle.Italic:
                        tmp.fontStyle = FontStyles.Italic;
                        break;
                    case FontStyle.BoldAndItalic:
                        tmp.fontStyle = FontStyles.Bold | FontStyles.Italic;
                        break;
                }

                tmp.enableAutoSizing = textComp.resizeTextForBestFit;
                tmp.fontSizeMin = textComp.resizeTextMinSize;
                tmp.fontSizeMax = textComp.resizeTextMaxSize;

                var alignment = textComp.alignment;
                switch (alignment)
                {
                    case TextAnchor.UpperLeft:
                        tmp.alignment = TextAlignmentOptions.TopLeft;
                        break;
                    case TextAnchor.UpperCenter:
                        tmp.alignment = TextAlignmentOptions.Top;
                        break;
                    case TextAnchor.UpperRight:
                        tmp.alignment = TextAlignmentOptions.TopRight;
                        break;
                    case TextAnchor.MiddleLeft:
                        tmp.alignment = TextAlignmentOptions.MidlineLeft;
                        break;
                    case TextAnchor.MiddleCenter:
                        tmp.alignment = TextAlignmentOptions.Midline;
                        break;
                    case TextAnchor.MiddleRight:
                        tmp.alignment = TextAlignmentOptions.MidlineRight;
                        break;
                    case TextAnchor.LowerLeft:
                        tmp.alignment = TextAlignmentOptions.BottomLeft;
                        break;
                    case TextAnchor.LowerCenter:
                        tmp.alignment = TextAlignmentOptions.Bottom;
                        break;
                    case TextAnchor.LowerRight:
                        tmp.alignment = TextAlignmentOptions.BottomRight;
                        break;
                }

                tmp.enableWordWrapping = textComp.horizontalOverflow == HorizontalWrapMode.Wrap;

                tmp.color = textComp.color;
                tmp.raycastTarget = textComp.raycastTarget;
                tmp.richText = textComp.supportRichText;

                tmp.rectTransform.sizeDelta = textSizeDelta;

                tmp.font = font;
            }
        }
    }
}