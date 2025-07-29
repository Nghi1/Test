using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;             
    public Transform[] spawnPoints;          

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            StartCoroutine(MoveEnemyAfterDelay(enemy));
            yield return new WaitForSeconds(3f); 
        }
    }
    IEnumerator MoveEnemyAfterDelay(GameObject enemy)
    {
        yield return new WaitForSeconds(2f);

        Vector3 targetPos = GetRandomPosition(); 
        float speed = 2f;
        while (enemy != null && Vector3.Distance(enemy.transform.position, targetPos) > 0.1f)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
    }
    Vector3 GetRandomPosition()
    {
        float x = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);
        return new Vector3(x, 0, z); 
    }
}
