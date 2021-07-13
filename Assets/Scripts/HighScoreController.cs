using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    #region Fields

    public bool resetHighScore;
    private int highScore;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        if(resetHighScore)
        {
            PlayerPrefs.DeleteKey("HighScore");
        }
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        GetComponent<Text>().text = "High Score: " + highScore.ToString();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Increases and displays the high score
    /// </summary>
    public void IncreaseHighScore()
    {
        highScore++;
        GetComponent<Text>().text = "High Score: " + highScore.ToString();
    }

    /// <summary>
    /// Gets the high score
    /// </summary>
    /// <returns>the high score</returns>
    public int getHighScore()
    {
        return highScore;
    }

    /// <summary>
    /// Saves the high score to player preferences
    /// </summary>
    public void saveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    #endregion
}
