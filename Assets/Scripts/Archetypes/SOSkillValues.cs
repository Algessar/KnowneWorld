using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Archetype", menuName = "Data/SkillValues")]
public class SOSkillValues : ScriptableObject
{
    public string archetypeName = "";
    public int value = 0;
    public List<string> coreNames = new List<string>();
}
