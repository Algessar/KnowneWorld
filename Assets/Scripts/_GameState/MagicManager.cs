using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpellSystem))]
[RequireComponent (typeof(SpellCraftingUI))]
public class MagicManager : MonoBehaviour
{
  
    private SpellSystem spellSystem;
    private SpellCraftingUI spellCraftingUI;

    private void Start()
    {        
        spellSystem = GetComponent<SpellSystem>();
        spellCraftingUI = GetComponent<SpellCraftingUI>();

        if (spellSystem != null && spellCraftingUI != null)
        {
            // Set up the connection between SpellSystem and SpellCraftingUI
            spellCraftingUI.SetEffectWordDictionary(spellSystem.GetEffectWordDictionary());
        }
        else
        {
            Debug.LogError("SpellSystem or SpellCraftingUI component not found.");
        }
    }
}
