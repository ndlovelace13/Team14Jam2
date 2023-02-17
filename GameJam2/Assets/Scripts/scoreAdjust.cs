using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreAdjust : MonoBehaviour
{
    int score;
    public TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "soup")
        {
            score++;
        }
      //Destroy(gameObject); // destroy the tomato after it joins the soup
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "score: " + score.ToString();

    }
}
