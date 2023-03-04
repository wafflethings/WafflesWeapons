using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Tram : MonoBehaviour
{

    public int maxSpeedStep;
    public int minSpeedStep;
    public float speedMultiplier;
    public Image[] speedIndicators;
    public float maxPlayerDistance;

    [Space] public TrainTrackPoint currentPoint;
    public TrainTrackPoint nextPoint;
    public TrainTrackPoint previousPoint;

    public GameObject bonkSound;

    public void ApplyPointRotation(TrainTrackPoint point, TrainTrackPoint next)
{}
    public void UpdateSpeedIndicators()
{}
    public void InstantStop()
{}
    public void TeleportTramToPoint(TrainTrackPoint point)
{}
    public void ShutDown()
{}
    public void TurnOn()
{}}
