using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private AnimationCurve healChanceCurve;
    [SerializeField] private Character character;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    void OnBeginTurn(Character c)
    {
        
    }

    void DetermineCombatAction()
    {
        
    }

    bool HasCombatActionOfType(CombatAction.Type type)
    {
        return character.CombatActions.Exists(action => action.ActionType == type);
    }

    CombatAction GetCombatActionOfType(CombatAction.Type type)
    {
        List<CombatAction> availabeActions = 
            character.CombatActions.FindAll(action => action.ActionType == type);
        
        return availabeActions[Random.Range(0, availabeActions.Count)];
    }
}
