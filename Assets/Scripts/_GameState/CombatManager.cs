using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public Enemy _enemy;
    public Character _character;

    public int _playerHealth = 10;
    public int _playerActionsMin;
    public int _playerActions = 3;
    public int _playerActionsMax = 3;
    public int _actionRegen = 2;

    public int _playerDamage = 1;

  

    public int timer = 0;
    public float _interval = .1f;
    private float _nextTick;

    public GameState GAMESTATE;

    StateMachine _stateMachine;
    PlayerState _playerState;
    EnemyState _enemyState;

    public bool _switchState;
    public bool _isDefeated;
    public bool _isVictorious;

    public TextMeshProUGUI _playerHealthText;
    public TextMeshProUGUI _enemyHealthText;
    public TextMeshProUGUI _playerActionsText;
    public TextMeshProUGUI _enemyActionsText;

    private void Awake()
    {
        _playerActions = _playerActionsMax;
        _enemy = GetComponent<Enemy>();
        _character = GameManager.Instance._character;

        //State Machine
        _stateMachine = new StateMachine();

        _playerState = new PlayerState(this, _character);
        _enemyState = new EnemyState(this, _enemy);
        var defeatState = new DefeatState();
        var victoryState = new VictoryState();

        // Define transitions

        At(_enemyState, _playerState, new FuncPredicate(() => _switchState));
        At(_playerState, _enemyState, new FuncPredicate(() => _switchState));
        Any(defeatState, new FuncPredicate(() => _isDefeated));
        Any(victoryState, new FuncPredicate(() => _isVictorious));


        _stateMachine.SetState(_playerState);
    }

    void At(IState from, IState to, IPredicate condition) => _stateMachine.AddTransition(from, to, condition);
    void Any( IState to, IPredicate condition ) => _stateMachine.AddAnyTransition(to, condition);

    public void SwitchState()
    {
        if (_stateMachine.GetCurrentState() != _enemyState)
            _stateMachine.SetState(_enemyState);
        else if(_stateMachine.GetCurrentState() == _enemyState)        
            _stateMachine.SetState(_playerState);
        

        //_switchState = !_switchState;
    } 

    private void Start()
    {
        GAMESTATE = GameState.PLAYER_TURN;
        _nextTick = Time.time + _interval;
        //SwitchTurn();
    }

    private void Update()
    {
        UpdateUI();
        //SwitchTurn();


        Debug.Log("Testing if I can get current state: " + _stateMachine.GetCurrentState());
        Timer();
        if(Timer() >= 10)
        {
            _stateMachine.SetState(_playerState);
        }
    }

    private void UpdateUI()
    {
        _playerActionsText.text = _playerActions.ToString();
        _playerHealthText.text = _playerHealth.ToString();
        _enemyActionsText.text = _enemy._enemyActions.ToString();
        _enemyHealthText.text = _enemy._enemyHealth.ToString();
    }

    public void GainActionPoints()
    {
        _playerActions += _actionRegen;
    }

     private int Timer()
     {
         if (timer > _nextTick)
         {
             timer++;
    
             _nextTick += _interval;
    
             Debug.Log("Timer: " + timer);
         }
         return timer;
     }
    #region old shit

    private void OnPlayerTurn()
    {           
        _enemy._enemyActions += 2;       
            
        
    }

    public void PlayerAttackButton()
    {
        if(GAMESTATE == GameState.PLAYER_TURN && _playerActions > 0)
        {
            _playerActions -= 1;
            _enemy._enemyHealth -= _playerDamage;
        }
    }
    public void EndPlayerTurnButton()
    {
        GAMESTATE = GameState.ENEMY_TURN;
        
    }

    private void OnEnemyTurn()
    {
        
        int currentActionPool = _enemy._enemyActions;

            currentActionPool += 2;
        if (GAMESTATE == GameState.ENEMY_TURN && _enemy._enemyActions > 0)
        {
            for(int i = 0; i < currentActionPool; i++)
            {
                currentActionPool -= 1;
                _playerHealth -= _enemy._enemyDamage;
            }
            GAMESTATE = GameState.PLAYER_TURN;
            _enemy._enemyActions = currentActionPool;
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
    #endregion
}
