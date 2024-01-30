using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue>
{
    public List<TKey> keys = new List<TKey>();
    public List<TValue> values = new List<TValue>();
}

