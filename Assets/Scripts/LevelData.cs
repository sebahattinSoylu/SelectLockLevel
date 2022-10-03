
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int sonAcilmisLevel = 0;

    public LevelItem[] levelItemArray;
}

[System.Serializable]
public class LevelItem
{
    public bool kilitAcikmi;
    public int acilacakYildiz;
}
