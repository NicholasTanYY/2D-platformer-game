using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private BoxCollider2D playerCollider;
    [SerializeField]
    private EdgeCollider2D spikeCollider;

    // Update is called once per frame
    void Update()
    {
        deathCheck();
    }
    void deathCheck(){
        if(spikeCollider.IsTouching(Level1.selectedCharacterCollider.GetComponent<BoxCollider2D>())){
            Debug.Log("DIED");
        }
    }
}
