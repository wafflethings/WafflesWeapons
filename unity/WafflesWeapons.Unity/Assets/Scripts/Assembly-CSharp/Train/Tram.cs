using System.Linq;
using UnityEngine;

namespace Train
{    public class Tram : MonoBehaviour
    {        // (get) Token: 0x060019F5 RID: 6645 RVA: 0x000E9359 File Offset: 0x000E7559
        // (set) Token: 0x060019F6 RID: 6646 RVA: 0x000E9361 File Offset: 0x000E7561
        public bool canGoForward { get; private set; }
        // (get) Token: 0x060019F7 RID: 6647 RVA: 0x000E936A File Offset: 0x000E756A
        // (set) Token: 0x060019F8 RID: 6648 RVA: 0x000E9372 File Offset: 0x000E7572
        public bool canGoBackward { get; private set; }
        // (get) Token: 0x060019F9 RID: 6649 RVA: 0x000E937B File Offset: 0x000E757B
        public TramMovementDirection movementDirection
        {
            get
            {
                if (this.speed > 0f)
                {
                    return TramMovementDirection.Forward;
                }
                if (this.speed >= 0f)
                {
                    return TramMovementDirection.None;
                }
                return TramMovementDirection.Backward;
            }
        }
        // (get) Token: 0x060019FA RID: 6650 RVA: 0x000E939C File Offset: 0x000E759C
        public float directionMod
        {
            get
            {
                return (float)((this.speed > 0f) ? 1 : -1);
            }
        }
        // (get) Token: 0x060019FB RID: 6651 RVA: 0x000E93B0 File Offset: 0x000E75B0
        public float computedSpeed
        {
            get
            {
                return this.speed * this.inheritedSpeedMultiplier;
            }
        }
        // (get) Token: 0x060019FC RID: 6652 RVA: 0x000E93C0 File Offset: 0x000E75C0
        public float inheritedSpeedMultiplier
        {
            get
            {
                if (this.zapAmount > 0f)
                {
                    TramPath tramPath = this.currentPath;
                    return Mathf.Lerp((tramPath != null) ? tramPath.MaxSpeedMultiplier(this.movementDirection, this.speed) : 1f, 2f, this.zapAmount);
                }
                TramPath tramPath2 = this.currentPath;
                if (tramPath2 == null)
                {
                    return 1f;
                }
                return tramPath2.MaxSpeedMultiplier(this.movementDirection, this.speed);
            }
        }
        // (get) Token: 0x060019FD RID: 6653 RVA: 0x000E9430 File Offset: 0x000E7630
        public float backwardOffset
        {
            get
            {
                if (this.connectedTrams != null && this.connectedTrams.Length != 0)
                {
                    return this.connectedTrams.Sum((ConnectedTram tram) => tram.offset);
                }
                return 0f;
            }
        }
        public void TurnOn()
        {
            this.poweredOn = true;
            if (this.screenActivators != null && this.screenActivators.Length != 0)
            {
                ScreenZone[] array = this.screenActivators;
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].gameObject.SetActive(true);
                }
            }
        }
        public void ShutDown()
        {
            this.poweredOn = false;
            if (this.screenActivators != null && this.screenActivators.Length != 0)
            {
                foreach (ScreenZone screenZone in this.screenActivators)
                {
                    ObjectActivator[] components = screenZone.GetComponents<ObjectActivator>();
                    if (components != null && components.Length != 0)
                    {
                        foreach (ObjectActivator objectActivator in components)
                        {
                            if (objectActivator.events.toActivateObjects != null && objectActivator.events.toActivateObjects.Length != 0)
                            {
                                GameObject[] toActivateObjects = objectActivator.events.toActivateObjects;
                                for (int k = 0; k < toActivateObjects.Length; k++)
                                {
                                    toActivateObjects[k].SetActive(false);
                                }
                            }
                        }
                    }
                    screenZone.gameObject.SetActive(false);
                }
            }
        }
        public void StopAndTeleport(TrainTrackPoint point)
        {
            this.currentPoint = point;
            this.currentPath = null;
            this.speed = 0f;
            TrainTrackPoint destination = this.currentPoint.GetDestination(true);
            TrainTrackPoint destination2 = this.currentPoint.GetDestination(false);
            TramPath tramPath = null;
            if (destination)
            {
                tramPath = new TramPath(this.currentPoint, destination);
            }
            else if (destination2)
            {
                tramPath = new TramPath(destination2, this.currentPoint);
                tramPath.distanceTravelled = tramPath.DistanceTotal;
            }
            if (tramPath != null)
            {
                this.currentPath = tramPath;
                this.UpdateWorldRotation();
                ConnectedTram[] array = this.connectedTrams;
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].UpdateTram(this.currentPath);
                }
                this.currentPath = null;
            }
        }
        private void Awake()
        {
            this.aud = base.GetComponent<AudioSource>();
            this.screenActivators = base.GetComponentsInChildren<ScreenZone>();
            this.rb = base.GetComponent<Rigidbody>();
        }
        private void Update()
        {
            this.UpdateAudio();
        }
        private void FixedUpdate()
        {
            if (this.currentPath == null && this.currentPoint != null)
            {
                this.rb.MovePosition(this.currentPoint.transform.position);
                this.canGoForward = (this.currentPoint.GetDestination(true) != null);
                this.canGoBackward = (this.currentPoint.GetDestination(false) != null);
            }
            if (this.speed != 0f)
            {
                if (this.currentPath == null && this.currentPoint != null)
                {
                    this.ReceiveNewPath();
                }
                if (this.currentPath != null)
                {
                    this.TraversePath();
                }
                this.deathZones.SetActive(true);
            }
            else
            {
                this.deathZones.SetActive(false);
            }
            if (this.currentPath != null)
            {
                this.UpdateWorldPosition();
                if (this.movementDirection != TramMovementDirection.None)
                {
                    this.UpdateWorldRotation();
                }
                this.DrawPathPreview();
                ConnectedTram[] array = this.connectedTrams;
                for (int i = 0; i < array.Length; i++)
                {
                    array[i].UpdateTram(this.currentPath);
                }
            }
        }
        private void DrawPathPreview()
        {
        }
        private void TraversePath()
        {
            this.currentPath.distanceTravelled += this.computedSpeed * Time.deltaTime;
            if (!this.IsAtEndOfPath())
            {
                this.canGoForward = true;
                this.canGoBackward = true;
                return;
            }
            float num = this.currentPath.distanceTravelled;
            if (this.movementDirection == TramMovementDirection.Forward)
            {
                num -= this.currentPath.DistanceTotal;
            }
            if (this.movementDirection == TramMovementDirection.Backward && this.backwardOffset != 0f && this.currentPath.IsDeadEnd(this.movementDirection))
            {
                this.speed = 0f;
                this.canGoBackward = false;
                UnityEngine.Object.Instantiate<GameObject>(this.bonkSound, this.rb.position, Quaternion.identity);
                return;
            }
            this.currentPoint = ((this.movementDirection == TramMovementDirection.Forward) ? this.currentPath.end : this.currentPath.start);
            this.currentPath = null;
            this.ReceiveNewPath();
            if (this.currentPath == null)
            {
                if (this.currentPoint.stopBehaviour == StopBehaviour.InstantClank || this.zapAmount > 0f)
                {
                    UnityEngine.Object.Instantiate<GameObject>(this.bonkSound, this.rb.position, Quaternion.identity);
                }
                if (this.movementDirection == TramMovementDirection.Forward)
                {
                    this.canGoForward = false;
                }
                else
                {
                    this.canGoBackward = false;
                }
                this.speed = 0f;
                return;
            }
            this.currentPath.distanceTravelled += num;
            if (this.movementDirection == TramMovementDirection.Forward)
            {
                this.canGoForward = true;
                return;
            }
            this.canGoBackward = true;
        }
        private bool IsAtEndOfPath()
        {
            if (this.currentPath == null)
            {
                return false;
            }
            float distanceTotal = this.currentPath.DistanceTotal;
            float num = 0f;
            if (this.movementDirection == TramMovementDirection.Backward && this.backwardOffset != 0f && this.currentPath.start.GetDestination(false) == null)
            {
                num += this.backwardOffset;
            }
            if (this.movementDirection != TramMovementDirection.Forward)
            {
                return this.currentPath.distanceTravelled <= num;
            }
            return this.currentPath.distanceTravelled >= distanceTotal;
        }
        public void UpdateWorldPosition()
        {
            if (this.currentPath == null)
            {
                return;
            }
            Vector3 pointOnPath = this.currentPath.GetPointOnPath(this.currentPath.Progress);
            this.rb.MovePosition(pointOnPath);
        }
        public void UpdateWorldRotation()
        {
            if (this.currentPath == null)
            {
                return;
            }
            Quaternion rotation = Quaternion.LookRotation(this.currentPath.MovementDirection(), Vector3.up);
            this.rb.rotation = rotation;
        }
        private void ReceiveNewPath()
        {
            if (this.currentPoint == null)
            {
                return;
            }
            bool flag = this.movementDirection == TramMovementDirection.Forward;
            TrainTrackPoint destination = this.currentPoint.GetDestination(flag);
            if (destination == null)
            {
                return;
            }
            TrainTrackPoint start = flag ? this.currentPoint : destination;
            TrainTrackPoint end = flag ? destination : this.currentPoint;
            TramPath tramPath = new TramPath(start, end);
            if (!flag)
            {
                tramPath.distanceTravelled = tramPath.DistanceTotal;
            }
            this.currentPath = tramPath;
            this.currentPoint = null;
        }
        private void UpdateAudio()
        {
            if (this.computedSpeed != 0f && !this.aud.isPlaying)
            {
                this.aud.Play();
            }
            else if (this.computedSpeed == 0f && this.aud.isPlaying)
            {
                this.aud.Stop();
            }
            float num;
            if (Mathf.Abs(this.computedSpeed) >= 50f)
            {
                num = ((this.zapAmount > 0f) ? Mathf.Lerp(1f, 1.5f, this.zapAmount) : 1f);
            }
            else
            {
                num = Mathf.Abs(this.computedSpeed) * 0.02f;
            }
            this.aud.volume = num;
            this.aud.pitch = num * 2f;
        }
        public bool poweredOn = true;
        private AudioSource aud;
        public GameObject bonkSound;
        public GameObject deathZones;
        [HideInInspector]
        public float zapAmount;
        public float speed;
        public ConnectedTram[] connectedTrams;
        [Space]
        public TrainTrackPoint currentPoint;
        public TramPath currentPath;
        private ScreenZone[] screenActivators;
        [HideInInspector]
        public TramControl controller;
        private Rigidbody rb;
    }
}
