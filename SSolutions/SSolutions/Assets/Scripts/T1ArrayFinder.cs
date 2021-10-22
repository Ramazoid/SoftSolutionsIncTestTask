using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1ArrayFinder : MonoBehaviour
{
    private Dictionary<object, object> testarray = new Dictionary<object, object>()
    {
        ["0"] = 0,
        ["1"] = 1,
        ["2"]=new Dictionary<object,object>()
        {
            ["3"]=3,
            ["4"]=4,
            ["5"]=5,
            ["6"]=6,
            ["7"]=7,
            ["8"]=8,
            ["9"]=new  Dictionary<object,object>()
                {
                    ["10"]="You found me!!!!!!!"                    
                }                                       
            
        }
    };

private void Start()
    {
      
      print(Finding(testarray, "10"));
    }

private object Finding(object dict, string key)
{
    if (dict is Dictionary<object, object>)
    {
        foreach (KeyValuePair<object, object> kvp in dict as Dictionary<object, object>)
        {
            if (kvp.Value is IDictionary)
                return Finding(kvp.Value, key);
            else
            {

                if (kvp.Key.ToString() == key)
                    return kvp.Value;
            }
        }
    }

    return "not found";
}

    

}