using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HighestLevelData
{
    private static int highestLevel;
    private static string filePath = Application.persistentDataPath + "/HighestLevelData.txt";
    public static int getHighestLevel()
    {
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            HighestLevelData.highestLevel = (int) bf.Deserialize(fs);
            fs.Close();
            return highestLevel;
        }
        else 
        {
            HighestLevelData.highestLevel = 1;
            return highestLevel;
        }
    }
    public static void setHighestLevel(int highestLevel)
    {
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, highestLevel);
            fs.Close();

        }
        else 
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, highestLevel);
            fs.Close();
        }
    }
}
