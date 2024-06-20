using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startPanel;
    public GameObject gameoverPanel;
    public GameObject tapText;

    public Text score;
    public Text highScore1;
    public Text highScore2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        highScore1.text = "BestScore : " + PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
    }

    public void GameStart()
    {
        tapText.GetComponent<Animator>().Play("textRight");
        startPanel.GetComponent<Animator>().Play("panelRight");
        tapText.SetActive(false);

    }

    public void GameOver()
    {
        score.text = "Score : " + PlayerPrefs.GetInt("score");
        highScore2.text = "BestScore : " + PlayerPrefs.GetInt("highscore");
        gameoverPanel.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
