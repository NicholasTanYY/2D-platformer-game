using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Slider soundSlider;
    [SerializeField]
    private Slider musicSlider;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(quitButtonFunction);
    }

    // Update is called once per frame
    void quitButtonFunction()
    {
        Time.timeScale = 1;
        SoundData.saveSoundSettingsFunction(new SoundData(soundSlider.value, musicSlider.value));
        SceneManager.LoadScene("MainMenu");
    }
}
