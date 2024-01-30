using System.Linq;
using UnityEngine;
using Vertx.Debugging;

namespace Train
{
    public class Tram : MonoBehaviour
    {
        public bool poweredOn = true;
        private AudioSource aud;
        public GameObject bonkSound;
        
        public bool canGoForward { get; private set; }
        public bool canGoBackward { get; private set; }
        
        public float speed = 0f;
        public ConnectedTram[] connectedTrams;
        [Space]
        public TrainTrackPoint currentPoint;

        public TramPath currentPath;
        public TramMovementDirection movementDirection => speed > 0 ? TramMovementDirection.Forward : speed < 0 ? TramMovementDirection.Backward : TramMovementDirection.None;
        public float directionMod => speed > 0 ? 1 : -1;
        public float computedSpeed => speed * inheritedSpeedMultiplier;
        public float inheritedSpeedMultiplier => currentPath?.MaxSpeedMultiplier(movementDirection, speed) ?? 1f;
        public float backwardOffset => connectedTrams == null || connectedTrams.Length == 0 ? 0 : connectedTrams.Sum(tram => tram.offset);
        
        private ScreenZone[] screenActivators;
        

        public void TurnOn()
        {
            poweredOn = true;
            if (screenActivators != null && screenActivators.Length > 0)
            {
                foreach (ScreenZone sz in screenActivators)
                    sz.gameObject.SetActive(true);
            }
        }

        public void ShutDown()
        {
            poweredOn = false;
            if (screenActivators != null && screenActivators.Length > 0)
            {
                foreach (ScreenZone sz in screenActivators)
                {
                    ObjectActivator[] objas = sz.GetComponents<ObjectActivator>();

                    if (objas != null && objas.Length > 0)
                    {
                        foreach (ObjectActivator obja in objas)
                        {
                            if (obja.events.toActivateObjects != null && obja.events.toActivateObjects.Length > 0)
                            {
                                foreach (GameObject gob in obja.events.toActivateObjects)
                                    gob.SetActive(false);
                            }
                        }
                    }

                    sz.gameObject.SetActive(false);
                }
            }
        }

        public void StopAndTeleport(TrainTrackPoint point)
        {
            currentPoint = point;
            currentPath = null;
            speed = 0;
            
            var forward = currentPoint.GetDestination(forward: true);
            var backward = currentPoint.GetDestination(forward: false);
            
            TramPath path = null;

            if (forward)
            {
                path = new TramPath(currentPoint, forward);
            }
            else if (backward)
            {
                path = new TramPath(backward, currentPoint);
                path.distanceTravelled = path.DistanceTotal;
            }
            
            if (path != null)
            {
                currentPath = path;
                UpdateWorldRotation();

                foreach (var connectedTram in connectedTrams)
                {
                    connectedTram.UpdateTram(currentPath);
                }

                currentPath = null;
            }
        }
        
        private void Awake()
        {
            aud = GetComponent<AudioSource>();
            screenActivators = GetComponentsInChildren<ScreenZone>();
        }
    
        private void Update()
        {
            UpdateAudio();
        }

        private void FixedUpdate()
        {
            if (currentPath == null && currentPoint != null)
            {
                transform.position = currentPoint.transform.position;
                
                canGoForward = currentPoint.GetDestination(forward: true) != null;
                canGoBackward = currentPoint.GetDestination(forward: false) != null;
            }
            
            if (speed != 0)
            {
                // We're moving! AAAA

                if (currentPath == null && currentPoint != null)
                {
                    // We have to pick a path, augh
                    ReceiveNewPath();
                }

                if (currentPath != null)
                {
                    // and now we're moving for real
                    TraversePath();
                }
            }

            if (currentPath != null)
            {
                UpdateWorldPosition();
                if (movementDirection != TramMovementDirection.None) UpdateWorldRotation();
                DrawPathPreview();
                
                // Update connected pieces
                foreach (var connectedTram in connectedTrams)
                {
                    connectedTram.UpdateTram(currentPath);
                }
            }
        }

        private void DrawPathPreview()
        {
            if (!Debug.isDebugBuild) return;
            
            var drawSteps = 16;
            var lastPosition = transform.position;
            
            // Draw remaining path in blue, offset final D.raw up
            for (var i = 0; i < drawSteps; i++)
            {
                var progress = currentPath.Progress + ((float) i / drawSteps) * directionMod;
                var point = currentPath.GetPointOnPath(progress);
                        
                var baseOffset = Vector3.up * 1f;
                var line = new Shape.Line(a: lastPosition + baseOffset, b: point + baseOffset);

                var altOffset = baseOffset + new Vector3(0, 0.125f, 0);
                var altLine = new Shape.Line(a: lastPosition + altOffset, b: point + altOffset);
                        
                D.raw(line, Color.blue);
                D.raw(altLine, Color.blue);
                        
                lastPosition = point;
            }
        }

        private void TraversePath()
        {
            currentPath.distanceTravelled += computedSpeed * Time.deltaTime;

            var isAtEnd = IsAtEndOfPath();
            if (!isAtEnd)
            {
                canGoForward = true;
                canGoBackward = true;
                return;
            }


            var leftovers = currentPath.distanceTravelled;
            if (movementDirection == TramMovementDirection.Forward) leftovers -= currentPath.DistanceTotal;
            
            // Special case for chained trams reaching the backward end with their offset
            if (movementDirection == TramMovementDirection.Backward && backwardOffset != 0)
            {
                if (currentPath.IsDeadEnd(movementDirection))
                {
                    speed = 0;
                    canGoBackward = false;
                    // BONK
                    Instantiate(bonkSound, transform.position, Quaternion.identity);
                    return;
                }
            }
            
            // Normal
            currentPoint = movementDirection == TramMovementDirection.Forward
                ? currentPath.end
                : currentPath.start;
            if (currentPoint != null) Debug.Log($"Reached {currentPoint.gameObject.name}");
            currentPath = null;
            ReceiveNewPath();

            if (currentPath != null)
            {
                Debug.Log($"New path: {currentPath.PrintPathDirectional(movementDirection)}");
                currentPath.distanceTravelled += leftovers;

                if (movementDirection == TramMovementDirection.Forward) canGoForward = true;
                else canGoBackward = true;
            }
            else
            {
                if (currentPoint.stopBehaviour == StopBehaviour.InstantClank)
                    Instantiate(bonkSound, transform.position, Quaternion.identity);
                if (movementDirection == TramMovementDirection.Forward) canGoForward = false;
                else canGoBackward = false;

                speed = 0;
            }
        }

        private bool IsAtEndOfPath()
        {
            if (currentPath == null) return false;

            var effectiveEnd = currentPath.DistanceTotal;
            var effectiveStart = 0f;

            // I'll touch this in the future
            // if (movementDirection == TramMovementDirection.Forward && forwardOffset.HasValue)
            // {
            //     effectiveEnd -= forwardOffset.Value;
            // }
            // else 
            if (movementDirection == TramMovementDirection.Backward && backwardOffset != 0)
            {
                // is this a dead end
                if (currentPath.start.GetDestination(forward: false) == null)
                {
                    effectiveStart += backwardOffset;
                }
            }

            return (movementDirection == TramMovementDirection.Forward) ? currentPath.distanceTravelled >= effectiveEnd : currentPath.distanceTravelled <= effectiveStart;
        }


        public void UpdateWorldPosition()
        {
            if (currentPath == null) return;
            var position = currentPath.GetPointOnPath(currentPath.Progress);
            transform.position = position;
        }

        public void UpdateWorldRotation()
        {
            if (currentPath == null) return;
            // rotate around Y axis
            var rotation = currentPath.MovementDirection();
            var newRotation = Quaternion.LookRotation(rotation, Vector3.up);
            transform.rotation = newRotation;
        }

        private void ReceiveNewPath()
        {
            if (currentPoint == null) return;

            var goingForward = movementDirection == TramMovementDirection.Forward;
            var destination = currentPoint.GetDestination(goingForward);
            if (destination == null) return;
            var startPoint = goingForward ? currentPoint : destination;
            var endPoint = goingForward ? destination : currentPoint;
            
            var newPath = new TramPath(startPoint, endPoint);
            if (!goingForward)
            {
                newPath.distanceTravelled = newPath.DistanceTotal;
            }

            currentPath = newPath;
            currentPoint = null;
        }

        private void UpdateAudio()
        {
            if (computedSpeed != 0 && !aud.isPlaying)
                aud.Play();
            else if (computedSpeed == 0 && aud.isPlaying)
                aud.Stop();

            float targetLevel = 0;

            if (Mathf.Abs(computedSpeed) >= 50f)
                targetLevel = 1;
            else
                targetLevel = Mathf.Abs(computedSpeed) * (1f / 50f);

            aud.volume = targetLevel;
            aud.pitch = targetLevel * 2;
        }
    }
    
    public enum TramMovementDirection { Forward, Backward, None }
}

