using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Stat", menuName = "Data/StatData")]
public class SOStatData : ScriptableObject
{
    [SerializeField]
    private SerializableDictionary<string, int> statDictionary = new SerializableDictionary<string, int>();
       
    public Dictionary<string, int> GetStatDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < statDictionary.keys.Count; i++)
        {
            dictionary[statDictionary.keys[i]] = statDictionary.values[i];
        }
        return dictionary;
    }
}
