using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreator : MonoBehaviour
{

    public void CreateCharacter()
    {
        string tempName = "";
        string characterName = GameManager.Instance._nameInputField.text;
        if (GameManager.Instance.CharacterNameExists(characterName) || GameManager.Instance._nameInputField.text == tempName)
        {
            Debug.Log("Character with that name already exists, or you did not choose a name.");
            return;
        }
        else
        {
            Character _character = new Character();
            _character._name = characterName;
            _character.OnCharacterCreated();

            GameManager.Instance._listExistingCharacters.Add(_character);            
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
