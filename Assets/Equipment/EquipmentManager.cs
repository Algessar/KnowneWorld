using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    // Singleton instance
    public static EquipmentManager Instance;

    // List of equipped items
    private List<SOEquipmentObject> _equippedItems = new List<SOEquipmentObject>();

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Equip an item
    public void EquipItem( SOEquipmentObject item )
    {
        // Check if the item is already equipped
        if (!_equippedItems.Contains(item))
        {
            _equippedItems.Add(item);
            Debug.Log("Equipped: " + item._name);
        }
        else
        {
            Debug.Log(item._name + " is already equipped.");
        }
    }

    // Unequip an item
    public void UnequipItem( SOEquipmentObject item )
    {
        if (_equippedItems.Contains(item))
        {
            _equippedItems.Remove(item);
            Debug.Log("Unequipped: " + item._name);
        }
        else
        {
            Debug.Log(item._name + " is not equipped.");
        }
    }

    // Get a specific equipped item by type
    public SOEquipmentObject GetEquippedItemByType( EquipmentType type )
    {
        foreach (var item in _equippedItems)
        {
            if (item._equipmentType == type)
                return item;
        }
        return null; // No item of the specified type is equipped
    }
}
