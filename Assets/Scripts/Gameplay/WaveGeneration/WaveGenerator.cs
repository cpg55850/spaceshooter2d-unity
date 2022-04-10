using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    public Wave[] waves;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while(true)
        {
            foreach (Wave W in waves) {
                foreach(WaveAction A in W.waveActions)
                {
                    if (A.delay > 0)
                        yield return new WaitForSeconds(A.delay);
                    if(A.message != "")
                    {
                        //Debug.Log(A.message);
                        StartCoroutine(GameManager.Instance.drawWave(A.message));
                    }
                    if(A.prefab != null && A.enemies.Length > 0)
                    {
                        for(int i = 0; i < A.enemies.Length; i++)
                        {
                            Enemy enemy = A.enemies[i];
                            float objectWidth = enemy.prefab.transform.GetComponent<SpriteRenderer>().bounds.size.x;
                            float objectHeight = enemy.prefab.transform.GetComponent<SpriteRenderer>().bounds.size.y;

                            float xPos = GameManager.Instance.maxX + (objectWidth / 2);
                            //float yPos = Random.Range(GameManager.Instance.minY + (objectHeight / 2), GameManager.Instance.maxY - (objectHeight / 2));
                            float yPos = enemy.yPos;
                            if(A.enemyDelay > 0)
                            {
                                yield return new WaitForSeconds(A.enemyDelay);
                            } else if(enemy.delay > 0)
                                yield return new WaitForSeconds(A.enemies[i].delay);
                            Instantiate(enemy.prefab, new Vector2(xPos, yPos), Quaternion.identity);
                        }
                    }
                    yield return null;  // prevents crash if all delays are 0
                }
                yield return null;  // prevents crash if all delays are 0
            }
        }
    }
}
