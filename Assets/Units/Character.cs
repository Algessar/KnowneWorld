using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class Character : Actions, IUnit, ITargetable
{
    RandomStats _randomStats = new RandomStats();  

    public string _playerName;
    public string _name;
    public int _playerID;
    public int _characterID;

    [Header("Stats")]
    public int _currentHealth = 0;
    public int _minHealth = 0;
    public int _maxHealth = 100;

    public List<Stat> _statList;
    public List<Stat> _archetypeList;
    [Space (20)]
        
    [Header("Actions")]
    private int _baselineAPR = 3;
    public int _actionPoints;
    public int _initiative;

    public int _energy;

    public int _maxWalkDistance = 0;
    private List<SOActions> _actionList;
    private List<SOAugmentations> _knownAugmentationsList;
    //private List<SOAugmentations> _activeAugmentations;

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
    public int _size;
    public CharacterRace _characterRace;
    public Size _sizeEnum;
    public List<Traits> _characterTraits = new List<Traits>();

    [Header("Inventory")]
    public List<SO_Items> _items;

    [Header("UI")]
    public GameObject _characterPortrait; //gameObject.GetComponent<Image>();
    public Character( )
    {
        this._playerName = "";
        this._name = "";

        _randomStats = new RandomStats();

    }
    public void OnCharacterCreated()
    {
        if (this != null)
        {
            Debug.Log("A character with name " + _name + " has been created.");
        }
        CharacterSetup();
       
    }
    public void CharacterSetup()
    {
        _statList = _randomStats.AssignAllRandom();
        //TraitsManager.Instance.CalculateRaceModifiers(this, _characterRace, _size);
        //TraitsManager.Instance.CalculateSizeModifiers(_sizeEnum, _bonusDamageMod, _maxWalkDistance);
        CalculateActionPoints();
     //   CalculateMaxHealth(); //TODO: Not implemented CalculateMaxHealth();

        _actionList = DataManager.Instance._SOActionData;
        
    }
    public int CalculateActionPoints()
    {
        _actionPoints = _baselineAPR;
        int temp = 0;
        temp = FindStatValueByName( _statList, "Agility") / 2;
        return _actionPoints += temp;
    }

    public void CalculateMaxHealth()
    {
        _maxHealth = 0;
        int calculatedSize = 0;
        _maxHealth = 10 + _size + this.FindStatValueByName(_archetypeList, "Athletics") + this.FindStatValueByName(_statList, "Stamina");
        //calculatedSize = 10 + _size;

        _currentHealth = _maxHealth;
    }


    // Functionality for using skills
    // Functionality for using magic
    // 


    private void AddKnownEffectWord(SOEffectWord effectWord)
    {
        _knownEffectWords.Add(effectWord);
    }

    public int IncrementStat( string name, int incrementValue ) //This function does not work as expected
    {
        Stat statToIncrement = _statList.Find(stat => stat.statName == name);

        if (statToIncrement != null)
        {
            statToIncrement.value += incrementValue;
            Debug.Log($"{name} incremented by {incrementValue}. New value: {statToIncrement.value}");
            return statToIncrement.value;
        }
        else
        {
            Debug.LogError($"Stat {name} not found.");
        }
        return 0;
    }
    public void TakeDamage( int damage, int reduction )
    {   
        _currentHealth -= damage;


    }
    public void DealDamage( int damage, int bonusDamage )
    {
        throw new NotImplementedException();
    }

    #region Utilities/Search

    public int FindStatValueByName(List<Stat> statList, string name )
    {
        int statValue = 0;
        foreach (Stat stat in statList)
        {
            Stat statToFind = statList.Find(stat => stat.statName == name);
            statValue = statToFind.value;
        }
        return statValue;
    }

   // public override void Attack( Character character )
   // {
   //     base.Attack(character);
   // }

    #endregion

}
