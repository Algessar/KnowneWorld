using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Archetype", menuName = "Data/CoreSkillsData")]
public class SOCoreSkillData : ScriptableObject
{
    [SerializeField]
    private SerializableDictionary<string, int> coreSkillsDictionary = new SerializableDictionary<string, int>();

    public Dictionary<string, int> GetCoreSkillDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < coreSkillsDictionary.keys.Count; i++)
        {
            dictionary[coreSkillsDictionary.keys[i]] = coreSkillsDictionary.values[i];
        }
        return dictionary;
    }

    public int GetCoreSkillValue( string key )
    {
        // Check if the key exists in the dictionary
        int index = coreSkillsDictionary.keys.IndexOf(key);

        if (index != -1)
        {
            return coreSkillsDictionary.values[index];
        }

        // Return a default value or handle the case where the key is not found
        return 0; // Default value (you can change it as needed)
    }

    
}