using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    #region Fields

    private int score;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Increases the score
    /// </summary>
    public void IncreaseScore()
    {
        score++;
        GetComponent<Text>().text = score.ToString();
    }

    /// <summary>
    /// Returns the score
    /// </summary>
    /// <returns>the score</returns>
    public int getScore()
    {
        return score;
    }

    #endregion
}
