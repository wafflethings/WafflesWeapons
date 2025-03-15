using UnityEngine;

namespace Train
{
    public class ConnectedTram : MonoBehaviour
    {
        public float offset = 10f;
        private Tram thisTram;
        
        private void Awake()
        {
            thisTram = GetComponent<Tram>();
        }

        public void UpdateTram(TramPath parentPath)
        {
            if (parentPath == null) return;
            thisTram.currentPath = new TramPath(parentPath.start, parentPath.end);
            
            var offsetInFraction = offset / parentPath.DistanceTotal;
            var ourProgress = parentPath.Progress - offsetInFraction;
    
            // Is out of bounds
            if (ourProgress < 0)
            {
                var leftover = -ourProgress;
                var leftoverInUnits = leftover * parentPath.DistanceTotal;

                TramPath newPath = new TramPath(parentPath.start, parentPath.end);

                while (leftoverInUnits > 0 && newPath.start.GetDestination(forward: false) != null)
                {
                    newPath = new TramPath(newPath.start.GetDestination(forward: false), newPath.start);
            
                    if (leftoverInUnits <= newPath.DistanceTotal)
                    {
                        thisTram.currentPath = newPath;
                        thisTram.currentPath.distanceTravelled = newPath.DistanceTotal - leftoverInUnits;
                        leftoverInUnits = 0;
                    }
                    else
                    {
                        leftoverInUnits -= newPath.DistanceTotal;
                    }
                }

                // We're done
                thisTram.UpdateWorldRotation();
                thisTram.UpdateWorldPosition();
                return;
            }

            // Are we already using this path
            if (!thisTram.currentPath.Equals(parentPath))
            {
                // If not, update
                thisTram.currentPath = new TramPath(parentPath.start, parentPath.end);
            }

            thisTram.currentPath.distanceTravelled = ourProgress * thisTram.currentPath.DistanceTotal;
            thisTram.UpdateWorldRotation();
            thisTram.UpdateWorldPosition();
        }
    }
}