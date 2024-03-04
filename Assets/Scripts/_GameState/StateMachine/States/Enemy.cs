using UnityEngine;

public class Enemy : MonoBehaviour
{
    Character character;
    CombatManager _combatManager;

    public int _enemyHealth = 10;
    public int _enemyActionsMin;
    public int _enemyActions = 3;
    public int _enemyActionsMax = 3;

    public int _enemyDamage = 1;


    public int _actionRegen = 2;

    private void Awake()
    {
        _combatManager = GetComponent<CombatManager>();
    }

    public void GainActionPoints( )
    {
        _enemyActions += _actionRegen;
    }
    public void OnEnemyTurn()
    {   
        int currentActionPool = _enemyActions;

        for (int i = 0; i < _enemyActions; i++)
        {
            currentActionPool -= 1;
            _combatManager._playerHealth -= _enemyDamage;
        }
        _enemyActions = currentActionPool;

        //_combatManager.SwitchState();
    }
}

