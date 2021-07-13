using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    #region Fields

    public float maxTime = 1;
    public float minHeight = 0;
    public float maxHeight = 0;
    private float timer = 0;
    private bool startSpawning;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        startSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print("startSpawning: " + startSpawning.ToString());
        if(startSpawning)
        {
            if(timer > maxTime)
            {
                GameObject newPipes = Instantiate(GameManager.Instance.GetPipes());
                newPipes.transform.position = transform.position + new Vector3(0, Random.Range(minHeight, maxHeight));
                timer = 0;
            }

            timer += Time.deltaTime;
        }
    }

    void OnEnable()
    {
        EventManager.Instance.OnStopMovement += Freeze;
    }

    void OnDisable()
    {
        if(EventManager.Instance != null)
        {
            EventManager.Instance.OnStopMovement -= Freeze;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Signals the spawner to start spawning pipes
    /// </summary>
    public void StartSpawningPipes()
    {
        startSpawning = true;
    }

    private void Freeze()
    {
        startSpawning = false;
    }

    #endregion
}
