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
}
