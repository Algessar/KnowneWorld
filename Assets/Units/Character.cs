using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    RandomStats _randomStats;
    public Character() : base() { }
    public ScriptableObject _statSO;

    public GameObject _characterPortrait; //gameObject.GetComponent<Image>();

    public List<Stat> _characterStatList;
    public Stat[] _statArray;
       

    public Size _playerSize;
    public PlayerRaces _characterRace;
    public List<Traits> _characterTraits = new List<Traits>();

    private void Awake()
    {
        _randomStats = FindAnyObjectByType<RandomStats>();
    }
    private void Start()
    {
        _randomStats.AssignAllRandom();
        
    }
    private void Update()
    {
        StatListTest();
    }
    public void CalculateActionPoints()
    {
        _actionPoints = _baselineAPR;
        int temp = 0;
        temp = _randomStats.FindStatValueByName("Agility") / 2;
        _actionPoints += temp;
    }

    public void StatListTest()
    {
        _characterStatList = new List<Stat>();
        _characterStatList = _randomStats.statList;

        _statArray = _characterStatList.ToArray();
    }


}
