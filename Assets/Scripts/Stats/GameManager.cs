using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Handle Turns
// 


public class GameManager : MonoBehaviour
{
    ArchetypeManager _archetypeManager;
    RandomStats _randomStats;

    public int _actionPoints = 3;
    public int _baselineAPR = 3;
    public int _initiative = 0;

    
    List<int> _baseStatList = new List<int>();
    
    public int _health = 0;
    public int _maxHealth = 100;
    public int _minHealth = 0;
    public int _totalDamage;
    public int _bonusDamageMod;

    public int _maxWalkDistance;

    
    public Size _sizeEnum;
    public int _gargantuanDamageModifier;
    public int _gargantuanWalkModifier;
    public Traits _traitsEnum;
    public List<Traits> _traitsEnumList = new List<Traits>(); //Use to add more than 1 trait when applicable
    public PlayerRaces _playerRacesEnum;
    public List<PlayerRaces> _playerRacesEnumList = new List<PlayerRaces>();
    
    public int _size = 10;

    public int _armourValue;
    public int _naturalArmorValue;

    public int _archetypeSkillValue;
    public int _coreSkillValue;

    private int _gainPoint;

   public int UpdateInitiative(int initiative) //Keeping this as a warning. Increments Initiative for each RandomRoll
    {
        initiative = 0;
        return initiative;
    }

    private void Awake()
    {
        _archetypeManager = GetComponent<ArchetypeManager>();
        _randomStats = GetComponent<RandomStats>();        
    }
    public void Start()
    {
        _health = _maxHealth;
        
        CalculateRaceModifiers();
        Debug.Log("Agility after Nimble modifier: " + _randomStats.FindStatValueByName("Agility"));
        CalculateSizeModifiers();               
        CalculateActionPoints();        
        //RollArchetypeStatDistribution();
        CalculateMaxHealth();

        PrintBaseStatList();
        _archetypeManager._archetypes["Athletics"].Value += 14;
    }

    private void Update()
    {
        CalculateMaxHealth();
        UpdateInitiative(_initiative);
    }
    public void PrintBaseStatList()
    {
        foreach (var entry in _baseStatList)
        {
            //Debug.Log("Base Stat List Entry: " + entry);
        }
    } 
    
    private void LogList( List<int> list )
    {
        string logString = "List contents: ";

        foreach (int item in list)
        {
            logString += item.ToString() + ", ";
        }

        // Remove the trailing comma and space
        logString = logString.TrimEnd(' ', ',');

        Debug.Log(logString);
    }
    void CalculateTotalDamage(int baseDmg, int bonusDmg)
    {
        _totalDamage += baseDmg + bonusDmg;
    }

    void CalculateBonusDamage()
    {

        // Requires Core skills being calculated

        // _bonusDamageMod = 
        // Stat mods
        // Weapon mods
        // Equipment mods
        // Augment mods
    }

    public void CalculateSizeModifiers()
    {
        switch (_sizeEnum)
        {
            case Size.TINY:
                _bonusDamageMod -= 2;
                _maxWalkDistance -= 2;
                break;
            case Size.SMALL:
                _bonusDamageMod -= 1;
                _maxWalkDistance -= 1;
                break;
            case Size.MEDIUM:
                _bonusDamageMod += 0;
                _maxWalkDistance += 0;
                break;
            case Size.LARGE:
                _bonusDamageMod += 1;
                _maxWalkDistance += 1;
                break;
            case Size.HUGE:
                _bonusDamageMod += 2;
                _maxWalkDistance += 2;
                break;
            case Size.GARGANTUAN:
                _bonusDamageMod += _gargantuanDamageModifier;
                _maxWalkDistance += _gargantuanWalkModifier;
                break;
        }
    }
    

    public void CalculateRaceModifiers()
    {
        _traitsEnumList.Clear();
        _size = 0;
        switch (_playerRacesEnum)
        {
            case PlayerRaces.DWARF:
                _size += DiceRoll(4) + 1;
                _sizeEnum = Size.MEDIUM;
                _traitsEnumList.AddRange(new[] { Traits.STOUT, Traits.BRAWN, Traits.STALWART });
                Debug.Log("added Trait: " + _traitsEnum);

                //_traitsEnum = Traits.BRAWN;
                //_traitsEnum = Traits.STALWART;
                break;
            case PlayerRaces.ELF:
                _size += DiceRoll(6) + 2;
                _sizeEnum = Size.MEDIUM;
                _traitsEnumList.AddRange(new[] { Traits.VIGILANT, Traits.NIMBLE });

                break;
            case PlayerRaces.HUMAN:
                _size += DiceRoll(6) + 4;
                _sizeEnum = Size.MEDIUM;
                _traitsEnumList.AddRange(new[] { Traits.CLEVER, Traits.IRONMIND });

                break;
            case PlayerRaces.HALFLING:
                _size -= DiceRoll(4) + 2;
                _sizeEnum = Size.SMALL;
                _traitsEnumList.AddRange(new[] { Traits.NIMBLE, Traits.OBSERVANT, });

                break;
            case PlayerRaces.GNOME:
                _size -= DiceRoll(4) - 2;
                _traitsEnumList.AddRange(new[] { Traits.CLEVER, Traits.INGENIOUS });
                _sizeEnum = Size.TINY;
                
                break;
            case PlayerRaces.GOBLIN:
                _size -= DiceRoll(4) - 1;
                _traitsEnumList.AddRange(new[] { Traits.NIMBLE, Traits.INGENIOUS });
                _sizeEnum = Size.SMALL;
                break;                
        }
        UpdateInitiative(_initiative);
    }
    public void CalculateActionPoints()
    {
        _actionPoints = _baselineAPR;
        int temp = 0;
        temp = _randomStats.FindStatValueByName("Agility") / 2;
        _actionPoints += temp;
    }

    public void CalculateTraitModifiers()
    {
        
        foreach (var trait in _traitsEnumList)
        {
            if (trait == Traits.BRAWN) { IncrementStat("Strength", 1); }
            if (trait == Traits.CLEVER) { IncrementStat("Intellect", 1); }
            if (trait == Traits.DIMINUTIVE) { _size -= 2; }
            if (trait == Traits.IRONMIND) { IncrementStat("Will", 1); }
            if (trait == Traits.NIMBLE) { IncrementStat("Agility", 1); }
            if (trait == Traits.INGENIOUS) { _archetypeManager._archetypes["Engineering"].Value += 7; }
            if (trait == Traits.IRONSKIN) { _naturalArmorValue += 1; }
            if (trait == Traits.OBSERVANT) { IncrementStat("Perception", 1); }
            if (trait == Traits.QUICK) { _actionPoints += 1; }
            if (trait == Traits.QUICK) { _actionPoints += 2; }
            if (trait == Traits.STALWART) { IncrementStat("Stamina", 1); }
            if (trait == Traits.STOUT) { _maxHealth += DiceRoll(4) + DiceRoll(4); }
            // TODO: Game Manager: Talented Trait; Get from CoreSkill List. Not sure how I imagined this one to work. "Core Skill Point gain counts as 2.**"
            // Change it to give +x in chosen Archetype?
            //if (trait == Traits.TALENTED) {  } 
            if (trait == Traits.VIGILANT) { _initiative += 1; }
        }       
    }



    public int IncrementCoreSkillValues( int coreSkill ){ return coreSkill += 1; }
    public int DecrementCoreSkillValue( int coreSkill ) {  return coreSkill -= 1; }

    public void UpdateHealth()
    {

    }
    public void CalculateMaxHealth() 
    { 
        _maxHealth = 0;
        int calculatedSize = 0;
        _maxHealth = 10 + _size + _archetypeManager._archetypes["Athletics"].Value + _randomStats.FindStatValueByName("Stamina");
        calculatedSize = 10 + _size;

        _health = _maxHealth;
    }
    void AddArchetypeValue(string selectedArchetype)
    {
        if (_archetypeSkillValue < 14)
        {
            _archetypeManager._archetypes[selectedArchetype].Value += _gainPoint;
        }
    }
    public int DiceRoll( int maxValue )
    {
        int result = UnityEngine.Random.Range(1, maxValue + 1);
        return result;
    }

    public int IncrementStat( string name, int incrementValue ) //This function does not work as expected
    {
        Stat statToIncrement = _randomStats.statList.Find(stat => stat.statName == name);

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
}

[System.Serializable]
public enum PlayerRaces
{
    ELF,
    HUMAN,
    HALFLING,
    GNOME,
    GOBLIN,
    DWARF,
    TROLL,
}

[System.Serializable]
public enum Size
{
    TINY,
    SMALL,
    MEDIUM,
    LARGE,
    HUGE,
    GARGANTUAN,
}

[System.Serializable]
public enum EnemyRaces
{
    DRAGON,
    TROLL,
    URUK,
    GREATBIRD,
    FACELESS,
    PALEMAN,


}
[System.Serializable]
public enum Traits
{
    NIMBLE,
    BRAWN,
    STALWART,
    CLEVER,
    IRONMIND,
    OBSERVANT,
    QUICK,
    QUICKER,
    STOUT,
    IRONSKIN,
    VIGILANT,
    TALENTED,
    DIMINUTIVE,
    BURLY,
    INGENIOUS,
}