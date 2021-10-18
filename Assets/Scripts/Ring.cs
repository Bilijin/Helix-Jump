using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;
    private CharacterSelection characterSelection;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        characterSelection = GameObject.FindObjectOfType<CharacterSelection>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > player.position.y)
        {
            FindObjectOfType<AudioManager>().Play("Woosh");
            GameManager.noOfPassedRings++;
            GameManager.score++;

            GameManager.numPassedCombo++;
            if(GameManager.numPassedCombo == 3)
            {
                //changes the player skin to the combo ball skin
                characterSelection.ChangeCharacter(4);
                Player.playerTR.material = Player.comboMaterial;

            }
            Destroy(gameObject);
        }
    }
}
