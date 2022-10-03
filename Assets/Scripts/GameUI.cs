using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
   [SerializeField] private Image[] yildizlarArray;
   [SerializeField] private Color kilitColor, acikColor;
   [SerializeField] private TextMeshProUGUI levelTxt;
   [SerializeField] private GameObject cikisPanel;

    public void LeveliGecFNC(int yildizAdet)
    {
        if (yildizAdet > 0)
        {
            levelTxt.text = "Level " + (LevelSystemManager.instance.gecerliLevel + 1) + " Tamamlandı";
            LevelSystemManager.instance.LevelTamamlandi(yildizAdet);
        }
        else
        {
            levelTxt.text = "Level " + (LevelSystemManager.instance.gecerliLevel + 1) + " Tamamlanmadı";
        }
        YildizlariAcFNC(yildizAdet);
        cikisPanel.SetActive(true);
    }

    void YildizlariAcFNC(int yildizAdet)
    {
        for (int i = 0; i < yildizAdet; i++)
        {
            if (i < yildizAdet)
            {
                yildizlarArray[i].color = acikColor;
            }
            else
            {
                yildizlarArray[i].color = kilitColor;
            }
        }
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }
}
