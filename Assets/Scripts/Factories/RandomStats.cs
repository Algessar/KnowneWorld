using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//TODO: Write logic for making sure that it is the lowest rolled number that get's set to zero.

public class RandomStats
{

    [SerializeField] private List<Stat> _rngList = new List<Stat>();

    public List<Stat> AssignAllRandom()
    {
        var _statCreator = new StatCreator();

        _rngList = new List<Stat>();  // Initialize the stats list
        _rngList = _statCreator.PopulateStatList();  // Populates the list with the amount of Stats defined in the StatSO

        List<Stat> A = new List<Stat>();
        List<Stat> B = new List<Stat>();
        List<Stat> C = new List<Stat>();
        //PrintListValues(_rngList); // 6 entries in list
        // Pass 3 random stats from the stats list to list A
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, _rngList.Count);
            A.Add(_rngList[randomIndex]);
            _rngList.RemoveAt(randomIndex);
        }
         // 3 entries in list
        // Pass 3 random stats from the remaining stats to list B
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, _rngList.Count);
            B.Add(_rngList[randomIndex]);
            _rngList.RemoveAt(randomIndex);
        }
        //at this point, there are 0 entries in the _rngList. 
        

        AssignintGroupA(A);
        // 3 positive entries are put back in. total 3 in _rngList
        AssignintGroupB(B);
        // 3 negative entries put in back in, total 6 in _rngList
        PrintListValues(_rngList);
        
        
        SetLowestToZero(_rngList);
        // _rngList is searched for the lowest value, which is then set to 0.
        PrintListValues(_rngList);

        return _rngList;
    }

    void PrintListValues(List<Stat> list )
    {
        foreach (Stat stat in list)
        {
            Debug.Log(stat.statName + " " + stat.value);
        }
        //for (int i = 1; i < list.Count; i++)
        //{
           // Debug.Log("list count: " + list.Count);
        //}
    }

    void AssignintGroupA( List<Stat> stat )
    {
        foreach (Stat s in stat)
        {
            s.value = (int)Random.Range(1, 5);
        }
        _rngList.AddRange(stat);
    }
    void AssignintGroupB( List<Stat> stat )
    {
        foreach (Stat s in stat)
        {
            s.value = (int)Random.Range(-4, -1);

        }
        _rngList.AddRange(stat);
    }

    void SetLowestToZero( List<Stat> stat )
    {
        // Check if the list is empty
        if (stat.Count == 0)
        {
            Debug.LogWarning("List is empty. Cannot set lowest value to zero.");
            return;
        }

        // Find the minimum value in the list
        int minIndex = 0;
        int minValue = stat[0].value;
        //Debug.Log("Min value before search: " + minValue);
        for (int i = 1; i < stat.Count; i++)
        {
            if (stat[i].value < minValue)
            {
                minValue = stat[i].value;
                Debug.Log("Min value in search: " + minValue);
                minIndex = i;
                Debug.Log("At index: " + minIndex);
            }
        }
        //Debug.Log("Min value just before setting to 0: " + minValue);

        // Replace the lowest value with 0
        stat[minIndex].value = 0;

        Debug.Log("Lowest value set to zero." + stat[minIndex].value);
    }
}

  //  void AssignToGroupCAndSetZero( List<Stat> stat )
  //  {
  //      if (stat.Count == 0)
  //      {
  //          // Handle the case where the list is empty
  //          return; // or some default value
  //      }
  //
  //      int min = (int)stat[0].value;
  //
  //      for (int i = 1; i < stat.Count; i++)
  //      {
  //          int currentValue = (int)stat[i].value;
  //
  //          if (currentValue < min)
  //          {
  //              min = currentValue;
  //          }
  //          min = 0;
  //      }
  //      _rngList.AddRange(stat);
  //  }
    

