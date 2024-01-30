using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SO_Augmentations : ScriptableObject
{
    
    public string _name = string.Empty;
    
    public string _mainDescription = string.Empty;

    ScriptableObject _actionToModify;

    public int _rank = 0;
    public string _descriptionRank1 = string.Empty;
    public string _descriptionRank2 = string.Empty;
    public string _descriptionRank3 = string.Empty;
    public string _descriptionRank4 = string.Empty;

    public int _arcPower = 0; //should I use the same word here, or just use _power to avoid confusion I should probs have both?
    public int _power = 0;

    /*What do I need for these? Any variable they can modify? I can't wrap my head around how to use it properly as an SO. 
     * Would if(SO_selectedFromList){DoThing;} work? Should I get references to Stats in the SO itself? */
}
