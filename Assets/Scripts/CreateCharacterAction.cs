using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterAction : MonoBehaviour {

    private string textInput;
    
    public void CreateCharacter() {
        textInput = GetComponent<Text>().text;
        GameControl.player.setPlayerName(textInput);
    }
}
