using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloseSettings : MonoBehaviour
{
    [SerializeField]
    private Button closeSettings;
    [SerializeField]
    private Slider soundSlider;
    [SerializeField]
    private Slider musicSlider;
    private string filePath;
    void Start()
    {
        closeSettings.onClick.AddListener(closeSettingsFunction);
    }
    void closeSettingsFunction()
    {
        SoundData.saveSoundSettingsFunction(new SoundData(soundSlider.value, musicSlider.value));
        SceneManager.LoadScene("MainMenu");
    }
}
