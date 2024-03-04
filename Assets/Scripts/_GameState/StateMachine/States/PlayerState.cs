using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : BaseState
{
    CombatManager CombatManager;
    Character Character;

    public PlayerState(CombatManager combatManager, Character character )
    {
        this.CombatManager = combatManager;
        this.Character = character;
    }

    public override void OnEnter()
    {
        CombatManager.GainActionPoints();
        Debug.Log("Current state is PlayerState");
    }
    public override void Update()
    {

    }
    public override void OnExit()
    {
        
    }

}
