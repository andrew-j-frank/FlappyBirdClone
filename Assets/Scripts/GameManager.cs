using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class is responsible for creating events that can be triggered and picked up by other scripts
public class GameManager : MonoBehaviour
{
    #region Fields

    /// <summary>
    /// The singleton instance of GameManager
    /// </summary>
    /// <value></value>
    public static GameManager Instance { get; private set; }

    // Get references to most of the objects in the game
    public BirdController bird;
    public ScoreController score;
    public HighScoreController highScore;
    public GameObject replayBtn;
    public PipeSpawner pipeSpawner;
    public GameObject pipes;
    public GameObject startCanvas;
    public GameObject gameCanvas;
    public GameObject deathCanvas;
    public GameObject newHighScoreTxt;
    public CameraShake cameraShake;
    public ParticleSystem confetti;

    // Internal variables
    private static bool restarted = false;
    private bool startCalled = false;
    private bool newHighScore = false;

    #endregion

    #region Unity Methods

    // Awake is called as soon as this object is instanciated
    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startCalled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(restarted && startCalled)
        {
            StartGame();
            restarted = false;
            startCalled = false;
        }
        else if(startCalled)
        {
            startCalled = false;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Restarts the game
    /// </summary>
    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        restarted = true;
    }

    /// <summary>
    /// Starts the game after the menu
    /// </summary>
    public void StartGame()
    {
        startCanvas.SetActive(false);
        replayBtn.SetActive(false);
        gameCanvas.SetActive(true);
        bird.Unfreeze();
        pipeSpawner.StartSpawningPipes();
    }

    /// <summary>
    /// Gets called when the game ends
    /// </summary>
    public void GameOver()
    {
        EventManager.Instance.StopMovement();
        gameCanvas.SetActive(false);
        highScore.saveHighScore();
        deathCanvas.SetActive(true);
        if(newHighScore)
        {
            newHighScoreTxt.SetActive(true);
        }
        StartCoroutine(cameraShake.Skake(0.07f, 0.07f));
        replayBtn.SetActive(true);
    }

    /// <summary>
    /// Increases the score and high score
    /// </summary>
    public void IncreaseScore()
    {
        print("Score Up");
        score.IncreaseScore();
        if(score.getScore() > highScore.getHighScore())
        {
            highScore.IncreaseHighScore();
            if(newHighScore == false)
            {
                newHighScore = true;
                confetti.Play();
            }
        }
    }

    /// <summary>
    /// Gets the pipes for the pipe spawner to spawn
    /// </summary>
    /// <returns>The pipe object to be spawned</returns>
    public GameObject GetPipes()
    {
        return pipes;
    }

    #endregion
}
