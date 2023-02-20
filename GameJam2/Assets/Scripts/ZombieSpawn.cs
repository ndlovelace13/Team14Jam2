using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField] private GameObject controller;
    [SerializeField] private GameObject zombie;
    [SerializeField] private int spawnCooldown = 5;
    private float currentTime = 0;
    private bool spawnerActive = false;
    private int spawnCount = 0;
    private int maxSpawn = 2;
    // Start is called before the first frame update
    void Start()
    {
        spawnerActive = controller.GetComponent<GameStateControl>().zombiesAttacking;

    }

    // Update is called once per frame
    void Update()
    {
        spawnerActive = controller.GetComponent<GameStateControl>().zombiesAttacking;
        if (spawnerActive && currentTime >= spawnCooldown)
        {
            print("Zombie Spawned!");
            Instantiate(zombie, transform.position, Quaternion.identity);
            spawnCount++;
            currentTime = 0;
        }
        else if (spawnerActive)
        {
            currentTime += Time.deltaTime;
        }

        if (spawnCount == maxSpawn)
        {
            spawnCount = 0;
            maxSpawn += 2;
            controller.GetComponent<GameStateControl>().zombiesAttacking = false;
        }
    }
}
