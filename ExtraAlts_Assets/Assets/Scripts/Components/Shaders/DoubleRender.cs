using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoubleRender : MonoBehaviour
{
	public List<int> subMeshesToIgnore = new List<int>();
	public Material radiantMat;
	public Renderer thisRend;
	public int shouldOutline;

     
    void Start() { }
	 
	void LateUpdate() { }
	public void OnDisable() { }
	public void RemoveEffect() { }
	public void SetOutline(int showOultine) { }}
