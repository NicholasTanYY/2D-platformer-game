using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapRight : MonoBehaviour
{
    [SerializeField]
    private GameObject spikeTrapRight, spikeButton;
    private bool activated = false;
    private float shiftRate = SpikeTrapLeft.shiftRate;
    private Vector3 trapPosition;

    // Start is called before the first frame update
    void Start()
    {
        trapPosition = spikeTrapRight.transform.position;
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
                spikeTrapRight.transform.position += new Vector3(shiftRate * Time.deltaTime, 0f, 0f);
            }
        }
        else if(activated)
        {
            spikeTrapRight.transform.position += new Vector3(shiftRate * Time.deltaTime, 0f, 0f);
        }
    }
}
