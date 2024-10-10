using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatActionUI : MonoBehaviour
{
   [SerializeField] private GameObject visualContainer;
   [SerializeField] private Button[] combatActionButtons;

   private void OnEnable()
   {
      throw new NotImplementedException();
   }

   private void OnDisable()
   {
      throw new NotImplementedException();
   }

   void OnBeginTurn(Character character)
   {
      
   }
   
   void OnEndTurn(Character character)
   {
      
   }

   public void OnClickCombatAction(CombatAction combatAction)
   {
      
   }
}
