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
    public Actions _meleeActions;
    public RangedActions _rangedActions;
    public Magic _magic;


}
