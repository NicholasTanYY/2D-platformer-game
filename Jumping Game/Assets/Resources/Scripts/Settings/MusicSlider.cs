using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField]
    private Slider musicSlider;
    private float musicSliderValue;
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.onValueChanged.AddListener(musicSliderFunction);
        musicSliderValue = SoundData.LoadSoundFunction().musicSliderValue;
        musicSlider.value = musicSliderValue;
    }
    void musicSliderFunction(float musicValue)
    {
        Debug.Log(musicValue);
        //function to change volume
    }
}
