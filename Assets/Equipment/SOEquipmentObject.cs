using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Items;


[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class SOEquipmentObject : ItemSO
{
    public EquipmentType _equipmentType;
    [Space(7)]
    public int _diceAmount;
    public int _atkValue;
    public int _armourValue;
    public int _modifier1;
    public int _modifier2;
    public int _modifier3;



    private void Awake()
    {
        _itemType = ItemType.Equipment;
    }

    public int GetTotalDamage()
    {
        int rolled = 0;
        for(int i = 0; i < _diceAmount;)
        {
            rolled = DiceRoller.Roll(1, 6);
            _atkValue += rolled;
        }
        return _atkValue;
    }
}
