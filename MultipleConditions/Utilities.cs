using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities 
{
    public static bool CheckForTrue(Dictionary<NameVariable,bool> values)
    {
        if(values.ContainsValue(true))
            return true;
        return false;
    }

    /*public static List<NameVariable> CheckValues(Dictionary<NameVariable,bool> values)
    {
        List<NameVariable> trueList = new List<NameVariable>();
        foreach(KeyValuePair<NameVariable,bool> entry in values)
            if (entry.Value == true) trueList.Add(entry.Key);           
        return trueList;
    }*/

}
