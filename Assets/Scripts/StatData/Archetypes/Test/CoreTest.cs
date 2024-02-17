using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Core", menuName = "Test/TestCore")]
public class CoreTest : ScriptableObject
{
    [SerializeField]
    public SerializableDictionary<string, int> coreSkillDictionary = new SerializableDictionary<string, int>();

    public Dictionary<string, int> GetCoreDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < coreSkillDictionary.keys.Count; i++)
        {
            dictionary[coreSkillDictionary.keys[i]] = coreSkillDictionary.values[i];
        }

        return dictionary;
    }

}
