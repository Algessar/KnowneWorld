using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomStats
{

    [SerializeField] private List<Stat> _rngList = new List<Stat>();

    public List<Stat> AssignAllRandom()
    {
        var _statCreator = new StatCreator();

        _rngList = new List<Stat>();  // Initialize the stats list
        _rngList = _statCreator.PopulateStatList();

        List<Stat> A = new List<Stat>();
        List<Stat> B = new List<Stat>();
        List<Stat> C = new List<Stat>();

        // Pass 3 random stats from the stats list to list A
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, _rngList.Count);
            A.Add(_rngList[randomIndex]);
            _rngList.RemoveAt(randomIndex);
        }

        // Pass 2 random stats from the remaining stats to list B
        for (int i = 0; i < 2; i++)
        {
            int randomIndex = Random.Range(0, _rngList.Count);
            B.Add(_rngList[randomIndex]);
            _rngList.RemoveAt(randomIndex);
        }


        AssignintGroupA(A);
        AssignintGroupB(B);
        AssignToGroupCAndSetZero(C);



        return _rngList;
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
    void AssignToGroupCAndSetZero( List<Stat> stat )
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
        _rngList.AddRange(stat);
    }
    
}
