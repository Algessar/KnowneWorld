using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Action", menuName = "Actions/New Action")]
public class SOActions : ScriptableObject
{
    //These are actions all characters can perform.

    public string _name = string.Empty;

    public string _description = string.Empty;
    public string _type = string.Empty;

    public int _actionPointCost = 1;

    public int _defaultDieType = 6; //D4, D6, D10 etc
    public int _diceAmount = 1;
    public int _range = 1;

    public int _negativeModifier = -0;
    public int _positiveModifier = 0;
    public int _totalDamage = 0;

    public ActionType _actionType;
    public MeleeActions _meleeActions;
    public RangedActions _rangedActions;
    public Magic _magic;


    //These are just a reference of all the Actions available. Might be nice to have actually. Simple way to toggle availability.
    //if(bowEquipped){RangedActions = true} kinda thing

    public void PerformAction()
    {
        Debug.Log("You performed Action: " + _name + "and dealt " + _totalDamage);
        //You performed "action", roll yDx with "modifier" _archetypeValue + _coreSkillValue;
        //You performed "action", it was modified by "augment".
    }

    public enum ActionType
    {
        NONE,
        MELEE,
        MOVEMENT,
        GENERAL,
    }

    public enum MeleeActions
    {
        NONE,
        ATTACK,
        BLOCK,
        PARRY,
        EVADE,
        FEINT,
        RIPOSTE,
        DISARM,
        CHARGE,
        SHIELDBASH,
        MURDERSTROKE,
        QUICKDRAW

    }
    public enum RangedActions
    {
        NONE,
        AIM,
        DRAW,
        RELOAD,

    }

    public enum Magic
    {
        NONE,
        CASTMAGIC,
        ACTIVATERUNE,
        ACTIVATESIGIL,
    }

}
