using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool isShaking;
    public IEnumerator Shake(float duration, float magnitude)
    {
        Debug.Log("Shake!");
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        if(!isShaking)
        {
            isShaking = true;
            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);

                elapsed += Time.deltaTime;

                yield return null; // wait for next frame in game update then run loop from top
            }

            transform.localPosition = originalPos;
            isShaking = false;
        }

    }
}
