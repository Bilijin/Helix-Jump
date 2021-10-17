using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEvents : MonoBehaviour
{
    public Text toggleSoundText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
        {
            toggleSoundText.text = "/";
        }
        else
        {
            toggleSoundText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QuitGame");
    }

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            toggleSoundText.text = "";
        }
        else
        {
            GameManager.mute = true;
            toggleSoundText.text = "/";
        }
    }
}
