using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New EffectWord", menuName = "Magic/New EffectWord")]
public class SOEffectWord : ScriptableObject
{
    //public string _name = string.Empty; // I can probably remove this
    public string _effectWord; // string for internal use
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

    private void Awake()
    {
       
    }
    public int DiceRoll()
    {
        return DiceRoller.Roll(1, _arcPower);
    }
}
