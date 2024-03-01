using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    PLAYER_TURN,
    ENEMY_TURN,
    VICTORY,
    DEFEAT,
}
public class TurnManager : MonoBehaviour
{

    GameState GAMESTATE;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchTurn();
    }


    public void SwitchTurn()
    {
        switch (GAMESTATE)
        {
            case GameState.PLAYER_TURN:
                //OnPlayerTurn();

                break;
            case GameState.ENEMY_TURN:
                //OnEnemyTurn();

                break;
            case GameState.VICTORY:

                break;
            case GameState.DEFEAT:

                break;
        }
    }
    public void EndPlayerTurn()
    {
        GAMESTATE = GameState.ENEMY_TURN;
    }

    public void EndEnemyTurn()
    {
        GAMESTATE = GameState.PLAYER_TURN;
    }
}
