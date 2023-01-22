using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private Button pauseButton;
    private GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(pauseButtonFunction);
        pauseScreen = GameObject.Find("PauseScreen");
    }

    // Update is called once per frame
    void pauseButtonFunction()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);

    }
}
