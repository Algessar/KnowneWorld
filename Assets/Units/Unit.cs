using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //RandomStats _randomStats;

    public string _characterName;
    

    public ScriptableObject[] _actions; //Show all available actions in a convenient list somewhere

    public int _actionPoints = 3;
    public int _baselineAPR = 3;
    public int _initiative = 0;

    public int _maxWalkDistance = 0;
    public int _size = 10;

    
    public int _archetypeSkillValue = 0;
    public int _coreSkillValue = 0;

    public int _health = 0;
    public int _maxHealth = 100;
    public int _minHealth = 0;

    public int _totalDamage = 0;
    public int _bonusDamageMod = 0;

    public int _armourValue = 0;
    public int _naturalArmorValue = 0;

    private int _gainPoint;

}
