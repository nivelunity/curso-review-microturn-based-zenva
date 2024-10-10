using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private Character[] characters;
    [SerializeField] private float nexTurnDelay = 1.0f;

    private int curCharacterIndex = -1;
    public Character CurrentCharacter;

    public event UnityAction<Character> OnBeginTurn;
    public event UnityAction<Character> OnEndTurn;

    public static TurnManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void OnEnable()
    {
        throw new NotImplementedException();
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        throw new NotImplementedException();
    }

    public void BeginNextTurn()
    {
        
    }

    public void EndTurn()
    {
        
    }

    void OnCharacterDie(Character character)
    {
        
    }
}
