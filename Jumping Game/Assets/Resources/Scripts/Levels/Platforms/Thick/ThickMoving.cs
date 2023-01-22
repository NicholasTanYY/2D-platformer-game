using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThickMoving : ThickPlatform
{
    private static float shiftRate = -StandardMoving.defaultShiftRate;
    private float platformShiftRate = shiftRate;
    public float xLimit = StandardMoving.defaultXLimit;

    public override void Update()
    {
        base.Update();
        shiftPlatform();
        checkTouchTop();
    }

    void shiftPlatform()
    {
        platform.transform.position += new Vector3(platformShiftRate * Time.deltaTime, 0f, 0f);
        if(platform.transform.position.x >= (xOriginal + xLimit) || platform.transform.position.x <= (xOriginal - xLimit))
        {
            platformShiftRate *= -1;
        }
    }

    void checkTouchTop()
    {
        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider) && characterBottom >= platformTop)
        {
            shiftCharacter();
        }
    }

    void shiftCharacter()
    {
        Level1.selectedCharacterCollider.gameObject.transform.position += new Vector3(platformShiftRate * Time.deltaTime, 0f, 0f);
    }
}
