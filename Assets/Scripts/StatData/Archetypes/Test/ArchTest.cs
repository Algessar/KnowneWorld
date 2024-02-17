using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Archetype", menuName = "Test/TestArchetype")]
public class ArchTest : ScriptableObject
{
    public CoreTest coreSkillSO;
    [SerializeField] List<Stat> coreSkillStats = new List<Stat>();

    [SerializeField]
    public SerializableDictionary<string, int> archetypeDictionary = new SerializableDictionary<string, int>();

    public Dictionary<string, int> GetArchetypeDictionary()
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < archetypeDictionary.keys.Count; i++)
        {
            dictionary[archetypeDictionary.keys[i]] = archetypeDictionary.values[i];
        }

        return dictionary;
    }

    private void Awake()
    {
        //GetCoreSkillList();
    }

    public List<Stat> GetCoreSkillList()
    {

        //This should likely be separated out, so that the CoreList wont be overwritten each time.
        coreSkillStats.Clear();
        var statCreator = new StatCreator();
        var coreSkillSO = ScriptableObject.CreateInstance<CoreTest>();
        coreSkillStats = statCreator.TestPopulateCoreList(coreSkillSO);
        return coreSkillStats;
    }

 
}
