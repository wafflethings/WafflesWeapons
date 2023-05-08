using UnityEngine;

public class TrainTrackPoint : MonoBehaviour
{
    public bool isAllowed = true;
    public TurningMethod turn = TurningMethod.TurnInstantly;
    public StoppingMethod ifLast = StoppingMethod.StopInstantly;
    public TrainTrackPoint next;
    public TrainTrackPoint previous;

    public void SetAllowed(bool state) { }
    public enum TurningMethod
    {
        None = 0,
        CurveToNext = 1,
        TurnInstantly = 2,
        SmoothStopAndTurn = 3
    };

    public enum StoppingMethod
    {
        StopInstantly = 0,
        StopSlowly = 1
    };
}
