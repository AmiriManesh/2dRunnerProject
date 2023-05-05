using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static void SaveData(string dataName , int value)
    {
        PlayerPrefs.SetInt(dataName , value);
    }

    public static int GetData(string dataName)
    {
        return PlayerPrefs.GetInt(dataName);
    }

}
