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
        Character.OnDie += OnCharacterDie;
    }

    private void OnDisable()
    {
        Character.OnDie -= OnCharacterDie;
    }

    private void Start()
    {
        BeginNextTurn();
    }

    public void BeginNextTurn()
    {
        curCharacterIndex++;
        if (curCharacterIndex == characters.Length)
            curCharacterIndex = 0;

        CurrentCharacter = characters[curCharacterIndex];
        OnBeginTurn?.Invoke(CurrentCharacter);
    }

    public void EndTurn()
    {
        OnEndTurn?.Invoke(CurrentCharacter);
        Invoke(nameof(BeginNextTurn), nexTurnDelay);
    }

    void OnCharacterDie(Character character)
    {
        if(character.IsPlayer)
            Debug.Log("You lost!");
        else
            Debug.Log("You Win");
    }   
}
