using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{


    public int _playerHealth = 10;
    public int _playerActionsMin;
    public int _playerActions = 3;
    public int _playerActionsMax = 3;

    public int _playerDamage = 1;

    public int _enemyHealth = 10;
    public int _enemyActionsMin;
    public int _enemyActions = 3;
    public int _enemyActionsMax = 3;

    public int _enemyDamage = 1;

  //  public int timer = 0;
  //  public float _interval = 2f;
  //  private float _nextTick;

    public GameState GAMESTATE;


    public TextMeshProUGUI _playerHealthText;
    public TextMeshProUGUI _enemyHealthText;
    public TextMeshProUGUI _playerActionsText;
    public TextMeshProUGUI _enemyActionsText;


    private void Start()
    {
        GAMESTATE = GameState.PLAYER_TURN;
        //_nextTick = Time.time + _interval;
        SwitchTurn();
    }

    private void Update()
    {
        UpdateUI();
        SwitchTurn();
    }

    private void UpdateUI()
    {
        _playerActionsText.text = _playerActions.ToString();
        _playerHealthText.text = _playerHealth.ToString();
        _enemyActionsText.text = _enemyActions.ToString();
        _enemyHealthText.text = _enemyHealth.ToString();
    }
    
    // private void Timer()
    // {
    //     if (timer > _nextTick)
    //     {
    //         timer++;
    //
    //         _nextTick += _interval;
    //
    //         Debug.Log("Timer: " + timer);
    //     }
    // }

    public void SwitchTurn()
    {
        switch (GAMESTATE)
        {
            case GameState.PLAYER_TURN:                
                //OnPlayerTurn();

                break;
            case GameState.ENEMY_TURN:
                //
                OnEnemyTurn();

                break;
            case GameState.VICTORY:

                break;
            case GameState.DEFEAT:

                break;
        }
    }
    private void OnPlayerTurn()
    {           
        _enemyActions += 2;
        //if (_enemyActions >= _enemyActionsMax)
        //{
        //    _enemyActions = _enemyActionsMax;
        //}
            
        
    }

    public void PlayerAttackButton()
    {
        if(GAMESTATE == GameState.PLAYER_TURN && _playerActions > 0)
        {
            _playerActions -= 1;
            _enemyHealth -= _playerDamage;
        }
    }
    public void EndPlayerTurnButton()
    {
        GAMESTATE = GameState.ENEMY_TURN;
        
    }

    private void OnEnemyTurn()
    {
        
        int currentActionPool = _enemyActions;

            currentActionPool += 2;
        if (GAMESTATE == GameState.ENEMY_TURN && _enemyActions > 0)
        {
            for(int i = 0; i < currentActionPool; i++)
            {
                currentActionPool -= 1;
                _playerHealth -= _enemyDamage;
            }
            GAMESTATE = GameState.PLAYER_TURN;
            _enemyActions = currentActionPool;
        }
        else
        {
            _playerActions += 2;
            GAMESTATE = GameState.PLAYER_TURN;
            if(_playerActions > _playerActionsMax)
            {
                _playerActions = _playerActionsMax;
            }
        }        
    }
}
