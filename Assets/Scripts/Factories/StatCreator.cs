using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCreator
{
    public List<Stat> statList = new List<Stat>();   
    public List<Stat> PopulateStatList()
    {
        var statData = DataManager.Instance._SOStatData;
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
        var archetypeData = DataManager.Instance._SOArchetypeData;
        statList.Clear();
    
        foreach (var kvp in archetypeData.GetArchetypeDictionary())
        {
            Stat newStat = new Stat((int)kvp.Value, kvp.Key);
            statList.Add(newStat);
        }
        return statList;
    }   
}
