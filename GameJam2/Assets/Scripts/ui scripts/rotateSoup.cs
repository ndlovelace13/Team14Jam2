using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSoup : MonoBehaviour
{
    float rpm = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    void Update()
    {
        transform.Rotate(0, 0,  6 * rpm * Time.deltaTime);
    }
}
