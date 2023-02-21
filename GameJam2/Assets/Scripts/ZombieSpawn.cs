using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField] private GameObject controller;
    [SerializeField] private GameObject zombie;
    [SerializeField] private int spawnCooldown = 5;
    private float currentTime = 0;
    private bool spawnerActive = false;
    [SerializeField] private int spawnCount = 0;
    [SerializeField] private int maxSpawn = 2;
    private int spawnWave = 1;
    // Start is called before the first frame update
    void Start()
    {
        spawnerActive = controller.GetComponent<GameStateControl>().zombiesAttacking;
        spawnCount = controller.GetComponent<GameStateControl>().spawnCount;
    }

    // Update is called once per frame
    void Update()
    {
        spawnerActive = controller.GetComponent<GameStateControl>().zombiesAttacking;
        if (spawnerActive && currentTime >= spawnCooldown)
        {
            Instantiate(zombie, transform.position, Quaternion.identity);
            controller.GetComponent<GameStateControl>().spawnCount++;
            spawnCount = controller.GetComponent<GameStateControl>().spawnCount;
            currentTime = 0;
            print("Current spawn count:" + spawnCount);
        }
        else if (spawnerActive)
        {
            currentTime += Time.deltaTime;
        }

        if (spawnCount == maxSpawn)
        {
            spawnCount = 0;
            //if (maxSpawn < 5)
            maxSpawn += 2;
            spawnWave++;
            print("Current wave: " + spawnWave);
            print("Current maxSpawn: " + maxSpawn);
            if (spawnWave == 4)
                controller.GetComponent<GameStateControl>().gameEnd = true;
            controller.GetComponent<GameStateControl>().spawnCount = 0;
            spawnCount = controller.GetComponent<GameStateControl>().spawnCount;
            controller.GetComponent<GameStateControl>().zombiesAttacking = false;
        }
    }
}
