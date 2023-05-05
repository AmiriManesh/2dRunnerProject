using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Canvas gameOverCanvas;
    [SerializeField]
    private Text currentScore , bestScore;
    private ScoreCounter scoreCounter;
    private void Awake()
    {
        scoreCounter = GetComponent<ScoreCounter>();
    }
    
    public void GameOverShowPanel()
    {
        SoundManager.instance.Play_GameOverSound();
        Time.timeScale = 0f;
        gameOverCanvas.enabled = true;
        DisplayScore();
        CheckToUnlockNewCharacters(scoreCounter.GetScore());
    }

    void DisplayScore()
    {
        int highscore = DataManager.GetData(TagManager.HIGHSCORE_DATA);
        if (scoreCounter.GetScore() > highscore)
            DataManager.SaveData(TagManager.HIGHSCORE_DATA, scoreCounter.GetScore());

        currentScore.text = "Score: " + scoreCounter.GetScore() + "m";
        bestScore.text = "Best : " + DataManager.GetData(TagManager.HIGHSCORE_DATA) + "m";
    }

    void CheckToUnlockNewCharacters(int score)
    {
        GamePlayController.instance.CheckToUnlockCharacter(score);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(TagManager.GAMEPLAY_SCENE_NAME);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(TagManager.MAIN_MENU_SCENE_NAME);
    }

}
