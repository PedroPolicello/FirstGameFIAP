using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    void Update()
    {

    }

    IEnumerator Spawner()
    {
        while (true)
        {
            float spawnTime = Random.Range(0.25f, 0.5f);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }
}
