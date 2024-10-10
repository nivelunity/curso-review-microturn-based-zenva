using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private AnimationCurve healChanceCurve;
    [SerializeField] private Character character;

    private void OnEnable()
    {
        TurnManager.Instance.OnBeginTurn += OnBeginTurn;
    }

    private void OnDisable()
    {
        TurnManager.Instance.OnBeginTurn -= OnBeginTurn;
    }

    void OnBeginTurn(Character c)
    {
        if (character == c)
        {
            DetermineCombatAction();
        }
    }

    void DetermineCombatAction()
    {
        float healthPercentage = character.GetHealthPercentage();
        bool wantToHeal = Random.value < healChanceCurve.Evaluate(healthPercentage);
    }

    bool HasCombatActionOfType(CombatAction.Type type)
    {
        return character.CombatActions.Exists(action => action.ActionType == type);
    }

    CombatAction GetCombatActionOfType(CombatAction.Type type)
    {
        List<CombatAction> availableActions = 
            character.CombatActions.FindAll(action => action.ActionType == type);
        
        return availableActions[Random.Range(0, availableActions.Count)];
    }

}
