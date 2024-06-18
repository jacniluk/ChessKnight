using UnityEngine;

public class Utilities : MonoBehaviour
{
    #region Progress
    public static float CalculateProgress01(float value, float min, float max)
    {
        float achieved = value - min;
        float toAchieve = max - min;
        float progress = achieved / toAchieve;
        progress = Mathf.Clamp01(progress);

        return progress;
    }
    #endregion
}
