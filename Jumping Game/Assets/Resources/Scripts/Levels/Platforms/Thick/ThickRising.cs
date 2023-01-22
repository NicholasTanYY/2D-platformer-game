using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThickRising : ThickPlatform
{
    public static float defaultShiftRate = StandardRising.defaultShiftRate;
    private float platformShiftRate = defaultShiftRate;
    public float yLimit = StandardRising.defaultYLimit;
    private float initialYPosition;

    public override void Start()
    {
        base.Start();
        initialYPosition = platform.transform.position.y;
    }

    public override void Update()
    {
        base.Update();
        shiftPlatform();
        shiftCharacter();
    }

    void shiftPlatform()
    {
        platform.transform.position += new Vector3(0f, platformShiftRate * Time.deltaTime, 0f);
        if(platform.transform.position.y >= (initialYPosition + yLimit) || platform.transform.position.y <= (initialYPosition - yLimit))
        {
            platformShiftRate *= -1;
        }
    }

    void shiftCharacter()
    {
        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider))
        {
            Level1.selectedCharacterCollider.gameObject.transform.position += new Vector3(0f, platformShiftRate * Time.deltaTime, 0f);
        }
    }
}
