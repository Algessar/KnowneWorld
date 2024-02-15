using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Trait Data", menuName = "Data/TraitData")]
public class SOTraitsData : ScriptableObject
{
    [SerializeField] private SerializableDictionary<string, int> traitsDictionary = new SerializableDictionary<string, int>();

    public Dictionary<string, int> GetTraitDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < traitsDictionary.keys.Count; i++)
        {
            dictionary[traitsDictionary.keys[i]] = traitsDictionary.values[i];
        }
        return dictionary;
    }
}
