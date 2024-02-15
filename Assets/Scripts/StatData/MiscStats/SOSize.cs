using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSizeStat", menuName = "Data/SizeData")]
public class SOSize : ScriptableObject
{
    [SerializeField] private SerializableDictionary<string, int> sizeDictionary = new SerializableDictionary<string, int>();

    public Dictionary<string, int> GetSizeDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < sizeDictionary.keys.Count; i++)
        {
            dictionary[sizeDictionary.keys[i]] = sizeDictionary.values[i];
        }
        return dictionary;
    }
}
