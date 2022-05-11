using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public UserData userData;
    public SystemData systemData;

    

    private void Awake()
    {        
        LoadUserData();
        LoadSystemData();

        if (instance == null)
        {            
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public void SaveHighScore(int score)
    {
        userData.highScore = score;

        FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(file, userData);
        file.Close();
    }

    private void LoadUserData()
    {
        if (File.Exists(Application.persistentDataPath + "/userdata.dat"))
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            userData = (UserData)binaryFormatter.Deserialize(file);
            file.Close();
        }
        else
        {
            userData = new UserData();
        }
    }

    public void SaveSystemData()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/systemdata.dat", FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(file, systemData);
        file.Close();

        Debug.Log(systemData.audioBackGroundVolume);
        Debug.Log(systemData.audioMasterVolume);
    }

    private void LoadSystemData()
    {
        if (File.Exists(Application.persistentDataPath + "/systemdata.dat"))
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/systemdata.dat", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            systemData = (SystemData)binaryFormatter.Deserialize(file);
            file.Close();
        }
        else
        {
            systemData = new SystemData();
        }
    }

}
[Serializable]
public class UserData
{
    public int highScore;
}

[Serializable]
public class SystemData
{
    public float audioMasterVolume;
    public float audioBackGroundVolume;
}
