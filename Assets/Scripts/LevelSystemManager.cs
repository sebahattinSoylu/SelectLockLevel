using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystemManager : MonoBehaviour
{
    public static LevelSystemManager instance;

    public LevelData levelData;

    public int gecerliLevel;
    
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

    private void OnEnable()
    {
        SaveDataManager.instance.BaslangicFNC();
    }

    public void LevelTamamlandi(int yildizAdet)
    {
        levelData.levelItemArray[gecerliLevel].acilacakYildiz = yildizAdet;

        if (levelData.sonAcilmisLevel < (gecerliLevel + 1))
        {
            levelData.sonAcilmisLevel = gecerliLevel + 1;
            levelData.levelItemArray[levelData.sonAcilmisLevel].kilitAcikmi = true;
        }
    }
}
