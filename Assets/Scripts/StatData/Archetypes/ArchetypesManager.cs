using UnityEngine;
using System.Collections.Generic;

public class ArchetypeManager : MonoBehaviour
{
    public List<Stat> _statList = new List<Stat>();
    Character _character;
    StatCreator _statCreator;

    public SOArchetypeData _data;

    ArchTest archetypeTest;

    // Get the Name and Value of the Archetype itself.


    private void Awake()
    {
        _statCreator = new StatCreator();   
        
    }
    private void Start()
    {
        testing();
    }
    public void FinishedList()
    {
        RollArchetypeValues(_statList);
    }

    public void RollArchetypeValues( List<Stat> stat )
    {

        _statList = GetArchetypeValues();
        foreach (Stat s in stat)
        {
            s.value = (int)Random.Range(4, 10); // This is wrong. This sets the Core skills.
        }
        _statList.AddRange(stat);

        int value = 1;
        _data._archetypeValue = value;
    }

    public List<Stat> GetArchetypeValues()
    {
        var statCreator = new StatCreator();
        _statList.Clear();
        _statList = statCreator.PopulateArchetypeList();
        
        var archetype = DataManager.Instance._SOArchetypes;
        foreach (var entry in archetype)
        {
            entry._archetypeValue = (int)Random.Range(4, 10);
            //value = (int)Random.Range(4, 10);  
        }
        return _statList;
    }
    public List<Stat> testing()
    {
        var statCreator = new StatCreator();
        
        _statList = statCreator.TestPopulateArchetypeList(DataManager.Instance._ArchTest);

        
        
        return _statList;
    }

}

/*
//DEPRECATED. Now uses the same stat creation system as base stats.

public class ArchetypeManager : MonoBehaviour
{
    // TODO: ArchetypeManager: Make sure things are rounded correctly
    // TODO: ArchetypeManager: 

    public class Archetype
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Dictionary<string, int> CoreSkills { get; set; }
    }

    GameManager _gameManager;
        
    public Dictionary<string, Archetype> _archetypes = new Dictionary<string, Archetype>();

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
        SetArchetypeAndCoreSkillDicts();       
    }

    private void Update()
    {
        var printEngineering = _archetypes["Engineering"].Value;
       // Debug.Log("Current Engineering SV: " + printEngineering);
    }
    void SetArchetypeAndCoreSkillDicts()
    {

        //initialization for Archetype/Core dictionaries
        Archetype alchemyArchetype = new Archetype
        {
            Name = "Alchemy",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {                
                {"Potion Brewing", 0 },
                {"Distillation", 0 },
                {"Identify Potion", 0 },
                {"Transmutation", 0 },
                {"Herbology", 0 },
            }
        };
        _archetypes["Alchemy"] = alchemyArchetype;

        Archetype athleticsArchetype = new Archetype
        {
            Name = "Athletics",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Avoidance", 0 },
                {"Jumping", 0 },
                {"Climbing", 0 },
                {"Sneaking", 0 },
                {"Lifting", 0 },
            }
        };
        _archetypes["Athletics"] = athleticsArchetype;

        Archetype craftingArchetype = new Archetype
        {
            Name = "Crafting",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Weapons", 0 },
                {"Armour", 0 },
                {"Jewellery", 0 },
                {"Carpentry", 0 },
                {"Masonry", 0 },
                {"Tailoring", 0 },
                {"Brewing", 0 },
                {"Leatherworking", 0 },
            }
        };
        _archetypes["Crafting"] = craftingArchetype;

        Archetype defenceArchetype = new Archetype
        {
            Name = "Defence",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Avoidance", 0 },
                {"Blocking", 0 },
                {"Parrying", 0 },
                {"Maneuvers", 0 }
            }
        };
        _archetypes["Defence"] = defenceArchetype;

        Archetype engineeringArchetype = new Archetype
        {
            Name = "Engineering",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Automatons", 0 },
                {"Clockwork", 0 },
                {"Firearms", 0 },
                {"Steam", 0 },
            }
        };
        _archetypes["Engineering"] = engineeringArchetype;

        Archetype investigationArchetype = new Archetype
        {
            Name = "Investigation",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Criminal Profiling", 0 },
                {"EvidenceHandling", 0 },
                {"Forensics", 0 },
                {"Interrogation", 0 },
                {"Legal", 0 },
                {"Surveillance", 0 },
            }
        };
        _archetypes["Investigation"] = investigationArchetype;

        Archetype knowledgeArchetype = new Archetype
        {
            Name = "Knowledge",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Argument", 0 },
                {"Biology", 0 },
                {"Geology", 0 },
                {"History", 0 },
                {"Physics", 0 },
                {"Reading", 0 },
            }
        };
        _archetypes["Knowledge"] = knowledgeArchetype;

        Archetype magicArchetype = new Archetype
        {
            Name = "Magic",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Read Magic", 0 },
                {"Spellcasting", 0 },
                {"Runes", 0 },
                {"Sigils", 0 },
            }
        };
        _archetypes["Magic"] = magicArchetype;

        Archetype martialArchetype = new Archetype
        {
            Name = "Martial",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Swords", 0 },
                {"Hammer", 0 },
                {"Spears", 0 },
                {"Bows", 0 },
                {"Rifles", 0 },
                {"Pistols", 0 },
            }
        };
        _archetypes["Martial"] = martialArchetype;

        Archetype socialArchetype = new Archetype
        {
            Name = "Social",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"Deception", 0 },
                {"Intimidation", 0 },
                {"Dancing", 0 },
                {"Singing", 0 },
                {"Theatrics", 0 },
                {"Instrument", 0 },
            }
        };
        _archetypes["Social"] = socialArchetype;

        Archetype survivalArchetype = new Archetype
        {
            Name = "Survival",
            Value = 0,
            CoreSkills = new Dictionary<string, int>
            {
                {"AnimalHandling", 0 },
                {"Foraging", 0 },
                {"Tracking", 0 },
                {"Trapping", 0 },
                {"Shelter", 0 },
                {"Skinning", 0 },
            }
        };
        _archetypes["Survival"] = survivalArchetype;

        
        
    }

    //If I need to get the names and values of all dict entries I can use this.
    public void PrintAllArchetypesAndCoreSkills()
    {
        foreach (var archetypeEntry in _archetypes)
        {
            string archetypeName = archetypeEntry.Key;
            Archetype archetypeData = archetypeEntry.Value;

            Debug.Log($"Archetype: {archetypeName}, Archetype Value: {archetypeData.Value}");

            foreach (var coreSkillEntry in archetypeData.CoreSkills)
            {
                string coreSkillName = coreSkillEntry.Key;
                int coreSkillValue = coreSkillEntry.Value;

                Debug.Log($"Core Skill: {coreSkillName}, Value: {coreSkillValue}");
            }
        }
    }
    public void CalculateArchetypeStartValues()
    {
        AddBaseStatsToArchetype(_archetypes["Alchemy"], _archetypes["Intellect"].Value, _archetypes["Agility"].Value);        
    }

    public void AddBaseStatsToArchetype(Archetype archetype, int statOne, int statTwo)
    {
        
        archetype.Value = (statOne + (statTwo / 2));
    }

    public void JustForTestingValues()
    {
        foreach (var archetypeEntry in _archetypes)
        {
            string archetypeName = archetypeEntry.Key;
            Archetype archetypeData = archetypeEntry.Value;

            Debug.Log($"Archetype: {archetypeName}, Archetype Value: {archetypeData.Value}");

            foreach (var coreSkillEntry in archetypeData.CoreSkills)
            {
                string coreSkillName = coreSkillEntry.Key;
                int coreSkillValue = coreSkillEntry.Value;
                coreSkillValue = 5;
                

                Debug.Log($"Core Skill: {coreSkillName}, Value: {coreSkillValue}");
            }
        }
    }
}

*/