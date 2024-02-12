using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{

    public int _health;
    public int _minHealth;
    public int _maxHealth;

    public List<Stat> _savedStatList = new List<Stat>();

    public PlayerData( Character character )
    {
        _savedStatList = character._statList;
        _health = character._currentHealth;
        _minHealth = character._minHealth;
        _maxHealth = character._maxHealth;
    }

}
