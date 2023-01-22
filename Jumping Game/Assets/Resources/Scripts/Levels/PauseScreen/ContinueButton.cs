using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Slider soundSlider;
    [SerializeField]
    private Slider musicSlider;
    
    private GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(continueButtonFunction);
        pauseScreen = GameObject.Find("PauseScreen");
    }

    // Update is called once per frame
    void continueButtonFunction()
    {
        Time.timeScale = 1;
        SoundData.saveSoundSettingsFunction(new SoundData(soundSlider.value, musicSlider.value));
        pauseScreen.SetActive(false);

    }
}
