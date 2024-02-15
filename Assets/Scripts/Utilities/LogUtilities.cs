using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class LogUtilities
{
    List<Stat> statList = new List<Stat>();

    public int FindStat( string name )
    {
        // Default value if the stat is not found
        int statValue = 0;

        // Find the Stat with the specified name
        Stat statToFind = statList.Find(stat => stat.statName == name);

        // Check if the Stat was found
        if (statToFind != null)
        {
            statValue = statToFind.value;
        }

        return statValue;
    }

    public void LogNameAndValue(List<Stat> list)
    {
       foreach(Stat stat in list) 
        {

            Debug.Log($"List name and value: {stat.statName} : {stat.value}");
        }
    }

    public void LogList<T>( List<T> list )
    {
        string logString = $"List contents: {string.Join(", ", list)}";
        Debug.Log(logString);
    }

    public void LogDict<T>( Dictionary<string, T> dict )
    {
        string logString = "Dictionary contents: ";

        foreach (var kvp in dict)
        {
            logString += $"{kvp.Key}: {kvp.Value}, ";
        }

        // Remove the trailing comma and space
        logString = logString.TrimEnd(' ', ',');

        Debug.Log(logString);
    }

}
