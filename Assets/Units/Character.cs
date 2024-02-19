using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class Character : Actions, ITargetable //IUnit
{
    RandomStats _randomStats = new RandomStats();
    StatCreator _statCreator;
    ArchetypeManager _archetypeManager;

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
    public List<Stat> _coreSkillList;
   // public List<SOArchetypeData> _archetypeDataList = new List<SOArchetypeData>();

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
    public CharacterRace _characterRace;

    public int _size;
    public List<Stat> _sizeList = new List<Stat>();
    public List<Traits> _characterTraits = new List<Traits>();

    [Header("Inventory")]
    public List<SOEquipmentObject> _itemsInInventory;
    public List<SOEquipmentObject> _equippedItems;

    [Header("UI")]
    public GameObject _characterPortrait; //gameObject.GetComponent<Image>();
    public Character( )
    {
        this._playerName = "";
        this._name = "";       

        
        
        
    }
    public void OnCharacterCreated()
    {
        if (this != null)
        {
            //Debug.Log("A character with name ´" + _name + "´ has been created.");
            _randomStats = new RandomStats();
            _statCreator = new StatCreator();
        }
        CharacterSetup();

        var thing = DataManager.Instance._ArchTests[0].coreSkillStats;

        foreach (var skill in DataManager.Instance._ArchTests)
        {
            skill.coreSkillStats = thing;
            _coreSkillList = thing;
        }
    }
    private void CharacterSetup()
    {
        
        
        _archetypeManager = ArchetypeManager.Instance;
        _archetypeList = _archetypeManager._archetypeList;
        //_statList = new List<Stat>();
        
        _actionList = DataManager.Instance._SOActionData;

        InitArchetypes();
        //_sizeList.value = GameManager.Instance._size;        
        //MergeArchetypeLists();
        //CalculateActionPoints();

        //int test = FindStatValueByName(_archetypeList, "Distillation");       
    }

    void InitArchetypes()
    {

       //ArchetypeManager.Instance.SetInitialArchetypeValue(_statList, "Alchemy", "Intellect", "Agility");
       //ArchetypeManager.Instance.SetInitialArchetypeValue(_statList, "Athletics", "Strength", "Agility");
       //ArchetypeManager.Instance.SetInitialArchetypeValue(_statList, "Defence", "Strength", "Agility");
       //ArchetypeManager.Instance.SetInitialArchetypeValue(_statList, "Engineering", "Intellect", "Agility");
       //ArchetypeManager.Instance.SetInitialArchetypeValue(_statList, "Investigation", "Intellect", "Perception");
    }



  //  void MergeArchetypeLists()
  //  {
  //      _archetypeList = new List<Stat>();
  //      _archetypeList.Clear(); // Clear the existing list before populating it again
  //
  //      foreach (var archetypeData in _archetypeDataList)
  //      {
  //          List<Stat> statsFromArchetype = _statCreator.PopulateArchetypeList(archetypeData);
  //          _archetypeList.AddRange(statsFromArchetype);
  //      }
  //  }
    public int CalculateActionPoints()
    {
        _actionPoints = _baselineAPR;
        int temp = 0;
        temp = FindStatValueByName( _statList, "Agility") / 2;
        return _actionPoints += temp;
    }


    private int CalculateMeleeBaseDamage(string _coreValue)
    {
        _totalDamage += this.FindStatValueByName(_archetypeList, _coreValue); //TODO: Character: Damage: How do I make this modular?
        _totalDamage += _bonusDamageMod;

        return _totalDamage;

    }

    public int CalculateTotalDamage(int weaponListIndex, string corevalue)
    {
        //equipped weapon
        //stat bonuses
        _itemsInInventory.GetRange(weaponListIndex, 1);
        
        
         int baseDamage = CalculateMeleeBaseDamage(corevalue);
         int totalWeaponDamage = _itemsInInventory[weaponListIndex].GetTotalDamage();
         _totalDamage += baseDamage + totalWeaponDamage;
        
        return _totalDamage;
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
    public  void TakeDamage( int damage, int reduction )
    {
        string dmgString = GameManager.Instance._takeDamageInput.text;        
        damage = dmgString.ConvertTo<int>();
        _currentHealth -= damage;


    }
    public  void DealDamage( int bonusDamage )
    {
        string dmgString = GameManager.Instance._dealDamageInput.text;
        int damage = dmgString.ConvertTo<int>();
        damage += _bonusDamageMod;       

        GameManager.Instance._showDamageOutput.text = damage.ToString();
        
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
        //Debug.Log("Showing stat value for " + name + ": " + statValue);
        return statValue;
    }

   // public override void Attack( Character character )
   // {
   //     base.Attack(character);
   // }

    #endregion

}
