using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThickCrumbly : ThickPlatform
{
    [SerializeField]
    private GameObject num1, num2, num3;
    private float destroyTime = StandardCrumbly.destroyTime;
    private bool destroying = false;

    public override void Start()
    {
        base.Start();
        num1.SetActive(false);
        num2.SetActive(false);
        num3.SetActive(false);
    }

    public override void Update()
    {
        base.Update();
        collisionCheck();
    }

    void collisionCheck()
    {
        if(platform.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider) && characterBottom >= platformTop)
        {
            if(!destroying)
            {
                StartCoroutine(destroyPlatform());
            }
        }
    }

    IEnumerator destroyPlatform()
    {
        destroying = true;

        num3.SetActive(true);
        yield return new WaitForSeconds(destroyTime/3);
        num3.SetActive(false);

        num2.SetActive(true);
        yield return new WaitForSeconds(destroyTime/3);
        num2.SetActive(false);
        
        num1.SetActive(true);
        yield return new WaitForSeconds(destroyTime/3);
        num1.SetActive(false);

        platform.SetActive(false);
    }
}
