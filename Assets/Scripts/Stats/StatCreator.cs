using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCreator : MonoBehaviour
{
    public List<Stat> statList = new List<Stat>();
    public SOStatData statData;
    public SOArchetypeData archetypeData;
    public SOCoreSkillData coreSkillData;
    public List<Stat> PopulateStatList()
    {
        statList.Clear();

        foreach (var kvp in statData.GetStatDictionary())
        {
            Stat newStat = new Stat((int)kvp.Value, kvp.Key);
            statList.Add(newStat);
        }
        return statList;
    }
    
    public List<Stat> PopulateArchetypeList()
    {
        statList.Clear();
    
        foreach (var kvp in archetypeData.GetArchetypeDictionary())
        {
            Stat newStat = new Stat((int)kvp.Value, kvp.Key);
            statList.Add(newStat);
        }
        return statList;
    }
    
    public List<Stat> PopulateCoreSkillList()
    {
        statList.Clear();
    
        foreach (var kvp in coreSkillData.GetCoreSkillDictionary())
        {
            Stat newStat = new Stat((int)kvp.Value, kvp.Key);
            statList.Add(newStat);
        }
        return statList;
    }
}
