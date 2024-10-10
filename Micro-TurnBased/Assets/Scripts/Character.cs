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
        if (combatAction.Damage > 0)
        {
            StartCoroutine(AttackOpponet(combatAction));
        }
        else if (combatAction.ProjectilPrefab != null)
        {
            GameObject projectile = Instantiate(combatAction.ProjectilPrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().Initialize(opponent, TurnManager.Instance.EndTurn);
        }
        else if(combatAction.HealAmount > 0)
        {
            Heal(combatAction.HealAmount);
            TurnManager.Instance.EndTurn();
        }
    }

    IEnumerator AttackOpponet(CombatAction combatAction)
    {
        while (transform.position != opponent.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, opponent.transform.position, 50 * Time.deltaTime);
            yield return null;
        }
        
        opponent.TakeDamage(combatAction.Damage);
        
        while (transform.position != startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 20 * Time.deltaTime);
            yield return null;
        }
        
        TurnManager.Instance.EndTurn();
    }
    
    public float GetHealthPercentage()
    {
        return (float)CurHp / (float)MaxHp;
    }
}
