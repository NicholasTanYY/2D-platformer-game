using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    [SerializeField]
    private Button settingsButton;
    void Start()
    {
        settingsButton.onClick.AddListener(settings);
    }

    void settings()
    {
            SceneManager.LoadScene("Settings");
        // function to go to settings page
    }
}
