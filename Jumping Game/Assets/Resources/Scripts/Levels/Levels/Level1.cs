using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    new public static bool isUnlocked = true;
    new public static bool isFinished = false;
    void unlockNextLevel()
    {
        if (Level2.isUnlocked == false)
        {
            Level2.isUnlocked = true;
            HighestLevelData.setHighestLevel(2);
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
 
