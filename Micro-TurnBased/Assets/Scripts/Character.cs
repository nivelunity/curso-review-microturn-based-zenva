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
    
}
