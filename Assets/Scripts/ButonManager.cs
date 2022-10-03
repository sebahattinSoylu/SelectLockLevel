using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButonManager : MonoBehaviour
{
   [SerializeField] private GameObject acilacakObje, kilitObje;
   [SerializeField] private Image[] yildizlarArray;
   [SerializeField] private TextMeshProUGUI levelTxt;
   [SerializeField] private Color kilitliColor, acikColor;
   [SerializeField] private Button btn;

   private int levelIndex;

   private void Start()
   {
      btn.onClick.AddListener(()=>OnButtonClick());
   }

   public void LevelDuzenleFNC(LevelItem levelItem, int index)
   {
      if (levelItem.kilitAcikmi)
      {
         levelIndex = index + 1;
         btn.interactable = true;
         kilitObje.SetActive(false);
         acilacakObje.SetActive(true);
         levelTxt.text = levelIndex.ToString();
         YildizlariAcFNC(levelItem.acilacakYildiz);
      }
      else
      {
         btn.interactable = false;
         kilitObje.SetActive(true);
         acilacakObje.SetActive(false);
      }
   }

   void YildizlariAcFNC(int acilacakYildiz)
   {
      for (int i = 0; i < yildizlarArray.Length; i++)
      {
         if (i < acilacakYildiz)
         {
            yildizlarArray[i].color = acikColor;
         }
         else
         {
            yildizlarArray[i].color = kilitliColor;
         }
      }
   }

   void OnButtonClick()
   {
      LevelSystemManager.instance.gecerliLevel = levelIndex - 1;
      SceneManager.LoadScene("Level" + levelIndex);
   }
}
