using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardMovingCrumbly : StandardCrumbly
{
    private static float defaultShiftRate = StandardMoving.defaultShiftRate;
    private float platformShiftRate = defaultShiftRate;
    public float xLimit = StandardMoving.defaultXLimit;

    public override void Update()
    {
        base.Update();
        shiftPlatform();
        shiftCharacter();
    }

    void shiftPlatform()
    {
        platform.transform.position += new Vector3(platformShiftRate * Time.deltaTime, 0f, 0f);
        if(platform.transform.position.x >= (xOriginal + xLimit) || platform.transform.position.x <= (xOriginal - xLimit))
        {
            platformShiftRate *= -1;
        }
    }

    void shiftCharacter()
    {
        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider))
        {
            Level1.selectedCharacterCollider.gameObject.transform.position += new Vector3(platformShiftRate * Time.deltaTime, 0f, 0f);
        }
    }
}
