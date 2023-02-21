using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateControl : MonoBehaviour
{
    [SerializeField] public bool zombiesAttacking;
    public int spawnCount = 0;
    public bool gameEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        zombiesAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
