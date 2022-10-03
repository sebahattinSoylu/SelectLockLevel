using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
   [SerializeField] private Transform btnlarHolder;
   [SerializeField] private ButonManager btnPrefab;

   private void Start()
   {
      BaslangicFNC();
   }

   void BaslangicFNC()
   {
      LevelItem[] levelItemArray = LevelSystemManager.instance.levelData.levelItemArray;

      for (int i = 0; i < levelItemArray.Length; i++)
      {
         ButonManager levelBtn = Instantiate(btnPrefab, btnlarHolder);
         levelBtn.LevelDuzenleFNC(levelItemArray[i],i);
         
      }
   }
}
