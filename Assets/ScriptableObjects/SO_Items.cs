using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_Items : ScriptableObject
{
    public enum ItemType
    {
        Food,
        Equipment,
        Misc
    }
    public class ItemSO : ScriptableObject
    {
        public string _name = "";
        public GameObject _prefab;
        public ItemType _itemType;
        [TextArea(7, 20)]
        public string _description;

        public string _magicalEffect;
        ScriptableObject _SOMagicEffect;


        void MagicalItem()
        {
            if (_SOMagicEffect != null)
            {

            }
        }
    }    
}
