using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Effect Word", menuName = "Magic/Effect Word")]
public class EffectWordSO : ScriptableObject
{
    public string _name = string.Empty;
    public string _effectWord; // not sure what I intended this string to be
    public int _diceAmount = 0;
    public string _displayDiceSize = "D"; // This is meant to be used as a display for those who wants to use physical dice.
                                          // To make this, we will create a way to have _diceAmount + _displayDiceSize + _arcPower visible in the UI. 
    public int _arcPower = 0; // this number represents number of dice
    public int _range = 0;
    public int _area = 0;
    public int _spellActionCost;
    public int _skillModifier = 0;
    
    public string _ancientWord = string.Empty;

    public Sprite _spellIcon;
    
    public int DiceRoll()
    {
        return DiceRoller.Roll(1, _arcPower);
    }
}
