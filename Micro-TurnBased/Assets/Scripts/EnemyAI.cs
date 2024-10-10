using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private AnimationCurve healChanceCurve;
    [SerializeField] private Character character;

    private void OnEnable()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }

    void OnBeginTurn(Character c)
    {
        
    }

    void DetermineCombatAction()
    {
        
    }

    bool HasCombatActionOfType(CombatAction.Type type)
    {
        
    }

    CombatAction GetCombatActionOfType(CombatAction.Type type)
    {
        
    }
}
