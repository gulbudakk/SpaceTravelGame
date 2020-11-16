using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject spawnPoint;
    public List<GameObject> maps;
    public CircleCollider2D colliderCircle1;
    public CircleCollider2D colliderCircle2;

    void OnTriggerEnter2D()
    {
        if (spawnPoint != null)
        {
            int rand = Random.Range(0, maps.Count);
            Instantiate(maps[rand], spawnPoint.transform.position, Quaternion.identity);
            colliderCircle1.enabled = true;
            colliderCircle2.enabled = true;
            Destroy(spawnPoint);
        }
    }
}
