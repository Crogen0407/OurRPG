using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "SO/StageData")]
public class SO_StageData : ScriptableObject
{
    public int currentStateIndex;
    public float[] survivalTimes;
}
