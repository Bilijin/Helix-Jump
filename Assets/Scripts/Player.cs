using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;
    private AudioManager audioManager;
    public static int characterSelectedIdx;
    private CharacterSelection characterSelection;
    public static TrailRenderer playerTR;

    public Material comboColorMaterial;
    //static non viewable in editor
    public static Material comboMaterial;
    private Material normMaterial;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        characterSelection = FindObjectOfType<CharacterSelection>();
        playerTR = gameObject.GetComponent<TrailRenderer>();

        normMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
        comboMaterial = comboColorMaterial;

        playerTR.material = normMaterial;
        //comboColorMaterial = new Material(Shader.Find("Default-Diffuse"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        string matName = collision.transform.GetComponent<MeshRenderer>().material.name;

        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        audioManager.Play("Bounce");

        //if the player has passed three rings in a row without touching them
        //destroy the next ring the player touches and continue the game
        if (GameManager.numPassedCombo >= 3 && matName != "Last Ring (Instance)")
        {
            Destroy(collision.gameObject);
            GameManager.numPassedCombo = 0;
            //changes the player skin to the originally selected skin
            characterSelection.ChangeCharacter(characterSelectedIdx);
            
            playerTR.material = normMaterial;
            return;
        } else if(GameManager.numPassedCombo >= 3 && matName == "Last Ring (Instance)")
        {
            //changes the player skin to the originally selected skin
            characterSelection.ChangeCharacter(characterSelectedIdx);
            playerTR.material = normMaterial;
        }

        characterSelection.ChangeCharacter(characterSelectedIdx);
        playerTR.material = normMaterial;
        GameManager.numPassedCombo = 0;

        if(matName == "Safe (Instance)")
        {
            //do safe
        } else if (matName == "Unsafe (Instance)")
        {
            //not safe
            Debug.Log("Game Over!");
            GameManager.isGameOver = true;
            audioManager.Play("GameOverSound");
        }
        else if(matName == "Last Ring (Instance)")
        {
            //end
            GameManager.isLevelCompleted = true;
            audioManager.Play("WinSound");
        }
    }
}
