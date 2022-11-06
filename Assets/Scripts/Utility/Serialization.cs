using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class TXTFireworkParameter
{
    public int id;
    public string name;
    public string color;
    public string buff;
    public TXTFireworkParameter(int id, string name, string color, string buff)
    {
        this.id = id;
        this.name = name;
        this.color = color;
        this.buff = buff;
    }
}
[Serializable]
public class FireworkParameterJson : ISerializationCallbackReceiver
{
    public List<TXTFireworkParameter> infodic;
    public FireworkParameterJson(List<TXTFireworkParameter> data)
    {
        this.infodic = data;
    }

    public List<TXTFireworkParameter> Fireworks;

    public void OnAfterDeserialize()
    {
        infodic = new List<TXTFireworkParameter>();
        for (int i = 0; i < Fireworks.Count; i++)
        {
            //FireworkParameter pamrater = new(ValueList[i].color, ValueList[i].buff);
            infodic.Add(Fireworks[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        Fireworks.Clear();

        foreach (var item in infodic)
        {
            Fireworks.Add(item);
        }
    }
}

//[Serializable]
//public class FireworkParameterJson : ISerializationCallbackReceiver
//{
//    public Dictionary<string, TXTFireworkParameter> infodic;
//    public FireworkParameterJson(Dictionary<string, TXTFireworkParameter> data)
//    {
//        this.infodic = data;
//    }

//    public List<string> KeyList;
//    public List<TXTFireworkParameter> ValueList;

//    public void OnAfterDeserialize()
//    {
//        infodic = new Dictionary<string, TXTFireworkParameter>();
//        for (int i = 0; i < Math.Min(KeyList.Count, ValueList.Count); i++)
//        {
//            //FireworkParameter pamrater = new(ValueList[i].color, ValueList[i].buff);
//            infodic.Add(KeyList[i], ValueList[i]);
//        }
//    }

//    public void OnBeforeSerialize()
//    {
//        KeyList.Clear();
//        ValueList.Clear();
//        foreach (var item in infodic)
//        {
//            KeyList.Add(item.Key);
//            ValueList.Add(item.Value);
//       }
//    }
//}
