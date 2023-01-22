using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAQButton : MonoBehaviour
{
    [SerializeField]
    private Button fAQButton;
    // Start is called before the first frame update
    void Start()
    {
        fAQButton.onClick.AddListener(fAQButtonFunction);
    }
    void fAQButtonFunction()
    {
        Debug.Log("FAQ Page");
        //function to go to FAQ Page
    }
}
