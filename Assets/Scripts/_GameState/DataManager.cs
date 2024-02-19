using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance { get; private set; }

    //SINGLETON!
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

    [Header("Stats")]
    public SOStatData _SOStatData;
    public SOSize _SOSize;
    public List<SOSize> _SOSizeList;

    public SOStatData _SOArchetypeData;
    public SOStatData _SOCoreData;

   // //public SOArchetypeData[] _SOArchetypes;
   // [HideInInspector] public List<ArchTest> _ArchTests = new List<ArchTest>();
   // [HideInInspector] public List<CoreTest> _CoreTests = new List<CoreTest>();
   // [HideInInspector] public ArchTest _ArchTest;

    [Header("Skills")]
    public List<SOActions>  _SOActionData = new List<SOActions>();
    public List<SOAugmentations> _SOAugmentationData = new List<SOAugmentations>();

    public List<SO_Items> _itemsExistingInWorld; //reference for GM    

}

[System.Serializable]

//TODO: Change all these fucking enums to scriptableObjects
public enum CharacterRace
{
    HUMAN,
    ELF,
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

public enum ActionType
{
    NONE,
    MELEE,
    MOVEMENT,
    GENERAL,
}

public enum MeleeActionsEnum
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

public enum EquipmentType
{
    ARMOUR,
    WEAPON,
    SHIELD,
    RING,
    NECKLACE,
}
