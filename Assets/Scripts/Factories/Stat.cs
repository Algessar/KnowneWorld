using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Stat
{
    public string statName;
    public int value;
    public Stat( int value, string statName )
    {
        this.statName = statName;
        this.value = value;
    }
}
