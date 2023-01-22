using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class SoundData
{
    public float soundSliderValue = 0;
    public float musicSliderValue = 0;
    private static string filePath = Application.persistentDataPath + "/saveSoundSettings.txt";
    public SoundData(float soundSliderValue, float musicSliderValue)
    {
        this.soundSliderValue = soundSliderValue;
        this.musicSliderValue = musicSliderValue;
    }

    public static void saveSoundSettingsFunction(SoundData saveData)
    {
        if (!File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, saveData);
            dataStream.Close();
        } 
        else
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter converter = new BinaryFormatter();
            converter.Serialize(dataStream, saveData);
            dataStream.Close();
        }
    }

    public static SoundData LoadSoundFunction()
    {
        if(File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();
            SoundData saveData = (SoundData)converter.Deserialize(dataStream);

            dataStream.Close();
            return saveData; 
        }
        else
        {
            SoundData saveData = new SoundData(0, 0);
            return saveData;
        }
    }
}
