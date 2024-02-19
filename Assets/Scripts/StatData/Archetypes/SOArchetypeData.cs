using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New ArchetypeData", menuName = "Data/ArchetypeData")]
public class SOArchetypeData : ScriptableObject
{
   //public string _archetypeName;
   //public int _archetypeValue;
   //


    [SerializeField]
    public SerializableDictionary<string, int> archetypeDictionary = new SerializableDictionary<string, int>();

    [SerializeField]
    public SerializableDictionary<string, int> coreDictionary = new SerializableDictionary<string, int>();


    // public SOArchetypeData(string name, int value) 
    // {
    //     this._archetypeName = name;
    //     this._archetypeValue = value;
    // }

    public Dictionary<string, int> GetArchetypeDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
    
        for (int i = 0; i < archetypeDictionary.keys.Count; i++)
        {
            dictionary[archetypeDictionary.keys[i]] = archetypeDictionary.values[i];
        }
    
        return dictionary;
    }

    public Dictionary<string, int> GetCoreDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < coreDictionary.keys.Count; i++)
        {
            dictionary[coreDictionary.keys[i]] = coreDictionary.values[i];
        }

        return dictionary;
    }


}
