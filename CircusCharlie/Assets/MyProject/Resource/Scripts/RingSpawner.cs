using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    public GameObject bigRingPrefab = default;
    public GameObject ringPrefab = default;

    public float timeBetSpawnMin = 0.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    private float xPos = 15f;

    public int count = 5;
    public GameObject[] rings;
    private int curIdx = 0;

    private Vector2 poolPosition = new Vector2(0, 25f);
    private float lastSpawnTime;

    void Start()
    {
        rings = new GameObject[count];

        rings[0] = Instantiate(ringPrefab, new Vector2(xPos, 0), Quaternion.identity);

        for (int i = 1; i < count; i++)
        {
            rings[i] = Instantiate(bigRingPrefab, new Vector2(rings[i - 1].transform.position.x + Random.Range(0, xPos), 0), Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }

    void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        for (int i = 0; i < count; ++i)
        {
            if (rings[i].transform.position.x <= -10f)
            {
                lastSpawnTime = Time.time;
                timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

                int idx = curIdx + 4;
                if (idx >= 5)
                {
                    idx -= 5;
                }

                if(rings[idx].transform.position.x < 10f)
                {
                    rings[curIdx].transform.position = new Vector2(Random.Range(10, xPos), 0);
                }
                else
                {
                    rings[curIdx].transform.position = new Vector2(rings[idx].transform.position.x + Random.Range(0, xPos), 0);
                }

                if(curIdx == 0)
                {
                    //RingSpawner rSpawner = FindObjectOfType<FoodSpawner>();
                    //rSpawner.SpawnFood(rings[curIdx]);
                }

                curIdx += 1;

                if (curIdx >= count)
                {
                    curIdx = 0;
                }
            }
        }
    }
}
