using System;
using UnityEngine;
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

    private void Start() { }
    public void ApplyPointRotation(TrainTrackPoint point, TrainTrackPoint next) { }
    void StopTram(TrainTrackPoint point) { }
    void CheckIfArrived() { }
    void MoveTram() { }
    private void FixedUpdate() { }    
    private void OnGUI() { }
    public void UpdateSpeedIndicators() { }
    public void InstantStop() { }
    public void TeleportTramToPoint(TrainTrackPoint point) { }
    public void ShutDown() { }
    public void TurnOn() { }}
