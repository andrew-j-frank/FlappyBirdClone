using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{    
    #region Methods

    /// <summary>
    /// This coroutine shakes the camera
    /// </summary>
    /// <param name="duration">the duration of the shake</param>
    /// <param name="magnitude">the magnitude of the shake</param>
    /// <returns></returns>
    public IEnumerator Skake(float duration, float magnitude)
    {
        Vector3 origPos = transform.localPosition;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            float x = Random.Range(-1f,1f) * magnitude;
            float y = Random.Range(-1f,1f) * magnitude;

            transform.localPosition = new Vector3(x, y, origPos.z);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = origPos;
    }

    #endregion
}
