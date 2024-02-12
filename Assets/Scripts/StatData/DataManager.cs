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
    public SOArchetypeData _SOArchetypeData;

    public SOArchetypeData[] _SOArchetypes;

    [Header("Skills")]
    public List<SOActions>  _SOActionData;
    public List<SOAugmentations> _SOAugmentationData;

}

[System.Serializable]
public enum CharacterRace
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
