using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isLevelCompleted = false;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;
    public static int currentLevelIdx;
    public Text currentLevelText;
    public Text nextLevelText;
    public Text scoreText;
    public Text highScoreText;
    public static int noOfPassedRings;
    public static int score = 0;
    public Slider gameProgressSlider;
    public static bool mute = false;
    public static bool isGameStarted;

    public static int numPassedCombo;

    private void Awake()
    {
        //PlayerPrefs.SetInt("CurrentLevelIndex", 1);
        //PlayerPrefs.SetInt("HighScore", 0);
        currentLevelIdx = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
        noOfPassedRings = 0;
        numPassedCombo = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        isGameOver = isLevelCompleted = false;
        isGameStarted = false;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                if(score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
                score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (isLevelCompleted)
        {
            Time.timeScale = 0;
            levelCompletedPanel.SetActive(true);
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIdx + 1);
                SceneManager.LoadScene("Level");
            }
        }

        currentLevelText.text = currentLevelIdx.ToString();
        nextLevelText.text = (currentLevelIdx + 1).ToString();
        scoreText.text = score.ToString();

        int progress = noOfPassedRings * 100 / FindObjectOfType<HelixManager>().noOfRings;
        gameProgressSlider.value = progress;

        if (Input.GetMouseButtonDown(0) & !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        } else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                return;
            }
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }
    }
}
