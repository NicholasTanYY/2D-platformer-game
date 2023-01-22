using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    new public static bool isUnlocked = false;
    new public static bool isFinished = false;
    void unlockNextLevel()
    {
        if (Level3.isUnlocked == false)
        {
            Level3.isUnlocked = true;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isFinished)
        {
            unlockNextLevel();
        }
    } 
}
