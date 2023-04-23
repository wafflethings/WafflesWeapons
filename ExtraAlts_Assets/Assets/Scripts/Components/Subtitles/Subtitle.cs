using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Subtitle : MonoBehaviour
{
    public AudioSource distanceCheckObject;
    public Subtitle nextInChain;
    [SerializeField] private float fadeInSpeed = 0.001f;
    [SerializeField] private float holdForBase = 2f;
    [SerializeField] private float holdForPerChar = 0.1f;
    [SerializeField] private float fadeOutSpeed = 0.0001f;
    [SerializeField] private float paddingHorizontal;
    [SerializeField] private Text uiText;

    private void OnEnable() { }
    public void ContinueChain() { }
    private void Update() { }}
