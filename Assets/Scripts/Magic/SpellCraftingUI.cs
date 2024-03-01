using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCraftingUI : MonoBehaviour
{
    //TODO: Link this whole system together with Archetype Magic.

    SpellSystem _spellSystem;

    public TMP_Dropdown _effectWordDropdown;
    //public Button _addEffectButton;

    public Dictionary<string, SOEffectWord> _effectWordDictionary;
    public List<SOEffectWord> _selectedEffectWords = new List<SOEffectWord>();

    public TextMeshProUGUI _spellDamageText;
    public TextMeshProUGUI _displayDiceToRoll;

    //public GameObject[] _displaySpellIcons;
    public List<GameObject> _spellIcons;
    public GameObject[] _spellIconRowParent;

    int _spellIndex;
    int _rowCount;

    private void Awake()
    {
        _spellSystem = GetComponent<SpellSystem>();
        GetEffectWordSpellIconsChildren();
        _rowCount = _spellIcons.Count;
        _spellIndex = 0;
    }

    private void Update()
    {
        UpdateSpellCraftUI();
    }

    public void SetEffectWordDictionary( Dictionary<string, SOEffectWord> dictionary )
    {
        if(dictionary == null)
        {
            Debug.LogError("Effect Word Dictionary is null.");
            return;
        }

        _effectWordDictionary = dictionary;

        // Populate the dropdown list with Effect Words
        _effectWordDropdown.ClearOptions();
        _effectWordDropdown.AddOptions(new List<string>(_effectWordDictionary.Keys));
    }

    public void AddSelectedEffectWord()
    {
        if (_spellIndex > _spellIcons.Count - 1)
        {
            return;
        }

        string selectedEffectWordKey = _effectWordDropdown.options[_effectWordDropdown.value].text;

        if (_effectWordDictionary.TryGetValue(selectedEffectWordKey, out SOEffectWord selectedEffectWord))
        {            
                _selectedEffectWords.Add(selectedEffectWord);
                Debug.Log($"Selected Effect Word: {selectedEffectWord._effectWord}");
                DisplaySpellIcon(selectedEffectWord, _spellIndex);            
        }
        else
        {
            Debug.LogError($"Effect Word with key '{selectedEffectWordKey}' not found in the dictionary.");
        }        
    }

    void UpdateSpellCraftUI()
    {
        _spellDamageText.text = _spellSystem._totalDamage.ToString();
        CollectAndDisplaySpellDice(); // TODO: Not implemented CollectAndDisplaySpellDice()
        // I want to split up arcPower and dice amount. There would be another line of code for calculation, but let me easier display it.
    }
    void CollectAndDisplaySpellDice()
    {

        //throw new System.NotImplementedException("CollectAndDisplaySpellDice() not yet implemented");
        //Get SO list, calc total amount of die
        //Display number of dice + "D" + dieSides
        //If dieSides are not equal for all dice in the list, then separate and display with "+"

        //_displayDiceToRoll.text = new string( _spellDamageText.text ); // temp lololol
    }

    private void GetEffectWordSpellIconsChildren()
    {
        foreach (GameObject parent in _spellIconRowParent)
        {
            // Check if the parent GameObject is not null
            if (parent != null)
            {
                // Get the number of children in the parent GameObject
                int childCount = parent.transform.childCount;

                // Loop through each child of the parent GameObject
                for (int i = 0; i < childCount; i++)
                {
                    // Get the child GameObject at index i
                    GameObject child = parent.transform.GetChild(i).gameObject;

                    // Add the child GameObject to the list
                    _spellIcons.Add(child);
                }
            }
            else
            {
                Debug.LogWarning("Parent GameObject is null.");
            }

        }
    }

    private void DisplaySpellIcon( SOEffectWord selectedSpell, int index )
    {        
        _spellIcons[_spellIndex].SetActive(true);
        Image imageComponent = _spellIcons[_spellIndex].GetComponent<Image>();

        if (imageComponent != null)
        {
            imageComponent.sprite = selectedSpell._spellIcon;
        }
        else
        {
            Debug.LogWarning("Image component not found on the GameObject.");
        }
        _spellIndex++;
        Debug.Log("Index is: " + index);        
    }

    public void ResetSpellList()
    {
        foreach(GameObject iconGameObject in  _spellIcons)
        {
            iconGameObject.SetActive(false);
        }        
        _spellIndex = 0;
        _selectedEffectWords.Clear();        
    }
    public void SaveSpellToSpellBook()
    {

    }
}
