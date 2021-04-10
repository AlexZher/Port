using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public static class SpawnerUtils 
{
    #region Fields
    public static Difficulty difficulty = Difficulty.Easy;

    #endregion

    #region CustomMethods

    public static void SetDifficulty(Difficulty _difficulty)
    {
        
        difficulty = _difficulty;
        if (difficulty == Difficulty.Easy)
            SceneManager.LoadScene("gameplayEasy");
        else 
            if (difficulty == Difficulty.Medium)
                SceneManager.LoadScene("gameplayMedium");
            else
                SceneManager.LoadScene("gameplayHard");
    }

    #endregion
	

}