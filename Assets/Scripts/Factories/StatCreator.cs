using NUnit.Framework;
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
    public List<Stat> PopulateArchetypeList( SOArchetypeData archetypeData )
    {
        statList.Clear(); // Clear the list before populating it again

        foreach (var kvp in archetypeData.GetArchetypeDictionary())
        {
            Stat newStat = new Stat((int)kvp.Value, kvp.Key);
            statList.Add(newStat);
        }

        return statList;
    }

    public List<Stat> TestPopulateArchetypeList(  List<ArchTest> list ) //ArchTest archetypeData,
    {
        statList.Clear(); // Clear the list before populating it again

        foreach(var entry in list)
        {
            foreach (var kvp in entry.GetArchetypeDictionary())
            {
                Stat newStat = new Stat((int)kvp.Value, kvp.Key);
                statList.Add(newStat);
            }
        }       

        return statList;
    }

    public List<Stat> TestPopulateCoreList(CoreTest coreDataList )
    {
        statList.Clear(); // Clear the list before populating it again
        
            foreach (var kvp in coreDataList.GetCoreDictionary())
            {
                Stat newStat = new Stat((int)kvp.Value, kvp.Key);
                statList.Add(newStat);
            }
        

        return statList;
    }
    public List<Stat> PopulateSizeList(Stat newSize)
    {
        var sizeData = DataManager.Instance._SOSize;
        statList.Clear();

        foreach (var kvp in sizeData.GetSizeDictionary())
        {
            newSize = new Stat((int)kvp.Value, kvp.Key);
            statList.Add(newSize);
        }
        return statList;
    }
}
