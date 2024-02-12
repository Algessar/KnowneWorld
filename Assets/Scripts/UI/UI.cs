using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

public class UI : MonoBehaviour
{
    //[SerializeField] private RandomStats RandomStats;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ArchetypeManager _archetypeManager;

    [Header("Switch Screens")]
    public GameObject _startScreenPanel;

    [Header("Main stats")]

    public List<TextMeshProUGUI> _displayMainStatsNumbers = new List<TextMeshProUGUI>();
    public TextMeshProUGUI AGI;
    public TextMeshProUGUI STR;
    public TextMeshProUGUI STA;
    public TextMeshProUGUI INT;
    public TextMeshProUGUI WIL;
    public TextMeshProUGUI PER;

    [Header("Secondary stats")]
    public TextMeshProUGUI HP;

    public TextMeshProUGUI Size;
    public TextMeshProUGUI APR;
    public TextMeshProUGUI DMG;


    //[SerializeField] private TextMeshProUGUI _textActionPoints;
    //[SerializeField] private TextMeshProUGUI _texthealth;
    //[SerializeField] private TextMeshProUGUI _textSize;
    //[SerializeField] private TextMeshProUGUI _textTrait;
    public List<TextMeshProUGUI> _secondaryStatsNumbers = new List<TextMeshProUGUI>();

    public GameObject[] panels;
    private int currentPanelIndex = 0;

 //
 //  void Start()
 //  {
 //     // RandomStats = FindAnyObjectByType<RandomStats>();
 //      _gameManager = FindAnyObjectByType<GameManager>();
 //      _archetypeManager = FindAnyObjectByType<ArchetypeManager>();
 //
 //      //InitializeData();
 //      //UpdateUI(_archetypeDropdown.options[_archetypeDropdown.value].text);
 //
 //      UpdateScoreText();
 //
 //      ShowCurrentPanel();
 //  }
 //
 //  private void Update()
 //  {
 //      UpdateScoreText();
 //  }

   // void UpdateScoreText()
   // {
   //     //_textAgility.text = "Agility: ";
   //     //_textStrength.text = "Strength: ";
   //     //_textStamina.text = "Stamina: ";
   //     //_textIntelligence.text = "Intelligence: ";
   //     //_textWill.text = "Will: ";
   //     //_textPerception.text = "Perception: ";
   //
   //     //Debug.Log("THIS IS A TEST FOR THE NAME TEXT BOX: Using _textPerception.text: " + _textPerception.text);
   //
   //     AGI.text = RandomStats.FindStatValueByName("Agility").ToString();
   //     STR.text = RandomStats.FindStatValueByName("Strength").ToString();
   //     STA.text = RandomStats.FindStatValueByName("Stamina").ToString();
   //     INT.text = RandomStats.FindStatValueByName("Intellect").ToString();
   //     //Debug.Log("UI: Intellect taken from FindStat(): " + RandomStats.FindStatValueByName("Intellect"));
   //     //Debug.Log("Int display in UI: " + RandomStats._intellect);
   //     WIL.text = RandomStats.FindStatValueByName("Will").ToString();
   //     PER.text = RandomStats.FindStatValueByName("Perception").ToString();
   //
   //     Size.text = "1" + _gameManager._size.ToString() + "0";
   //     APR.text = _gameManager._actionPoints.ToString();
   //     DMG.text = _gameManager._totalDamage.ToString();
   //     HP.text = _gameManager._health.ToString();
   //
   // }
    /*
        public void InrementAGI()
        {

            if (RandomStats.FindStatValueByName("Agility") > 3) { return; }
            RandomStats.IncrementStat("Agility", 1);
        }
        public void DecrementAgi()
        {
            if (RandomStats.FindStatValueByName("Agility") < -3) { return; }
            RandomStats.DecrementStat("Agility", 1);

        }
        public void InrementSTR()
        {
            if (RandomStats.FindStatValueByName("Strength") > 3) { return; }
            RandomStats.IncrementStat("Strength", 1);
        }
        public void DecrementSTR()
        {
            if (RandomStats.FindStatValueByName("Strength") < -3) { return; }
            RandomStats.DecrementStat("Strength", 1);
        }
        public void InrementSTA()
        {
            if (RandomStats.FindStatValueByName("Stamina") > 3) { return; }
            RandomStats.IncrementStat("Stamina", 1);
        }
        public void DecrementSTA()
        {
            if (RandomStats.FindStatValueByName("Stamina") < -3) { return; }
            RandomStats.DecrementStat("Stamina", 1);
        }
        public void InrementINT()
        {
            if (RandomStats.FindStatValueByName("Intellect") > 3) { return; }
            RandomStats.IncrementStat("Intellect", 1);
        }
        public void DecrementINT()
        {
            if (RandomStats.FindStatValueByName("Intellect") < -3) { return; }
            RandomStats.DecrementStat("Intellect", 1);
        }
        public void InrementWILL()
        {
            if (RandomStats.FindStatValueByName("Will") > 4) { return; }
            RandomStats.IncrementStat("Will", 1);
        }
        public void DecrementWILL()
        {
            if (RandomStats.FindStatValueByName("Will") < -4) { return; }
            RandomStats.DecrementStat("Will", 1);
        }
        public void InrementPER()
        {
            if (RandomStats.FindStatValueByName("Perception") > 4) { return; }
            RandomStats.IncrementStat("Perception", 1);
        }
        public void DecrementPER()
        {
            if (RandomStats.FindStatValueByName("Perception") < -4) { return; }
            RandomStats.DecrementStat("Perception", 1);
        }

        */
    //public void ToScreen1()
    //{
    //    _page1.SetActive(true);
    //    _page2.SetActive(false);
    //}
    //public void ToScreen2()
    //{
    //    _page1.SetActive(false);
    //    _page2.SetActive(true);
    //    
    //}

    public void CreateNewCharacterButton()
    {
        //Call needed functions
        _startScreenPanel.SetActive(false);

    }

    private void ShowCurrentPanel()
    {
        // Set all panels inactive
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }

        // Set the current panel active
        panels[currentPanelIndex].SetActive(true);
    }

    public void SwitchPanelOrToggle()
    {
        // Check if all panels are currently active
        if (AreAllPanelsActive())
        {
            // If all panels are active, switch to the next panel
            SwitchToNextPanel();
        }
        else
        {
            // If not all panels are active, toggle visibility of all panels
            ToggleAllPanels();
        }
    }

    private void ToggleAllPanels()
    {
        // Toggle visibility of all panels
        foreach (var panel in panels)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    private void SwitchToNextPanel()
    {
        // Increment the index and wrap around if needed
        currentPanelIndex = (currentPanelIndex + 1) % panels.Length;

        // Show the updated panel
        ShowCurrentPanel();
    }

    private bool AreAllPanelsActive()
    {
        // Check if all panels are currently active
        foreach (var panel in panels)
        {
            if (!panel.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}


