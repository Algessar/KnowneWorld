
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;


//Rules of thumb: value types that I want to be able to touch as a GM should be here. Like Experience point pool.
[RequireComponent(typeof(CharacterCreator))]
[RequireComponent(typeof(EquipmentManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    StatCreator _statCreator;
    CharacterCreator _characterCreator;
    private Character _character;

    [Header("Scene managment")]

    public string _sceneWelcomeScreen = "WelcomeScreen";
    public string _sceneCharacterSelection = "CharacterSelection";
    public string _sceneLoginScreen = "Login";
    public string _sceneCharacterCreation = "CharacterCreation";
    public string _sceneGameMaster = "GameMasterScene";
    public string _scenePlayer = "PlayerScene";

    [Header("UI")]
    Canvas _canvas;
    [SerializeField] Camera _camera;

    [Header("UI/Login")]
    public string loginName;
    public TMP_InputField _accountNameInput;
    public TMP_InputField _accountPasswordInput;

    [Header("UI/Character creation")]
    public string _name;
    public TMP_InputField _nameInputField;

    public TMP_Dropdown _raceSelectionDropdown;
    public CharacterRace _currentlySelectedRace;
    public TMP_Dropdown _sizeSelectionDropdown;
    public Stat _size;
    public List<Stat> _sizeList = new List<Stat>();
    private int _indexSize;
    public Dictionary<string, int> _sizeDictionary;




    [HideInInspector] public TMP_InputField _inputField;
    [HideInInspector] public TextMeshProUGUI _displayHealthText;
    [HideInInspector] public TextMeshProUGUI _AGIText;
    [HideInInspector] public TextMeshProUGUI _STRText;
    [HideInInspector] public TextMeshProUGUI _STAText;
    [HideInInspector] public TextMeshProUGUI _INTText;
    [HideInInspector] public TextMeshProUGUI _WILLText;
    [HideInInspector] public TextMeshProUGUI _PERText;
    [Space(5)]

    [Header("UI/Action inputs")]
    public TMP_InputField _dealDamageInput;
    public TMP_InputField _takeDamageInput;

    public TextMeshProUGUI _showDamageOutput;

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
            DontDestroyOnLoad(this.gameObject);
        }

        _characterCreator = GetComponent<CharacterCreator>(); 
        _canvas = FindAnyObjectByType<Canvas>();
        _camera = FindAnyObjectByType<Camera>();

        _canvas.renderMode = RenderMode.ScreenSpaceCamera;
        _canvas.worldCamera = _camera;

        _sizeSelectionDropdown.gameObject.SetActive(false);

        _statCreator = new StatCreator();
    }

    private void GameManagerSetup()
    {
        _characterSelectDisplay = GameObject.Find("");
        _dealDamageInput.HasDescriptor();
        //_dealDamageInput = GameObject.Find("");
        

    }

    private void Start()
    {
        if (_sizeSelectionDropdown != null)
        {
            SetSizeDictionary(DataManager.Instance._SOSize.GetSizeDictionary());

            //_sizeSelectionDropdown.onValueChanged.AddListener(OnSizeDropdownValueChanged);
        }
        else if (_sizeSelectionDropdown == null)
        {
            Debug.LogWarning("Size Selection Dropdown Is Not Assigned");
        }
        //_sizeSelection = _statCreator.PopulateSizeList();

        var log = new LogUtilities();

        //log.LogNameAndValue(_sizeSelection);       

        if(_raceSelectionDropdown != null)
        {

        SelectRace();
        }
        else if (_sizeSelectionDropdown == null)
        {
            Debug.LogWarning("Race Selection Dropdown Is Not Assigned");
        }

    }
    private void Update()
    {
        //OnSizeDropdownValueChanged();
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

    public void SelectRace()
    {
        if(_raceSelectionDropdown != null)
        {
        _raceSelectionDropdown.ClearOptions();
        }
        int enumValues = System.Enum.GetValues(typeof(CharacterRace)).Length;

        List<TMP_Dropdown.OptionData> data = new List<TMP_Dropdown.OptionData>();

        for(int i = 0; i < enumValues; i++)
        {
            TMP_Dropdown.OptionData newData = new TMP_Dropdown.OptionData();
            newData.text = ((CharacterRace)i).ToString();
            data.Add(newData);
        }
        _raceSelectionDropdown.AddOptions(data);
        
        //OnRaceDropdownValueChanged(0);
        

    }

    public void OnRaceDropdownValueChanged()
    {
        string selectedText = _raceSelectionDropdown.options[_raceSelectionDropdown.value].text;

        CharacterRace selectedRace;
        if (System.Enum.TryParse(selectedText, out selectedRace))
        {
            _currentlySelectedRace = selectedRace;
            Debug.Log("Currently selected race: " + _currentlySelectedRace);
        }
        else
        {
            Debug.LogWarning("Failed to parse selected race: " + selectedText);
        }

        
    }

    public void SetSizeDictionary(Dictionary<string, int> dictionary )
    {
        _sizeDictionary = dictionary;

        
        _sizeSelectionDropdown.ClearOptions();
        _sizeSelectionDropdown.AddOptions(new List<string>(_sizeDictionary.Keys));       
        

    }

   // public void OnSizeDropdownValueChanged(int index)
   // {
   //     index = _sizeSelectionDropdown.value;
   //     string selectedSizeKey = _sizeSelectionDropdown.options[index].text;
   //     
   //     if (_sizeDictionary.TryGetValue(selectedSizeKey, out int selectedSizeValue))
   //     {
   //         // Handle the selected size value (e.g., update UI, perform actions)
   //         //Debug.Log($"Selected Size: {selectedSizeKey} - Value: {selectedSizeValue}");
   //
   //         
   //         _character._size = SetSize(selectedSizeKey, selectedSizeValue);
   //         _sizeList = _statCreator.PopulateSizeList(_character._sizeList);
   //         var log = new LogUtilities();
   //         log.LogNameAndValue(_sizeList);
   //         //SetSize(selectedSizeKey, selectedSizeValue);
   //     }
   //     else
   //     {
   //         Debug.LogWarning($"Selected size key '{selectedSizeKey}' not found in the dictionary.");
   //     }
   // }


    private Stat SetSize(string key, int value)
    {
        _size.statName = key;
        _size.value = value;
        return _size;
    }


    public int IncrementCoreSkillValues( int coreSkill ){ return coreSkill += 1; }
    public int DecrementCoreSkillValue( int coreSkill ) {  return coreSkill -= 1; }

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
        SceneManager.LoadScene(_sceneLoginScreen);
    }
    public void ToCharacterSelectionScene()
    {        
        SceneManager.LoadScene(_sceneCharacterSelection);       
    }
    public void ToCharacterCreationScene()
    {        
        SceneManager.LoadScene(_sceneCharacterCreation);        
    }
    public void ToGMScene()
    {
        if (_accountNameInput.text == "Master" && _accountPasswordInput.text == "Master")
        {           
            SceneManager.LoadScene(_sceneGameMaster);            
        }
    }
    public void ToPlayerScene()
    {
        Debug.Log("LOGIN was pressed");
        if (_accountNameInput.text == "Test" && _accountPasswordInput.text == "Test")
        {
            
            
            Debug.Log("Login was pressed and should change scene");
            SceneManager.LoadScene(_scenePlayer);
            
        }
    }

    public void ToWelcomeScene()
    {
        SceneManager.LoadScene(_sceneWelcomeScreen);
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
