using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreBackButton : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    void Start()
    {
        backButton.onClick.AddListener(backToMenu);
    }

    void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // function to go to select level page
    }
}
