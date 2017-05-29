using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterAction : MonoBehaviour {

    private string textInput;
    private PlayerInfo playerInfo;

    void Awake() {
        playerInfo = FindObjectOfType<PlayerInfo>().GetComponent<PlayerInfo>();
    }

    public void CreateCharacter() {
        textInput = GetComponent<Text>().text;
        playerInfo.SetPlayerName(textInput);
    }
}
