using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject ch in characters)
        {
            ch.SetActive(false);
        }

        characters[selectedCharacter].SetActive(true);
        Player.characterSelectedIdx = selectedCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCharacter(int newCharacterIdx)
    {
        characters[selectedCharacter].SetActive(false);
        characters[newCharacterIdx].SetActive(true);
        selectedCharacter = newCharacterIdx;
    }
}
