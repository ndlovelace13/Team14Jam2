using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreAdjust : MonoBehaviour
{
    [SerializeField] int score;
    bool fall = false;
    public TMP_Text txt;
    public AudioSource splash;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void OnTriggerEnter(Collider coll)
    {
        
       
        if (coll.gameObject.tag == "ingredient" || coll.gameObject.tag == "sauce")
        {
            splash.Play();
            score = score + 5;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "zombie")
        {
            splash.Play();
            score = score - 1;
            Destroy(coll.gameObject);
            
        }
       if (coll.gameObject.tag == "player")
        {
            splash.Play();
            score = score - 1;
            fall = true;

        }



    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "score: " + score.ToString();
        if(fall == true)
        {
            Debug.Log("You can't go in the soup, silly!");
            fall = false;
        }
        
        

    }
}
