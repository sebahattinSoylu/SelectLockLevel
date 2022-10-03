using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BaslangicFNC()
    {
        if (PlayerPrefs.GetInt("OyunIlkAcildi") == 1)
        {
            DataYukleFNC();
        }
        else
        {
            DataKaydetFNC();
            PlayerPrefs.SetInt("OyunIlkAcildi",1);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            DataKaydetFNC();
    }

    public void DataKaydetFNC()
    {
        string levelDataString = JsonUtility.ToJson(LevelSystemManager.instance.levelData);

        try
        {
            System.IO.File.WriteAllText(Application.persistentDataPath+"/LevelData.json",levelDataString);
        }
        catch (Exception e)
        {
            print("kayıtta hata oluştu"+ e);
            throw;
        }
    }

    void DataYukleFNC()
    {
        try
        {
            string levelDataString = System.IO.File.ReadAllText(Application.persistentDataPath + "/LevelData.json");

            LevelData levelData = JsonUtility.FromJson<LevelData>(levelDataString);

            if (levelData != null)
            {
                LevelSystemManager.instance.levelData.levelItemArray = levelData.levelItemArray;
                LevelSystemManager.instance.levelData.sonAcilmisLevel = levelData.sonAcilmisLevel;
            }
        }
        catch (Exception e)
        {
            print("yüklemede hata oluştu"+ e);
            throw;
        }
    }
}
