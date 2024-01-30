using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Items;

public enum EquipmentType
{
    Armour,
    Weapon,
    Ring,
    Necklace,
}
[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemSO
{
    public EquipmentType _equipmentType;
    [Space(7)]
    public int _armourValue;
    public int _atkValue;
    public int _modifier1;
    public int _modifier2;
    public int _modifier3;

    private void Awake()
    {
        _itemType = ItemType.Equipment;
    }


}
