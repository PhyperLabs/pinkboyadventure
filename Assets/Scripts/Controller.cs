using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public GameObject player;
    public GameObject gameOver;
    public GameObject pauseMenu;
    public GameObject TouchControl;
    public GameObject on;
    public GameObject off;
    public static Controller instance;
    public string menu;
    public string lvlName;
    public string nextLevel;
    public string previousLevel;
    private AudioSource som;
    private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
        instance = this;
        //totalScore = Score.pontos;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = Score.pontos.ToString();
    }

    public void GameOver()
    {
        MusicController.isso.backGroundSound.Pause();
        MusicController.isso.gameOverSound.Play();
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        som.Play();
        MusicController.isso.backGroundSound.UnPause();
        MusicController.isso.gameOverSound.Stop();
        SceneManager.LoadScene(lvlName);
        Score.pontos -= totalScore;
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(menu);
        Score.pontos = 0;
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        MusicController.isso.Clean();
        Application.Quit();
    }
    
    public void Plim()
    {
        som.Play();
    }

    public void Pause()
    {
        isPause = !isPause;
        if(isPause)
        {
            MusicController.isso.backGroundSound.Pause();
            MusicController.isso.mainMenuSound.Play();
            TouchControl.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            MusicController.isso.backGroundSound.UnPause();
            MusicController.isso.mainMenuSound.Stop();
            TouchControl.SetActive(true);
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void EnablePopUp()
    {
        on.SetActive(true);
        off.SetActive(false);
    }

    public void DisablePopUp()
    {
        on.SetActive(false);
        off.SetActive(true);
    }
}
