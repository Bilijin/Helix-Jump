using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        audioManager.Play("Bounce");

        string matName = collision.transform.GetComponent<MeshRenderer>().material.name;
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
            Debug.Log("Game Completed!");
            GameManager.isLevelCompleted = true;
            audioManager.Play("WinSound");
        }
    }
}
