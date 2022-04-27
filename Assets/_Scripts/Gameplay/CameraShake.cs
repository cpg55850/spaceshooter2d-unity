using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : StaticInstance<CameraShake>
{
    private bool isShaking;

    protected override void Awake()
    {
        base.Awake();
        PlayerHealth.onDamageTaken += PlayerDamageShake;
    }

    private void OnDestroy()
    {
        PlayerHealth.onDamageTaken -= PlayerDamageShake;
    }


    public void PlayerDamageShake(Health playerHealth)
    {
        StartCoroutine(ShakeCoroutine(.25f, .25f));
    }

    public IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
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
