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
        //if (spawnerActive)
       // {

       // }
    }
}
