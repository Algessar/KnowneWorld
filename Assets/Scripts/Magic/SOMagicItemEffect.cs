using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Magic Item Effect", menuName = "Magic/New Magic Item")]
public class SOMagicItemEffect : ScriptableObject
{

    [SerializeField] private int _arcPowerModifier;
    [SerializeField] private float _rangeModifier;

    //magical effect ("Flaming Sword", "Unbreakable" etc

    // This might be unnecessary. I can just directly take EffectWords and put them on an item.


}
