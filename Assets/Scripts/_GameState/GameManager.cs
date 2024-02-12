
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

//Rules of thumb: value types that I want to be able to touch as a GM should be here. Like Experience point pool.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    
    CharacterCreator _characterCreator;
    private Character _character;


    [Header("Login")]
    public string loginName;
    public TMP_InputField _accountNameInput;
    public TMP_InputField _accountPasswordInput;


    [Header("Scene managment")]


    [Header("UI")]

    public string _name;
    public TMP_InputField _nameInputField;
   // public TextMeshProUGUI _displayName;
   // public TextMeshProUGUI[] _characterNames;

    [HideInInspector] public TMP_InputField _inputField;
    [HideInInspector] public TextMeshProUGUI _displayHealthText;
    [HideInInspector] public TextMeshProUGUI _AGIText;
    [HideInInspector] public TextMeshProUGUI _STRText;
    [HideInInspector] public TextMeshProUGUI _STAText;
    [HideInInspector] public TextMeshProUGUI _INTText;
    [HideInInspector] public TextMeshProUGUI _WILLText;
    [HideInInspector] public TextMeshProUGUI _PERText;

    [Space(9)]   

    [Header("Character List")]
    public GameObject _characterSelectDisplay;
    public Transform _textParent;
    public List<Character> _listExistingCharacters = new List<Character>();


    private int _gainPoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        _characterCreator = GetComponent<CharacterCreator>();        
    }   

    public void DisplayCharacterList()
    {
        foreach (Transform child in _textParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Character character in _listExistingCharacters)
        {
            GameObject newTextObject = Instantiate(_characterSelectDisplay, _textParent);

            TextMeshProUGUI textComponent = newTextObject.GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = character._name;
            }
            else
            {
                Debug.LogWarning("TextMeshProUGUI component not found in prefab.");
            }
        }
    }

    public void CreateNewCharacter()
    {
        _characterCreator.CreateCharacter();
    }    

    void CalculateTotalDamage(int baseDmg, int bonusDmg)
    {
       // _totalDamage += baseDmg + bonusDmg;
    }

    void CalculateBonusDamage()
    {

        // Requires Core skills being calculated

        // _bonusDamageMod = 
        // Stat mods
        // Weapon mods
        // Equipment mods
        // Augment mods
    }
    public int IncrementCoreSkillValues( int coreSkill ){ return coreSkill += 1; }
    public int DecrementCoreSkillValue( int coreSkill ) {  return coreSkill -= 1; }

    public int DiceRoll( int maxValue )
    {
        int result = UnityEngine.Random.Range(1, maxValue + 1);
        return result;
    }
    public int IncrementStat( string name, int incrementValue ) //This function does not work as expected
    {
        Stat statToIncrement = _character._statList.Find(stat => stat.statName == name);

        if (statToIncrement != null)
        {            
            statToIncrement.value += incrementValue;
            Debug.Log($"{name} incremented by {incrementValue}. New value: {statToIncrement.value}");
            return statToIncrement.value;
        }
        else
        {
            Debug.LogError($"Stat {name} not found.");
        }
        return 0;
    }

    #region player handling

    public void SelectTarget(IUnit unit)
    {
        ITargetable targetable = unit as ITargetable;
    }
    #endregion

    #region Scene/Login Management

    public void ToLoginScene()
    {
        SceneManager.LoadScene("Login");
    }
    public void ToCharacterSelectionScene()
    {
        if (_accountNameInput.text == "TestPlayer")
        {            
            if (_accountPasswordInput.text == "Master")
            {
                SceneManager.LoadScene("CharacterSelection");
            }
        }
    }
    public void ToGMScene()
    {
        if (_accountNameInput.text == "Master")
        {
            if (_accountPasswordInput.text == "Master")
            {
                SceneManager.LoadScene("GameMasterScene");
            }
        }
    }
    public void ToPlayerScene()
    {
        SceneManager.LoadScene("PlayerScene");
    }

    #endregion

    #region Utilities

    public bool CharacterNameExists( string name )
    {
        foreach (Character character in _listExistingCharacters)
        {
            if (character._name == name)
            {
                return true; // Character with the same name already exists
            }
        }
        return false; // Character with the same name does not exist
    }
    private void LogList( List<int> list )
    {
        string logString = "List contents: ";

        foreach (int item in list)
        {
            logString += item.ToString() + ", ";
        }

        // Remove the trailing comma and space
        logString = logString.TrimEnd(' ', ',');

        Debug.Log(logString);
    }
    #endregion
}
