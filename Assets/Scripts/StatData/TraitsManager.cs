using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Do I want to keep this class? It almost seems superfluous. I could move all these functions directly to the Character class. But I'm also not sure that is
//a good idea either. This is something that will be done at creation and not continually during the character's life so to speak.

public class TraitsManager : MonoBehaviour
{
    public static TraitsManager Instance;

    

    public Size _sizeEnum;
    public int _gargantuanDamageModifier;
    public int _gargantuanWalkModifier;
    public Traits _traitsEnum;
    public List<Traits> _traitsEnumList = new List<Traits>(); //Use to add more than 1 trait when applicable
    public CharacterRace _playerRacesEnum;
    public List<CharacterRace> _playerRacesEnumList = new List<CharacterRace>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        
    }
   // public void CalculateRaceModifiers(Character character, CharacterRace characterRace, int size) //This method should only add the enums to the characters lists.
   // {
   //     _traitsEnumList.Clear();
   //     
   //     switch (characterRace)
   //     {
   //         case CharacterRace.DWARF:
   //             character._sizeEnum = Size.MEDIUM;
   //             character._size += DiceRoll(0, 4) + 1; //Move this to CalcSizeModifiers?
   //             character._characterTraits.AddRange(new[] { Traits.STOUT, Traits.BRAWN, Traits.STALWART });
   //             Debug.Log("added Trait: " + _traitsEnum);
   //
   //             //_traitsEnum = Traits.BRAWN;
   //             //_traitsEnum = Traits.STALWART;
   //             break;
   //         case CharacterRace.ELF:
   //             size += DiceRoll(0, 6) + 2;
   //             character._sizeEnum = Size.MEDIUM;
   //             character._characterTraits.AddRange(new[] { Traits.VIGILANT, Traits.NIMBLE });
   //
   //             break;
   //         case CharacterRace.HUMAN:
   //             size += DiceRoll(0, 6) + 4;
   //             character._sizeEnum = Size.MEDIUM;
   //             character._characterTraits.AddRange(new[] { Traits.CLEVER, Traits.IRONMIND });
   //
   //             break;
   //         case CharacterRace.HALFLING:
   //             size -= DiceRoll(0, 4) + 2;
   //             character._sizeEnum = Size.SMALL;
   //             character._characterTraits.AddRange(new[] { Traits.NIMBLE, Traits.OBSERVANT, });
   //
   //             break;
   //         case CharacterRace.GNOME:
   //             size -= DiceRoll(0, 4) - 2;
   //             character._characterTraits.AddRange(new[] { Traits.CLEVER, Traits.INGENIOUS });
   //             character._sizeEnum = Size.TINY;
   //
   //             break;
   //         case CharacterRace.GOBLIN:
   //             size -= DiceRoll(0, 4) - 1;
   //             character._characterTraits.AddRange(new[] { Traits.NIMBLE, Traits.INGENIOUS });
   //             character._sizeEnum = Size.SMALL;
   //             break;
   //     }
   //
   // }
    public void CalculateSizeModifiers( Size sizeEnum, int bonusDamageMod, int walkDistanceMod )
    {
        switch (sizeEnum)
        {
            case Size.TINY:
                bonusDamageMod -= 2;
                walkDistanceMod -= 2;
                break;
            case Size.SMALL:
                bonusDamageMod -= 1;
                walkDistanceMod -= 1;
                break;
            case Size.MEDIUM:
                bonusDamageMod += 0;
                walkDistanceMod += 0;
                break;
            case Size.LARGE:
                bonusDamageMod += 1;
                walkDistanceMod += 1;
                break;
            case Size.HUGE:
                bonusDamageMod += 2;
                walkDistanceMod += 2;
                break;
            case Size.GARGANTUAN:
                bonusDamageMod += _gargantuanDamageModifier;
                walkDistanceMod += _gargantuanWalkModifier;
                break;
        }
    }

    public void CalculateTraitModifiers(Character character)
    {
  
        foreach (var trait in _traitsEnumList)
        {
            if (trait == Traits.BRAWN) { character.IncrementStat("Strength", 1); }
            if (trait == Traits.CLEVER) { character.IncrementStat("Intellect", 1); }
            if (trait == Traits.DIMINUTIVE) { character._size -= 2; } // TODO: This needs looking over
            if (trait == Traits.IRONMIND) { character.IncrementStat("Will", 1); }
            if (trait == Traits.NIMBLE) { character.IncrementStat("Agility", 1); }
            if (trait == Traits.INGENIOUS) { }
            //{ character._archetypeManager._archetypes["Engineering"].Value += 7; }
            if (trait == Traits.IRONSKIN) { character._naturalArmorValue += 1; }
            if (trait == Traits.OBSERVANT) { character.IncrementStat("Perception", 1); }
            if (trait == Traits.QUICK) { character._actionPoints += 1; }
            if (trait == Traits.QUICK) { character._actionPoints += 2; }
            if (trait == Traits.STALWART) { character.IncrementStat("Stamina", 1); }
            if (trait == Traits.STOUT) { character._maxHealth += DiceRoll(0, 4) + DiceRoll(0, 4); }
            // TODO: Game Manager: Talented Trait; Get from CoreSkill List. Not sure how I imagined this one to work. "Core Skill Point gain counts as 2.**"
            // Change it to give +x in chosen Archetype?
            //if (trait == Traits.TALENTED) {  } 
            if (trait == Traits.VIGILANT) { character._initiative += 1; }
        }
    }

    public int DiceRoll(int min, int max)
    {
        return DiceRoller.Roll(min, max);
    }

}
