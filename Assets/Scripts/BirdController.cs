using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    #region Fields
    public float velocity = 1;
    public float xVelocity = 0;
    private Rigidbody2D rb;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Freeze();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && rb.constraints == RigidbodyConstraints2D.FreezePositionX)
        {
            // jump
            rb.velocity = Vector2.up * velocity;
        }

        Vector2 moveDirection = rb.velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, xVelocity) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnEnable()
    {
        EventManager.Instance.OnStopMovement += Die;
    }

    void OnDisable()
    {
        if(EventManager.Instance != null)
        {
            EventManager.Instance.OnStopMovement -= Die;
        }
    }

    // Runs when the bird passes through a pipe
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pipes"))
        {
            // increase score
            GameManager.Instance.IncreaseScore();
        }
    }

    // Runs when the bird collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Run if the bird dies
        if(collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            // Game Over
            GameManager.Instance.GameOver();
        }
    }

    #endregion

    #region Methods

    public void Freeze()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Unfreeze()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    public void Die()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.velocity = new Vector2(Random.Range(-1, 2.5f), Random.Range(2, 5));
        GetComponent<PolygonCollider2D>().enabled = false;
        Invoke("Freeze", 5);
    }

    #endregion
}
