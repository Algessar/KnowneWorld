using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCraftingUI : MonoBehaviour
{
    //TODO: Link this whole system together with Archetype Magic.

    SpellSystem _spellSystem;

    public TMP_Dropdown _effectWordDropdown;
    public Button _addEffectButton;

    public Dictionary<string, SOEffectWord> _effectWordDictionary;
    public List<SOEffectWord> _selectedEffectWords = new List<SOEffectWord>();

    public TextMeshProUGUI _spellDamageText;
    public TextMeshProUGUI _displayDiceToRoll;

    public GameObject[] _displaySpellIcons;
    
    int _spellIndex;

    private void Awake()
    {
        _spellSystem = GetComponent<SpellSystem>();        
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
        string selectedEffectWordKey = _effectWordDropdown.options[_effectWordDropdown.value].text;

        if (_effectWordDictionary.TryGetValue(selectedEffectWordKey, out SOEffectWord selectedEffectWord))
        {
            // Check if the selected Effect Word is not already in the list
            if (!_selectedEffectWords.Contains(selectedEffectWord))
            {
                _selectedEffectWords.Add(selectedEffectWord);

                // Optionally, update UI or do something with the selected Effect Word
                Debug.Log($"Selected Effect Word: {selectedEffectWord._effectWord}");
                DisplaySpellIcon(selectedEffectWord, _spellIndex);
            }
            else
            {
                Debug.LogWarning($"Effect Word '{selectedEffectWord._effectWord}' is already selected.");
            }
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
    }

    void CollectAndDisplaySpellDice()
    {
        //Get SO list, calc total amount of die
        //Display number of dice + "D" + dieSides
        //If dieSides are not equal for all dice in the list, then separate and display with "+"

        //_displayDiceToRoll.text = new string( _spellDamageText.text ); // temp lololol
    }
    private void DisplaySpellIcon( SOEffectWord selectedSpell, int index )
    {        
        
        if(index < _displaySpellIcons.Length)
        {
            //considering creating a new array or List of the currently indexed spells?
            _displaySpellIcons[_spellIndex].SetActive(true);
            Image imageComponent = _displaySpellIcons[_spellIndex].GetComponent<Image>();

            if (imageComponent != null)
            {
                // Assign the sprite to the Image component
                imageComponent.sprite = selectedSpell._spellIcon;

                // Optionally, you can also set other properties of the Image component here
            }
            else
            {
                Debug.LogWarning("Image component not found on the GameObject.");
            }
            _spellIndex++;
            Debug.Log("Index is: " + index);
        }
    }

    public void ResetSpellList()
    {
        foreach(GameObject iconGameObject in  _displaySpellIcons)
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
