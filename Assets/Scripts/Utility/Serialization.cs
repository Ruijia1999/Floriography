using System;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoad
{
    
}

[Serializable]
public class FireworkParameterJson : ISerializationCallbackReceiver
{
    public Dictionary<string, FireworkParameter> infodic;
    public FireworkParameterJson(Dictionary<string, FireworkParameter> data)
    {
        this.infodic = data;
    }

    public List<string> KeyList = new List<string>();
    public List<FireworkParameter> ValueList = new List<FireworkParameter>();
    public void OnAfterDeserialize()
    {
        infodic = new Dictionary<string, FireworkParameter>();
        for (int i = 0; i < Math.Min(KeyList.Count, ValueList.Count); i++)
        {
            infodic.Add(KeyList[i], ValueList[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        KeyList.Clear();
        ValueList.Clear();
        foreach (var item in infodic)
        {
            KeyList.Add(item.Key);
            ValueList.Add(item.Value);
        }
    }
}
