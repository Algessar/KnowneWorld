using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RandomStats : MonoBehaviour
{

    // TODO: Collect all generated numbers in a list, for manual assignment
    // 
    [SerializeField]
    public List<Stat> statList = new List<Stat>();

    [SerializeField] StatCreator _statCreator;

    bool _canRoll = true;

    private void Awake()
    {        
        _statCreator = GetComponent<StatCreator>();
        AssignAllRandom();
    }
    public void AssignAllRandom() // public List<> AssignAllRandom(){ return }
    {
        if(!_canRoll)
        {
            return;
        }
        if(_canRoll)
        {
            for(int i = 0; i < 2; i++) 
            {
                if(i >= 5)
                {
                    _canRoll = false;
                }
            }        
            if (_statCreator == null)
            {
                Debug.LogError("StatCreator is not assigned to RandomStats.");
                return;
            }

            statList = new List<Stat>();  // Initialize the stats list
            statList = _statCreator.PopulateStatList();

            List<Stat> A = new List<Stat>();
            List<Stat> B = new List<Stat>();
            List<Stat> C = new List<Stat>();

            // Pass 3 random stats from the stats list to list A
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = Random.Range(0, statList.Count);
                A.Add(statList[randomIndex]);
                statList.RemoveAt(randomIndex);
            }

            // Pass 2 random stats from the remaining stats to list B
            for (int i = 0; i < 2; i++)
            {
                int randomIndex = Random.Range(0, statList.Count);
                B.Add(statList[randomIndex]);
                statList.RemoveAt(randomIndex);
            }

            // Pass the remaining stat to list C
            C.AddRange(statList);
            AssignintGroupA(A);
            AssignintGroupB(B);
            AssignToGroupCAndSetZero(C);

            //AssignintGroupC(C);        

            //LogList(A);
            //LogList(B);
            //LogList(C);
        }
        else
        {
            return;
        }
        //_gameManager.CalculateRaceModifiers();

    }
    void AssignintGroupA( List<Stat> stat )
    {
        foreach (Stat s in stat)
        {
            s.value = (int)Random.Range(1, 5);
        }
        statList.AddRange(stat);
    }
    void AssignintGroupB( List<Stat> stat)
    {
        foreach (Stat s in stat)
        {
            s.value = (int)Random.Range(-4, -1);

        }        
        statList.AddRange(stat);
    }
    void AssignToGroupCAndSetZero(List<Stat> stat )
    {
        if (stat.Count == 0)
        {
            // Handle the case where the list is empty
            return; // or some default value
        }        

        int min = (int)stat[0].value;

        for (int i = 1; i < stat.Count; i++)
        {
            int currentValue = (int)stat[i].value;

            if (currentValue < min)
            {
                min = currentValue;
            }
            min = 0;
        }
        statList.AddRange(stat);
    }
    
    // THESE ARE HERE BECAUSE statList IS IN THIS CLASS
    public void IncrementStat( string name, int incrementValue ) //This function does not work as expected
    {
        Stat statToIncrement = statList.Find(stat => stat.statName == name);

        if (statToIncrement != null)
        {          
          statToIncrement.value += incrementValue;
          Debug.Log($"{name} incremented by {incrementValue}. New value: {statToIncrement.value}");            
        }
        else
        {
            Debug.LogError($"Stat {name} not found.");
        }        
    }
    public void DecrementStat( string name, int incrementValue )
    {
        Stat statToIncrement = statList.Find(stat => stat.statName == name);

        if (statToIncrement != null)
        {
            statToIncrement.value -= incrementValue;
            Debug.Log($"{name} incremented by {incrementValue}. New value: {statToIncrement.value}");
        }
        else
        {
            Debug.LogError($"Stat {name} not found.");
        }
    }
    //public int FindStatValueByName( string statName )
    //{
    //    int fetchedValue = 0;
    //    foreach (Stat stat in statList)
    //    {
    //        if (stat.statName == statName)
    //        {
    //            fetchedValue = (int)stat.value;
    //            return fetchedValue;
    //        }
    //    }
    //    //Debug.Log(statName);
    //    return 0; // If the stat with the specified name is not found
    //}
    public int FindStatValueByName(string name)
    {
        int statValue = 0;
        foreach (Stat stat in statList)
        {
            Stat statToFind = statList.Find(stat => stat.statName == name);
            statValue = statToFind.value;
        }
        return statValue;
    }
}


//void AssignintGroupC( List<Stat> stat )
//{
//    foreach (Stat s in stat)
//    {
//        s.value = 0;
//        stats.Add(new Stat(s.value, s.statName));
//    }
//    stats.AddRange(stat);
//}