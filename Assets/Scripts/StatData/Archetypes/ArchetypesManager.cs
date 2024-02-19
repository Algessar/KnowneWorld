using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using Unity.VisualScripting.Antlr3.Runtime.Collections;

//TODO: All this was probably unnecessary. 

public class ArchetypeManager : MonoBehaviour
{

    public static ArchetypeManager Instance;
    public List<Stat> _archetypeList = new List<Stat>();
    public List<Stat> _coreList1 = new List<Stat>();
    public List<Stat> _coreList2 = new List<Stat>();
    public List<Stat> _coreList3 = new List<Stat>();
    public List<Stat> _coreList4 = new List<Stat>();
    public List<Stat> _coreList5 = new List<Stat>();
    public List<Stat> _coreList6 = new List<Stat>();
    public List<Stat> _coreList7 = new List<Stat>();
    public List<Stat> _coreList8 = new List<Stat>();
    public List<Stat> _coreList9 = new List<Stat>();
    public List<Stat> _coreList10 = new List<Stat>();
    public List<Stat> _coreList11 = new List<Stat>();

    public List<ArchTest> _archetypeSOList = new List<ArchTest>();
    public List<CoreTest> _coreSOList = new List<CoreTest>();

    List<List<Stat>> list = new List<List<Stat>>();

    Character _character;
    StatCreator _statCreator;




    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        _statCreator = new StatCreator();
        
    }
    private void Start()
    {
        _archetypeSOList.Clear();
        _archetypeSOList.AddRange(DataManager.Instance._ArchTests);
        _archetypeList = testingArchetype(_archetypeList);

        CoreList(_coreSOList);
        
        TestingCoreSkill();

        //SetArchetypeFromStats();
        //AssignArchetypeValues();
    }
    public List<Stat> testingArchetype(List<Stat> list)
    {
        var statCreator = new StatCreator();
        list = new List<Stat>();

        for (int i = 0; i < DataManager.Instance._ArchTests.Count; i++)
        {
            list = statCreator.TestPopulateArchetypeList(DataManager.Instance._ArchTests);
        }        
        
        return list;
    }

    public void CoreList(List<CoreTest> coreSOs)
    {
        foreach(var entry in DataManager.Instance._ArchTests)
        {
            coreSOs.Add(entry.coreSkillSO);
        }
  
    }
    private void TestingCoreSkill()
    {
        var data = DataManager.Instance._ArchTests;

        _coreList1 = data[0].coreSkillStats;
        _coreList2 = data[1].coreSkillStats;
        _coreList3 = data[2].coreSkillStats;
        _coreList4 = data[3].coreSkillStats;
        _coreList5 = data[4].coreSkillStats;
        _coreList6 = data[5].coreSkillStats;
        _coreList7 = data[6].coreSkillStats;
        _coreList8 = data[7].coreSkillStats;
        _coreList9 = data[8].coreSkillStats;
        _coreList10 = data[9].coreSkillStats;
        _coreList11 = data[10].coreSkillStats;

    }

    void AssignArchetypeValues()
    {
        //var data = DataManager.Instance._ArchTests;
        foreach (Stat stat in _archetypeList)
        {
            string name = stat.statName;
            //FindStatValueByName(_archetypeList, name);
            int value = 0;//FindStatValueByName(_archetypeList, name);
            value = Random.Range(4, 10);
            stat.value = value;

            Debug.Log(value);
        }
    }

    public void SetArchetypeFromStats()
    {
        //IncrementStat(_archetypeList, "Alchemy", 5);
        
        //SetInitialArchetypeValue(_character._statList, "Alchemy", "Intellect", "Agility");
    }

    void IncrementStat( List<Stat> statList, string name, int incrementValue )
    {
        int statValue = 0;
        foreach (Stat stat in statList)
        {
            Stat statToFind = statList.Find(stat => stat.statName == name);
            statValue = statToFind.value;
            statToFind.value = incrementValue;
        }
    }

    public int SetInitialArchetypeValue( List<Stat> statList,string archetypeName , string baseStatName1,string baseStatName2)
    {
        int archValue1 = 0;
        int archValue2 = 0;
        foreach (Stat stat in statList)
        {
            Stat statToFind = statList.Find(stat => stat.statName == baseStatName1);
            archValue1 = statToFind.value;
            statToFind.value = archValue1;
        }
        foreach (Stat stat in statList)
        {
            Stat statToFind = statList.Find(stat => stat.statName == baseStatName2);
            archValue1 = statToFind.value;
            statToFind.value = archValue2;
        }

        int final = archValue1 + (archValue2 / 2);
        return final;
        //FindStatValueByName(statList, archetypeName);
    }


    public int FindStatValueByName( List<Stat> statList, string name )
    {
        int statValue = 0;
        foreach (Stat stat in statList)
        {
            Stat statToFind = statList.Find(stat => stat.statName == name);
            statValue = statToFind.value;
        }
        //Debug.Log("Showing stat value for " + name + ": " + statValue);
        return statValue;
    }
}

/*
 
[Alchemy] AGI/INT
[Athletics] AGI/STR
[Defence] STR/AGI
[Engineering] INT/AGI
[Investigation] INT/PER
[Knowledge] INT/INT
[Magic] INT/AGI
[Martial] AGI/STR
[Crafting] STR/INT
[Survival] PER/INT
 */

