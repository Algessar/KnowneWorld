using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSystem : MonoBehaviour
{
    
    SpellCraftingUI spellCraftingUI;
    public Dictionary<string, SOEffectWord> effectWordDictionary = new Dictionary<string, SOEffectWord>();

    [SerializeField] private SOEffectWord[] effectWords;  // Drag-and-drop your SO instances in the Inspector

    public int _totalDamage;

    private void Awake()
    {
        spellCraftingUI = GetComponent<SpellCraftingUI>();
        PopulateDictionary();
    }

    private void PopulateDictionary()
    {
        foreach (SOEffectWord effectWord in effectWords)
        {
            if (!effectWordDictionary.ContainsKey(effectWord._effectWord))
            {
                effectWordDictionary.Add(effectWord._effectWord, effectWord);
            }
            else
            {
                Debug.LogWarning($"Effect Word '{effectWord._effectWord}' already exists in the dictionary.");
            }
        }
    }
    public Dictionary<string, SOEffectWord> GetEffectWordDictionary()
    {
        return effectWordDictionary;
    }

    /*What will I be doing here? I need to roll damage*/

    public void CalculateSpellDamage()
    {
        int totalDamage = 0;
        foreach (SOEffectWord effectWord in spellCraftingUI._selectedEffectWords)
        {
            //Get variables
            for(int i = 0; i < effectWord._diceAmount; i++)
            {
                totalDamage += DiceRoller.Roll(1, effectWord._arcPower);
            }

        }
        _totalDamage = totalDamage;
        DisplayDamage(totalDamage);
    }

    public void DisplayDamage(int totalDamage)
    {
        string displaySpellDamage = totalDamage.ToString();
        Debug.Log("Damage dealt: " + totalDamage);
    }

}
