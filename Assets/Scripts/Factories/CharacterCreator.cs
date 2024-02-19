using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour
{
    //StatCreator _statCreator = new StatCreator();
    RandomStats _randomStats = new RandomStats();

    public void CreateCharacter()
    {
        string tempName = "";
        string characterName = GameManager.Instance._nameInputField.text;
       //if (GameManager.Instance.CharacterNameExists(characterName) || GameManager.Instance._nameInputField.text == tempName)
       //{
       //    Debug.Log("Character with that name already exists, or you did not choose a name.");
       //    return;
       //}
        //else
        {
            _randomStats = new RandomStats();
            Character _character = new Character();
            _character._name = characterName;
            _character._characterRace = GameManager.Instance._currentlySelectedRace;
            _character._statList = _randomStats.AssignAllRandom();
            //_character.FillArchetypeList();
            _character.OnCharacterCreated();
            //_character._archetypeList = ArchetypeManager.Instance.SetInitialArchetypeValue();


            if (GameManager.Instance._listExistingCharacters.Count == 0)
            {
                GameManager.Instance._listExistingCharacters.Add(_character);
            }
            else
            {
                GameManager.Instance._listExistingCharacters.Clear();
                GameManager.Instance._listExistingCharacters.Add(_character);
            }
        }
    }


    private void SetCharacterID(Character character)
    {
        int tempID = 0;
        character._characterID = tempID;
    }
    private void Update()
    {
        //UIDisplay();
    }
    public void UIDisplay()
    {
        //_displayName.text = _character._name;
    }
}
