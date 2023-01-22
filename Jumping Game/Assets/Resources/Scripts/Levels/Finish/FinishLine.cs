using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (BatteryNumber.batteryCount == 0)
        {
            Level1.isFinished = true;
        }
    }
}
