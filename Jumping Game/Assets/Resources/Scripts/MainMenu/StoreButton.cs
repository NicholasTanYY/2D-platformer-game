using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StoreButton : MonoBehaviour
{
    [SerializeField]
    private Button storeButton;
    void Start()
    {
        storeButton.onClick.AddListener(store);
    }

    void store()
    {
            SceneManager.LoadScene("Store");
        // function to go to Store page
    }
}
