using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public string _name;
    public int _characterID;



    public int _health;
    public int _minHealth;
    public int _maxHealth;
    public int _energy;

    public int _maxWalkDistance = 0;

    public List<Stat> _savedStatList = new List<Stat>();
    public List<Stat> _archetypeList;
    public List<Stat> _coreSkillList;

    public int _actionPoints;
    public int _initiative;

    [Header("Magic")]
    private List<SOEffectWord> _knownEffectWords;


    [Header("Damage")]
    public int _totalDamage = 0;
    public int _bonusDamageMod = 0;

    [Header("Defences")]
    public int _armourValue = 0;
    public int _naturalArmorValue = 0;
    public int _magicalProtection = 0;

    [Header("Secondary/Traits")]
    public CharacterRace _characterRace;

    public int _size;
    public List<Stat> _sizeList = new List<Stat>();
    public List<Traits> _characterTraits = new List<Traits>();

    [Header("Inventory")]
    public List<SOEquipmentObject> _itemsInInventory;
    public List<SOEquipmentObject> _equippedItems;
    public PlayerData( Character character )
    {
        _name = character._name;

        _health = character._currentHealth;
        _minHealth = character._minHealth;
        _maxHealth = character._maxHealth;

        _energy = character._energy;
        _maxWalkDistance = character._maxWalkDistance;

        _savedStatList = character._statList;
        _archetypeList = character._archetypeList;
        _coreSkillList = character._coreSkillList;


        _actionPoints = character._actionPoints;
        _initiative = character._initiative;

        _totalDamage = character._totalDamage;
        _bonusDamageMod = character._bonusDamageMod;

        _armourValue = character._armourValue;
        _naturalArmorValue = character._naturalArmorValue;
        _magicalProtection = character._magicalProtection;

        _characterRace = character._characterRace;

        _size = character._size;
        //_sizeList = character._sizeList;
        _characterTraits = character._characterTraits;

        //_itemsInInventory = character._itemsInInventory;
        //_equippedItems = character._equippedItems;
    }

}
