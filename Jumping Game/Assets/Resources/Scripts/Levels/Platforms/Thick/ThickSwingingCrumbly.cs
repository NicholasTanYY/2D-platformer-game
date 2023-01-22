using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThickSwingingCrumbly : ThickCrumbly
{
    private static float shiftRate = -StandardMoving.defaultShiftRate;
    private float platformShiftRate = 0.5f;
    public float xLimit = StandardMoving.defaultXLimit * 1.4f;

    public override void Update()
    {
        base.Update();
        shiftPlatform();
        checkTouchTop();
    }

    void shiftPlatform()
    {
        float platformXPos = platform.transform.position.x + platformShiftRate * Time.deltaTime;
        float platformYPos = -2.5f * Mathf.Cos(platform.transform.position.x - xOriginal) + 2.5f + yOriginal;
        platform.transform.position = new Vector3(platformXPos, platformYPos, 0f);
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
        float charXPos = Level1.selectedCharacterCollider.gameObject.transform.position.x + platformShiftRate * Time.deltaTime;
        float charYPos = Level1.selectedCharacterCollider.gameObject.transform.position.y;
        Level1.selectedCharacterCollider.gameObject.transform.position = new Vector3(charXPos, charYPos, 0f);
    }
}
