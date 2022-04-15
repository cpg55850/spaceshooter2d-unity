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
                foreach (WaveAction A in W.waveActions)
                {
                    if (A.delay > 0)
                        yield return new WaitForSeconds(A.delay);
                    if(A.message != "")
                    {
                        //Debug.Log(A.message);
                        //StartCoroutine(UIManager.Instance.drawWave(A.message));
                    }
                    if(A.prefab != null && A.enemies.Length > 0)
                    {
                        for (int i = 0; i < A.spawnCount; i++)
                        {
                            for (int j = 0; j < A.enemies.Length; j++)
                                {

                                Enemy enemy = A.enemies[j];
                                float objectWidth = enemy.prefab.transform.GetComponent<SpriteRenderer>().bounds.size.x;
                                float objectHeight = enemy.prefab.transform.GetComponent<SpriteRenderer>().bounds.size.y;

                                float xPos = Screen.maxX + (objectWidth / 2);
                                //float yPos = Random.Range(GameManager.Instance.minY + (objectHeight / 2), GameManager.Instance.maxY - (objectHeight / 2));
                                float yPos = A.yOffset + enemy.yPos;
                                if (A.enemyDelay > 0)
                                {
                                    yield return new WaitForSeconds(A.enemyDelay);
                                }
                                else if (enemy.delay > 0)
                                    yield return new WaitForSeconds(A.enemies[j].delay);
                                GameObject o = (GameObject)Instantiate(enemy.prefab, new Vector2(xPos, yPos), Quaternion.identity);
                                if (A.enemies[j].movementData != null)
                                    o.GetComponent<Movement>().movementData = A.enemies[j].movementData;
                                else
                                    o.GetComponent<Movement>().movementData = A.movementData;

                                if(A.speed != 0f)
                                    o.GetComponent<Movement>().movementData.speed = A.speed;
                            }

                        }
                    }
                    yield return null;  // prevents crash if all delays are 0
                }
                yield return null;  // prevents crash if all delays are 0
            }
        }
    }
}
