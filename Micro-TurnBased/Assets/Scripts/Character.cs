using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int CurHp;
    public int MaxHp;

    public bool IsPlayer;

    public List<CombatAction> CombatActions = new List<CombatAction>();

    [SerializeField] Character opponent;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    public void TakeDamage(int damageToTake)
    {
        CurHp -= damageToTake;
        if(CurHp <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void Heal(int healAmount)
    {
        CurHp += healAmount;
        if (CurHp > MaxHp)
            CurHp = MaxHp;
    }

    public void CastCombatAction(CombatAction combatAction)
    {
        
    }
}
