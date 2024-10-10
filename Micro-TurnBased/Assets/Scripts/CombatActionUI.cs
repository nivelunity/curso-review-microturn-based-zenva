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
      TurnManager.Instance.OnBeginTurn += OnBeginTurn;
      TurnManager.Instance.OnEndTurn += OnEndTurn;
   }

   private void OnDisable()
   {
      TurnManager.Instance.OnBeginTurn -= OnBeginTurn;
      TurnManager.Instance.OnEndTurn -= OnEndTurn;
   }

   void OnBeginTurn(Character character)
   {
      if(!character.IsPlayer)
         return;
      
      visualContainer.SetActive(true);

      for (int i = 0; i < combatActionButtons.Length; i++)
      {
         if (i < character.CombatActions.Count)
         {
            combatActionButtons[i].gameObject.SetActive(true);
            CombatAction ca = character.CombatActions[i];

            combatActionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = ca.DisplayName;
            combatActionButtons[i].onClick.RemoveAllListeners();
            combatActionButtons[i].onClick.AddListener(()=> OnClickCombatAction(ca));
         }
         else
         {
            combatActionButtons[i].gameObject.SetActive(false);
         }
      }
   }
   
   void OnEndTurn(Character character)
   {
      visualContainer.SetActive(false);
   }

   public void OnClickCombatAction(CombatAction combatAction)
   {
      TurnManager.Instance.CurrentCharacter.CastCombatAction(combatAction);
   }
}
