using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Spawner Details")]
    [SerializeField] GameObject itemPrefab;
    [SerializeField] int spawnTime;
    [SerializeField] bool spawnOnStart = true;
    [SerializeField] bool respawn;
    private bool spawning = false;

    [Header("Gizmo Details")]
    [SerializeField] float radius = 1f;

    private void Start()
    {
        if(!spawnOnStart)
        {
            return;
        }
        Instantiate(itemPrefab, transform);
    }

    private void Update()
    {
        if (!respawn)
        {
            return;
        }
        if(!spawning && transform.childCount == 0)
        {
            StartCoroutine(SpawnCountDown());
        }
    }

    IEnumerator SpawnCountDown()
    {
        spawning = true;
        int timer = spawnTime;
        while (timer > 0)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }
        Instantiate(itemPrefab, transform);
        spawning = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
