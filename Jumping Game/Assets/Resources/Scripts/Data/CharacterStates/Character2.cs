using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Character2
{
    private static bool unlocked;
    private static string filePath = Application.persistentDataPath + "/saveCharacter2State.txt";
    public static bool getUnlocked()
    {
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Character2.unlocked = (bool) bf.Deserialize(fs);
            fs.Close();
            return unlocked;
        } 
        else
        {
            Character2.unlocked = false;
            return unlocked;
        }
    }
    public static void setUnlocked(bool unlocked)
    {
        Character2.unlocked = unlocked;
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Character2.unlocked);
            fs.Close();
        } 
        else
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Character2.unlocked);
            fs.Close();
        }
    }
}
