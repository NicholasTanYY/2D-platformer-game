using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapLeft : MonoBehaviour
{
    [SerializeField]
    private GameObject spikeTrapLeft, spikeButton;
    private bool activated = false;
    public static float shiftRate = 5f;
    private Vector3 trapPosition;

    // Start is called before the first frame update
    void Start()
    {
        trapPosition = spikeTrapLeft.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkActivated();
    }

    void checkActivated(){
        if(!activated)
        {
            if(spikeButton.GetComponent<BoxCollider2D>().IsTouching(Level1.selectedCharacterCollider))
            {
                activated = true;
                spikeTrapLeft.transform.position -= new Vector3(shiftRate * Time.deltaTime, 0f, 0f);
            }
        }
        else if(activated)
        {
            spikeTrapLeft.transform.position -= new Vector3(shiftRate * Time.deltaTime, 0f, 0f);
        }
    }
}
