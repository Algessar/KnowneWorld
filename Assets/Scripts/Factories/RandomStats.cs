using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

//TODO: Write logic for making sure that it is the lowest rolled number that get's set to zero.

public class RandomStats
{

    [SerializeField] private List<Stat> _rngList = new List<Stat>();
    LogUtilities logUtilities;

    public List<Stat> AssignAllRandom()
    {
        logUtilities = new LogUtilities();
        var _statCreator = new StatCreator();
        _rngList.Clear();
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
        AssignIntGroupA(A);
        // 3 positive entries are put back in. total 3 in _rngList
        AssignIntGroupB(B);
        // 3 negative entries put in back in, total 6 in _rngList
        SetLowestToZero(_rngList);
        // _rngList is searched for the lowest value, which is then set to 0.

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
    void AssignIntGroupA( List<Stat> stat )
    {
        foreach (Stat s in stat)
        {
            s.value = (int)Random.Range(1, 5);
        }
        _rngList.AddRange(stat);
    }
    void AssignIntGroupB( List<Stat> stat )
    {
        foreach (Stat s in stat)
        {
            s.value = (int)Random.Range(-4, -0);

        }
        _rngList.AddRange(stat);
    }

    void SetLowestToZero( List<Stat> statList )
    {
        // Check if the list is empty
        if (statList.Count == 0)
        {
            Debug.LogWarning("List is empty. Cannot set lowest value to zero.");
            return;
        }

        List<int> intList = new List<int>();
        int val = 0;
        
        foreach (Stat s in statList)
        {
            //Add value per stat in the statList. So 6 numbers are getting added.
            val = s.value;
            intList.Add(val);
        }

        // Find the minimum value in the list
        int minValue = intList.Min();

        // Iterate through the statList to find the Stat object with the minimum value
        foreach (Stat s in statList)
        {
            if (s.value == minValue)
            {
                // Update the value of the Stat object with the minimum value to 0
                s.value = 0;
                break; // Once we've found and updated the minimum value, we can exit the loop
            }
        }
    }
}