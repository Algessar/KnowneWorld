using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Archetype", menuName = "Test/TestArchetype")]
public class ArchTest : ScriptableObject
{
    public CoreTest coreSkillSO;
    public List<Stat> coreSkillStats = new List<Stat>();

    [SerializeField]
    public SerializableDictionary<string, int> archetypeDictionary = new SerializableDictionary<string, int>();
    //[SerializeField]
    //public Dictionary<string, int> coreDictionary = new Dictionary<string, int>();

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
        //coreSkillStats.AddRange(GetCoreSkillList());
        coreSkillStats = GetCoreSkillList();
        
    }

    public List<Stat> GetCoreSkillList()
    {
        //coreSkillSO = CreateInstance<CoreTest>();
        //Get the CoreSO
        //coreSkillStats.Clear();
        var statCreator = new StatCreator();
       // coreSkillStats = new List<Stat>();
        coreSkillStats = statCreator.TestPopulateCoreList(coreSkillSO);
        
        return coreSkillStats;
    }

 
}
