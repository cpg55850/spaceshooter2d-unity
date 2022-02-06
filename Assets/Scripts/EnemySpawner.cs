using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime = 1f;
    private float objectWidth, objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyWave());
        objectWidth = enemyPrefab.transform.GetComponent<SpriteRenderer>().bounds.size.x;
        objectHeight = enemyPrefab.transform.GetComponent<SpriteRenderer>().bounds.size.y;
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
        float xPos = GameManager.Instance.maxX + (objectWidth / 2);
        float yPos = Random.Range(GameManager.Instance.minY + (objectHeight / 2), GameManager.Instance.maxY - (objectHeight / 2));
        Instantiate(enemyPrefab, new Vector2(xPos, yPos), Quaternion.identity);
    }

    IEnumerator EnemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
