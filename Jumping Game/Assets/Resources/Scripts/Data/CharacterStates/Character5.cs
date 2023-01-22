using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Character5
{
    private static bool unlocked;
    private static string filePath = Application.persistentDataPath + "/saveCharacter5State.txt";
    public static bool getUnlocked()
    {
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            Character5.unlocked = (bool) bf.Deserialize(fs);
            fs.Close();
            return unlocked;
        } 
        else
        {
            Character5.unlocked = false;
            return unlocked;
        }
    }
    public static void setUnlocked(bool unlocked)
    {
        Character5.unlocked = unlocked;
        if (File.Exists(filePath))
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Character5.unlocked);
            fs.Close();
        } 
        else
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Character5.unlocked);
            fs.Close();
        }
    }
}
