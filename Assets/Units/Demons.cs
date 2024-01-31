using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demons : MonoBehaviour
{

    public string _demonName;    

    public ScriptableObject[] _actions; //Show all available actions in a convenient list somewhere

    public int _actionPoints = 3;
    public int _baselineAPR = 3;
    private int _gainActionPoint = 0;
    public int _initiative = 0;

    public int _maxWalkDistance = 0;
    public int _size = 10;

    public int _level;
    public int _voidPower = 0; 
    public int _maxVoidPower = 0; // level * 10
    public int _minVoidPower = 0;
    public int _voidPowerPool = 0; // The pool where you dump Void to use for an ability.

    public int _health = 0;
    public int _maxHealth = 100;
    public int _minHealth = 0;

    public int _totalDamage = 0;
    public int _bonusDamageMod = 0;

    public int _armourValue = 0;
    public int _naturalArmorValue = 0;    

    public ScriptableObject[] _defaultPowers = null;

    //These can likely be Scriptables

    public enum DemonWeakness
    {
        LIGHT,
        HERB1,
        HERB2,
        MAGIC,

    }
    public enum SharedDemonicAbilities
    {
        DARKVISION,
        POSSESS,
        SHADE_ILLUSION,
        EMPATHIC_READING,
        EMPATHIC_EMPOWERMENT,
    }

    public enum DemonicPowers
    {
        NONE = 0,
        SHADOWSTEP,
        SHADOW_CLOAK,
        VOID_SCYTHE, //Instant cleave effect
        VOID_BLADE, // Summoned blade, functions as a normal martial blade
        SHADE_SKIN, //NATURAL ARMOUR
        WITHERING_TOUCH, //deals Necrotic damage to the target.
        TERROR, //FORCE A ROLL ON WILL; FAILURE INCREASES THE POINTS ON THE FEAR TABLE BY x _voidPower
        DARKNESS, // SPREADS DARKNESS AROUND THE DEMON
        NECROTIC_AURA, // same as Wither, but weaker and in an area around the demon
        PLAGUE_AURA, // forces rolls on Stamina to not be inflicted by a Disease
    }
}
