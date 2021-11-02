using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveData : MonoBehaviour
{
    public void SaveIntData(string _name, int _data)
    {
        PlayerPrefs.SetInt(_name, _data);
    }

    public int GetIntData(string _name)
    {
        if (PlayerPrefs.HasKey(_name))
        {
            return PlayerPrefs.GetInt(_name);
        }

        return 0;
    }

    public void SaveFloatData(string _name, float _data)
    {
        PlayerPrefs.SetFloat(_name, _data);
    }

    public float GetFloatData(string _name)
    {
        if (PlayerPrefs.HasKey(_name))
        {
            return PlayerPrefs.GetFloat(_name);
        }

        return 0;
    }

    public void SaveStringData(string _name, string _data)
    {
        PlayerPrefs.SetString(_name, _data);
    }

    public string GetStringData(string _name)
    {
        if (PlayerPrefs.HasKey(_name))
        {
            return PlayerPrefs.GetString(_name);
        }

        return null;
    }

#if UNITY_EDITOR
    [MenuItem("Data/DeleteAllData")]
#endif
    public static void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}
