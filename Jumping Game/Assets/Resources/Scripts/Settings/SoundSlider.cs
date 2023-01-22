using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SoundSlider : MonoBehaviour
{
    [SerializeField]
    private Slider soundSlider;
    private string filePath;
    private float soundSliderValue;
    // Start is called before the first frame update
    void Start()
    {
        soundSlider.onValueChanged.AddListener(soundSliderFunction);
        soundSliderValue = SoundData.LoadSoundFunction().soundSliderValue;
        soundSlider.value = soundSliderValue;
        
    }
    void soundSliderFunction(float soundValue)
    {
        Debug.Log(soundValue);
        //function to change volume
    }
}
