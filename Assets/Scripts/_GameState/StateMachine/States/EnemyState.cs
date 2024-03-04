using UnityEngine;

internal class EnemyState : BaseState
{
    protected Enemy _enemy; 
    protected CombatManager _combatManager;

    public EnemyState( CombatManager combatManager, Enemy enemy )
    {
        this._combatManager = combatManager;
        this._enemy = enemy;
    }


    public EnemyState()
    {
    }


    public override void OnEnter()
    {
        //increment actions
        Debug.Log("Current state is EnemeyState");
        if(_enemy._enemyActions != 3 )
        {
        _combatManager.GainActionPoints();            
        }
        _enemy.OnEnemyTurn();
        
    }
    public override void Update()
    {
        //_enemy.OnEnemyTurn();

    }

    public override void OnExit()
    {
        //noop
    }
}
