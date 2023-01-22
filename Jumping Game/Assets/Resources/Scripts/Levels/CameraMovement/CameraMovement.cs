using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = 0;
    }
    // Update is called once per frame
    void Update()
    {
        cameraMovement();
    }
    void cameraMovement()
    {
        if (Level1.selectedCharacterCollider.transform.position.y > startingPos)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, Level1.selectedCharacterCollider.transform.position.y, 0.01f), transform.position.z);
        }
        else if (Level1.selectedCharacterCollider.transform.position.y < startingPos)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, startingPos, 0.01f), transform.position.z);
        }
    }
}
