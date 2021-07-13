using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScoreController : MonoBehaviour
{
    #region Unity Methods
    
    // Will change the text to the score the player had when they died
    void OnEnable()
    {
        GetComponent<Text>().text = "Final Score: " + GameManager.Instance.score.getScore();
    }

    #endregion
}
