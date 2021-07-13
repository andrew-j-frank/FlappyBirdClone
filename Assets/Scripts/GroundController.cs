using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    #region Fields

    public float speed = 1;
    private BoxCollider2D bc;
    private float groundLength;
    private bool move = true;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        groundLength = bc.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

            if(transform.position.x <= -groundLength)
            {
                transform.position = new Vector2(transform.position.x + 2* groundLength, transform.position.y);
            }
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

    private void Freeze()
    {
        move = false;
    }

    #endregion
}
