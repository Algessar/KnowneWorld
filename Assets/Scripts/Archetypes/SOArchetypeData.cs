using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "New Archetype", menuName = "Data/ArchetypeData")]
public class SOArchetypeData : ScriptableObject
{
        
    [SerializeField]
    public SerializableDictionary<string, int> archetypeDictionary = new SerializableDictionary<string, int>();


    //Dictionary<string, int > _archetypeDictionary = new Dictionary<string, int>();
    //public List<string> archetypeNames = new List<string>();
    
    public Dictionary<string, int> GetArchetypeDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
    
        for (int i = 0; i < archetypeDictionary.keys.Count; i++)
        {
            dictionary[archetypeDictionary.keys[i]] = archetypeDictionary.values[i];
        }
    
        return dictionary;
    }
    public int GetArchetypeValue( string key )
    {
        // Check if the key exists in the dictionary
        int index = archetypeDictionary.keys.IndexOf(key);

        if (index != -1)
        {
            return archetypeDictionary.values[index];
        }

        // Return a default value or handle the case where the key is not found
        return 0; // Default value (you can change it as needed)
    }

    public string GetArchetypeName( string key ) 
    {
        return archetypeDictionary.ToString();
    }



    // _archetypeData._archetypeDictionary = new Dictionary<string, int>
    //     {
    //         { "Alchemy", 0 },
    //         { "Athletics", 0 },
    //         { "Crafting", 0 },
    //         { "Defense", 0 },
    //         { "Engineering", 0 },
    //         { "Investigation", 0 },
    //         { "Knowledge", 0 },
    //         { "Magic", 0 },
    //         { "Martial", 0 },
    //         { "Social", 0 },
    //         { "Survival", 0},
    //     };

}
