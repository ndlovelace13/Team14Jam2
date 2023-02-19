using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startController : MonoBehaviour
{
    //this script is solely to control the start screen and the description screen
    //and allow them to load the next scene
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if (Input.anyKey)
        {
            SceneManager.LoadScene(y + 1);
        }
    }

}
