using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemiesToSpawn;
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnRate);
    }

    public void SpawnEnemy()
    {
        int randomRoll = (int)Random.Range(0, enemiesToSpawn.Length);
        Instantiate(enemiesToSpawn[randomRoll], new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z), transform.rotation);
    }
}
