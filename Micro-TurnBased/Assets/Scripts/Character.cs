using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public int CurHp;
    public int MaxHp;

    public bool IsPlayer;

    public List<CombatAction> CombatActions = new List<CombatAction>();

    [SerializeField] Character opponent;

    private Vector3 startPos;

    public event UnityAction OnHealthChange;
    public static event UnityAction<Character> OnDie;
    private void Start()
    {
        startPos = transform.position;
    }

    public void TakeDamage(int damageToTake)
    {
        CurHp -= damageToTake;
        OnHealthChange?.Invoke();
        
        if(CurHp <= 0)
            Die();
    }

    void Die()
    {
        OnDie?.Invoke(this);
        Destroy(gameObject);
    }

    public void Heal(int healAmount)
    {
        CurHp += healAmount;
        OnHealthChange?.Invoke();
        
        if (CurHp > MaxHp)
            CurHp = MaxHp;
    }

    public void CastCombatAction(CombatAction combatAction)
    {
        
    }
}
