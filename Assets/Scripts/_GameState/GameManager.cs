
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.SearchService;


//Rules of thumb: value types that I want to be able to touch as a GM should be here. Like Experience point pool.
[RequireComponent(typeof(CharacterCreator))]
[RequireComponent(typeof(EquipmentManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    StatCreator _statCreator;
    CharacterCreator _characterCreator;
    public Character _character;

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
    public List<PlayerData> playerDatas = new List<PlayerData>();

    private int _gainPoint;


    private List<string> _characterNames = new List<string>();


    //testing
    ArchTest archTest;

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

        //GameManagerSetup();

        _characterCreator = GetComponent<CharacterCreator>(); 
        _canvas = FindAnyObjectByType<Canvas>();
        _camera = FindAnyObjectByType<Camera>();
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();

        if (scene.ToString() == _sceneCharacterCreation)
        {
            _raceSelectionDropdown = GameObject.Find("RaceSelection - Dropdown").GetComponent<TMP_Dropdown>();
            _sizeSelectionDropdown = GameObject.Find("RaceSelection - Dropdown").GetComponent<TMP_Dropdown>();
        }
        _canvas.renderMode = RenderMode.ScreenSpaceCamera;
        _canvas.worldCamera = _camera;

        //_sizeSelectionDropdown.gameObject.SetActive(false);

        _statCreator = new StatCreator();
    }
    private void GameManagerSetup()
    {
        #region Find objects


        
        #endregion
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
    private Stat SetSize(string key, int value)
    {
        _size.statName = key;
        _size.value = value;
        return _size;
    }
    public int IncrementSkillValues( int value ){ return value += 1; }
    public int DecrementSkillValue( int value ) {  return value -= 1; }

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

    #region save and load

    public void SaveCharacter()
    {
        SaveSystem.SaveCharacter(_character);
        Debug.Log("attempting to save " + _nameInputField.text);


    }



    public void LoadCharacter()
    {
       //Character _character = new Character();
       //var character = new PlayerData(_character);
       //character = SaveSystem.LoadCharacter(_nameInputField.text);
       //
       //playerDatas.Add( character );

        PlayerData loadedData = SaveSystem.LoadCharacter(_nameInputField.text);

        if ( loadedData != null ) 
        {
            Character loadedCharacter = new Character();
            loadedCharacter.LoadFromPlayerData( loadedData );

            _listExistingCharacters.Add(loadedCharacter);
        }

        // I need some kind of object that can call LoadCharacter with the character name.
        // Which means what? _nameInputField.text is ofc a placeholder. How do I pass in the name I want?
        // Maybe just use a list somehow? Save all the names in a list, pass that into a function which calls LoadCharacter with that name passed in.

        var name = _listExistingCharacters[0]._name;

        foreach ( var character in _listExistingCharacters )
        {
            _characterNames.Add(character._name);
        }

    }

    public void DeleteCharacter()
    {

        _listExistingCharacters.Clear();
        _character = null;
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
