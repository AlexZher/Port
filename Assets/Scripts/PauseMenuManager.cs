using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject panel;

    GameObject scoreManager;
    bool isPaused;
    float currentTimeScale;
    #endregion

    #region CustomMethods

    #endregion
	
    #region UnityMethods

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("highlighter");

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Configuration.isGameOver && !Configuration.isGameInAutoEnding)
        {
            
            if (isPaused)
                UnPauseGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        
        isPaused = true;
        scoreManager.SetActive(false);
        currentTimeScale = Time.timeScale;
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitToMenu()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);

        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }

    public void UnPauseGame()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        isPaused = false;
        scoreManager.SetActive(true);
        panel.SetActive(false);
        Time.timeScale = currentTimeScale;
    }
    #endregion
}