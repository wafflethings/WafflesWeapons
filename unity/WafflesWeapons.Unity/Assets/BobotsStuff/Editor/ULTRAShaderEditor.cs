using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

//[CanEditMultipleObjects]
public class ULTRAShaderEditor : ShaderGUI 
{

    
    public enum BlendMode
    {
        Opaque,
        Cutout,
        Transparent,
        Advanced,
    }
    
    public bool HandleShowIf(string attribute, Material material)
    {
        
        if (attribute == "ERROR")
            return true;

        var regexMatch = Regex.Match(attribute, "ShowIf\\((?'variable'\\w*)\\((?'values'(\\d|,|\\s)*)\\)");
        string variable = regexMatch.Groups["variable"].Value;
        string values = regexMatch.Groups["values"].Value.Replace(" ", "");

        if (regexMatch.Success)
        {
            
            if (!material.HasFloat(variable))
                return false;
            
            var splitValues = values.Split(',');

            foreach (var value in splitValues)
            {
                if (float.TryParse(value, out float parsedValue) && Mathf.Approximately(parsedValue, material.GetFloat(variable)))
                    return true;
            }
        }
        else
        {
            regexMatch = Regex.Match(attribute, "ShowIf\\((?'variable'\\w*)");
            variable = regexMatch.Groups["variable"].Value;
            
            
            if (material.HasFloat(variable) && material.GetFloat(variable) > 0.1f)
                return true;

        }
        
        return false;

    }

    static void MaterialChanged(Material material, BlendMode blendMode)
    {
        bool useVertexLighting = material.GetFloat("_VertexLighting") > 0.1f;
        
        material.SetOverrideTag("PassFlags", useVertexLighting ? "" : "OnlyDirectional");
        
        if (useVertexLighting)
        {
            material.EnableKeyword("VERTEX_LIGHTING");
        }
        else
        {
            material.DisableKeyword("VERTEX_LIGHTING");
        }

        switch (blendMode)
        {
            case BlendMode.Opaque:
                material.SetOverrideTag("RenderType", "Opaque");
                material.SetFloat("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetFloat("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetFloat("_ZWrite", 1);
                
                material.DisableKeyword("ALPHA_TEST");
                material.DisableKeyword("TRANSPARENCY");
                
                material.renderQueue = -1;
                break;
            
            
            
            case BlendMode.Cutout:
                material.SetOverrideTag("RenderType", "TransparentCutout");
                material.SetFloat("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetFloat("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetFloat("_ZWrite", 1);
                                
                material.EnableKeyword("ALPHA_TEST");
                material.DisableKeyword("TRANSPARENCY");

                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.AlphaTest;
                break;
            case BlendMode.Transparent:
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                                                
                material.DisableKeyword("ALPHA_TEST");
                material.EnableKeyword("TRANSPARENCY");

                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                break;
            
            case BlendMode.Advanced:
                material.SetOverrideTag("RenderType", "Transparent");
                
                material.DisableKeyword("ALPHA_TEST");
                material.EnableKeyword("TRANSPARENCY");


                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                break;
        }
    }
    
    public override void OnGUI (MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        if (materialEditor.targets.Length > 1)
        {
            EditorGUILayout.HelpBox("Ill be honest making this thing support editing multiple materials at once is a huge pain in the ass so ive just hard coded it to not because trying to would break it, sorry for the inconvenience", MessageType.Error);
            //
            if (GUILayout.Button("click me if you just assigned multiple materials to the master shader"))
            {
                foreach (var target in materialEditor.targets)
                {
                    Material targetMat = target as Material;
                    MaterialChanged(targetMat, (BlendMode)targetMat.GetFloat("_BlendMode"));
                }
            }
            
            return;
        }

        foreach (var target in materialEditor.targets)
        {

            bool blendModeChanged = false;
            bool inFoldout = false;
            string currentFoldout = "";
            Material targetMat = target as Material;
        
                    
            //EditorGUILayout.LabelField(targetMat.renderQueue.ToString(), new GUIStyle("AM HeaderStyle"));
        
            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
            
                var attributes = targetMat.shader.GetPropertyAttributes(i);
            
            
                /*
             * UltraCategory X (i hope...)
             * UltraHeader X (i hope...)
             * EndUltraHeader X (i hope...)
             * ShowIf
             * HelpBox X
             * KeywordToggle X
             * Keyword X
             * ShowRenderQueue X
             */
            
                var targetAttribute = attributes.Any(x => x.StartsWith("ShowIf")) ? attributes.First(x => x.StartsWith("ShowIf")) : "ERROR";

           


                bool drawProperty = HandleShowIf(targetAttribute, targetMat);
                bool drawPropertyOverride = drawProperty;

                
                //if (targetAttribute != "ERROR")
                //    EditorGUILayout.LabelField(drawProperty.ToString(), new GUIStyle("AM HeaderStyle"));

                //drawProperty = true;
            
                foreach (string attribute in attributes)
                {
                
                    if (attribute.StartsWith("ShowRenderQueue") && drawProperty && (currentFoldout != "" && targetMat.GetFloat(currentFoldout) > 0.1f))
                    {
                        drawProperty = false;
                        materialEditor.RenderQueueField();
                    }
                    
                    /*if (attribute.StartsWith("UltraHeader") && drawProperty && (currentFoldout != "" && targetMat.GetFloat(currentFoldout) > 0.1f))
                    {

                        //drawProperty = false;
                        //CurveEditorBackground
                        EditorGUILayout.LabelField(property.displayName, new GUIStyle("AM HeaderStyle"));

                        GUILayout.BeginHorizontal(new GUIStyle("GroupBox"));
                        GUILayout.Space(18);
                        GUILayout.BeginVertical();

                    }

                    if (attribute.StartsWith("EndUltraHeader") && drawProperty && (currentFoldout != "" && targetMat.GetFloat(currentFoldout) > 0.1f))
                    {

                        //End Indent level
                        GUILayout.EndVertical();
                        GUILayout.EndHorizontal();
                    }*/
                
                    if (attribute.StartsWith("UltraCategory"))
                    {

                        if (inFoldout)
                        {
                            EditorGUILayout.EndFoldoutHeaderGroup();
                        }
                    
                        inFoldout = true;
                        drawProperty = false;
                        currentFoldout = property.name;
                    
                        bool value = (property.floatValue != 0.0f);
                    
                    
                        EditorGUI.BeginChangeCheck();
                    
                        value = EditorGUILayout.BeginFoldoutHeaderGroup(value, property.displayName);
                    
                        if (EditorGUI.EndChangeCheck())
                        {
                            property.floatValue = value ? 1.0f : 0.0f;
                        }
                    }
                
                
                    if (attribute.StartsWith("Keyword") && !attribute.StartsWith("KeywordToggle") && !attribute.StartsWith("KeywordEnum"))
                    {
                        var regexMatch = Regex.Match(attribute, "Keyword\\((?'keyword'.*)\\)");
        
                        string attributekeyword = regexMatch.Groups["keyword"].Value.Replace(" ", "");
                    
                        var keywords = attributekeyword.Split(',');
                    
                        drawProperty = false;
                    
                        foreach (string keyword in keywords)
                        {
                            if (targetMat.IsKeywordEnabled(keyword))
                            {
                                drawProperty = true;
                                break;
                            }
                        }
                    }

                    if (attribute.StartsWith("HelpBox") && drawProperty && (currentFoldout != "" && targetMat.GetFloat(currentFoldout) > 0.1f))
                    {
                        EditorGUILayout.HelpBox(property.displayName, MessageType.Info);
                        drawProperty = false;
                    }
                
                    if (!drawPropertyOverride)
                        drawProperty = false;
                }
            
            
            
                if (drawProperty && (currentFoldout != "" && targetMat.GetFloat(currentFoldout) > 0.1f))
                {
                    materialEditor.ShaderProperty(property, property.displayName); 
                

                }
                
                MaterialChanged(targetMat, (BlendMode)targetMat.GetFloat("_BlendMode"));
            }
        }

        //base.OnGUI (materialEditor, properties);
    }
}

/*
public class UltraCategoryDrawer : MaterialPropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI (Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {

    }
}

public class UltraHeaderDrawer : MaterialPropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI (Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {
       
    }
}

public class HelpBoxDrawer : MaterialPropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI (Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {
        EditorGUI.HelpBox(position, label, MessageType.Info);
    }
}




public class EndUltraHeaderDrawer : MaterialPropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI (Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {
        EditorGUI.EndFoldoutHeaderGroup();
    }
}



public class ShowIfDrawer : MaterialPropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI (Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {

    }
}


public class KeywordDrawer : MaterialPropertyDrawer
{
    
    private readonly string[] keywords;
    public KeywordDrawer(params string[] keywords)
    {
        this.keywords = keywords;
    }
    
    // Draw the property inside the given rect
    public override void OnGUI (Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {
        Material targetMat = editor.target as Material;
        bool drawProperty = false;
        
        foreach (string keyword in keywords)
        {
            if (targetMat.IsKeywordEnabled(keyword))
            {
                drawProperty = true;
                break;
            }
        }
        
        if (!drawProperty)
            return;
        
        base.OnGUI (position, prop, label, editor);
    }
}

*/
public class KeywordToggleDrawer : MaterialPropertyDrawer
{
    // Draw the property inside the given rect
    public override void OnGUI (Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {
        // Setup
        bool value = (prop.floatValue != 0.0f);

        EditorGUI.BeginChangeCheck();

        var regexMatch = Regex.Match(label, "Name\\((?'name'.*)\\) Tooltip\\((?'tooltip'.*)\\)");
        
        string propertyName = regexMatch.Groups["name"].Value;
        string propertyTooltip = regexMatch.Groups["tooltip"].Value;
        
        Material targetMat = editor.target as Material;
        
        // Show the toggle control
        value = EditorGUI.Toggle(position, new GUIContent(propertyName, propertyTooltip), value);

        if (EditorGUI.EndChangeCheck())
        {
            prop.floatValue = value ? 1.0f : 0.0f;
            
            if (value)
                targetMat.EnableKeyword(prop.name);
            else
                targetMat.DisableKeyword(prop.name);
        }
    }
}

