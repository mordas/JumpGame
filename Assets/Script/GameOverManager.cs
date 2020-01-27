using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject gameOverPanel;
    public Animator anim;
    private Button _playAgainButton, _backBtn;
    private Text _finalScore;
    private GameObject _scoreText;
    private void Awake()
    {
        MakeInstance();
        InitializeVaribles();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void InitializeVaribles()
    {
        gameOverPanel = GameObject.Find("GameOver_Panel_Holder");
        anim = gameOverPanel.GetComponent<Animator>();
        _backBtn = GameObject.Find("BackButton").GetComponent<Button>();
        _playAgainButton = GameObject.Find("RestartButton").GetComponent<Button>();
        _backBtn.onClick.AddListener(() => BackToMenu());
        _playAgainButton.onClick.AddListener(() => PlayAgain());
        _finalScore = GameObject.Find("GameOverScore").GetComponent<Text>();
        _scoreText = GameObject.Find("Score_Text");
        gameOverPanel.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOverShowPanel()
    {
        _scoreText.SetActive(false);
        gameOverPanel.SetActive(true);
        anim.SetTrigger("GameOver");
        _finalScore.text = "Score\n" + "" + ScoreManager.instance.GetScore();
    }
}
