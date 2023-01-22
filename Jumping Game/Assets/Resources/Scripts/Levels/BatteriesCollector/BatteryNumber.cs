using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BatteryNumber : MonoBehaviour
{
    public static int batteryCount;
    private TextMeshProUGUI batteryNumber;
    // Start is called before the first frame update
    void Start()
    {
        batteryCount = 0;
        batteryNumber = gameObject.GetComponent<TextMeshProUGUI>();
        batteryNumber.text = BatteryNumber.batteryCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        batteryNumber.text = BatteryNumber.batteryCount.ToString();
    }
}
