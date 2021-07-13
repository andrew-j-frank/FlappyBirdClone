using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    #region Fields

    public float speed = 1;
    public float despawnTime = 1;
    private bool move = true;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMe", despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
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
    /// Destroys this object
    /// </summary>
    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }

    private void Freeze()
    {
        CancelInvoke("DestroyMe");
        move = false;
    }

    #endregion
}
