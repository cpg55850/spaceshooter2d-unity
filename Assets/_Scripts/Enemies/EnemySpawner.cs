using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float respawnTime = 1f;
    private float objectWidth, objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        //if (respawnTime >= 0f)
        //    respawnTime -= Time.deltaTime * 0.0025f;
    }

    private void FixedUpdate()
    {

    }

    private void SpawnEnemy()
    {
        float randEnemy = Random.Range(0, 101);
        GameObject currentEnemy = enemies[0];

        //if (randEnemy > 50f)
        //{
        //    currentEnemy = enemies[0];
        //} else
        //{
        //    currentEnemy = enemies[1];
        //}

        if (GameManager.Instance.score >= 400)
        {
            if (randEnemy > 40f)
            {
                if (Random.Range(0, 2) == 0)
                    currentEnemy = enemies[1];
                else
                    currentEnemy = enemies[2];
            }
        }
        else if (GameManager.Instance.score >= 300)
        {
            if (randEnemy > 50f)
            {
                if (Random.Range(0, 2) == 0)
                    currentEnemy = enemies[1];
                else
                    currentEnemy = enemies[2];
            }
        }
        else if (GameManager.Instance.score >= 200)
        {
            if (randEnemy > 65f)
            {
                if (Random.Range(0, 2) == 0)
                    currentEnemy = enemies[1];
                else
                    currentEnemy = enemies[2];
            }
        }
        else if (GameManager.Instance.score >= 100)
        {
            if (randEnemy > 75f)
            {
                if (Random.Range(0, 2) == 0)
                    currentEnemy = enemies[1];
                else
                    currentEnemy = enemies[2];
            }
        }
        else if (GameManager.Instance.score >= 50)
        {
            if (randEnemy > 75f)
            {
                currentEnemy = enemies[1];
            }
        }

        //Debug.Log(currentEnemy + " " + randEnemy);

        objectWidth = currentEnemy.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = currentEnemy.transform.GetComponent<SpriteRenderer>().bounds.size.y;

        float xPos = Screen.maxX + (objectWidth / 2);
        float yPos = Random.Range(Screen.minY + (objectHeight / 2), Screen.maxY - (objectHeight / 2));
        Instantiate(currentEnemy, new Vector2(xPos, yPos), Quaternion.identity);
    }

    IEnumerator EnemyWave()
    {
        while (true)
        {
            if (GameManager.Instance.score >= 500)
            {
                yield return new WaitForSeconds(respawnTime * .3f);
            }
            else if (GameManager.Instance.score >= 400)
            {
                yield return new WaitForSeconds(respawnTime * .4f);
            }
            else if (GameManager.Instance.score >= 200)
            {
                yield return new WaitForSeconds(respawnTime*.5f);
            } 
            else if (GameManager.Instance.score >= 100)
            {
                yield return new WaitForSeconds(respawnTime * .75f);
            } else
            {
                yield return new WaitForSeconds(respawnTime);
            }

            SpawnEnemy();
        }
    }
}