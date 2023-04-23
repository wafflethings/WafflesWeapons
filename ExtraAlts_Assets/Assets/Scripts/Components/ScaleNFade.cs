using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FadeType
{
    Sprite,
    Line,
    Light,
    Renderer
};

public class ScaleNFade : MonoBehaviour {

    public bool scale;
    public bool fade;
    public FadeType ft;

    public float scaleSpeed;
    public float fadeSpeed;

    public bool dontDestroyOnZero;
    

	 
	void Start () {}	
	 
	void Update () {}
    private void FixedUpdate() { }}
