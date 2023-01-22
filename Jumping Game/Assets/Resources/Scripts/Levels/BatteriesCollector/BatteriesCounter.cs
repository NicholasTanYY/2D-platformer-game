using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteriesCounter : MonoBehaviour
{
    private BoxCollider2D batteriesCollider;
    // Start is called before the first frame update
    void Start()
    {
        batteriesCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        BatteryNumber.batteryCount++;
        Destroy(this.gameObject);
    }
}
