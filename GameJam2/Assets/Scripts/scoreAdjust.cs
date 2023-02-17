using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreAdjust : MonoBehaviour
{
    [SerializeField] int score;
    
    public TMP_Text txt;
   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void OnTriggerEnter(Collider coll)
    {
       
        if (coll.gameObject.tag == "ingredient")
        {
            score = score + 1;
            
        }
        if (coll.gameObject.tag == "zombie")
        {
            score = score - 1;
            
        }



    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "score: " + score.ToString();
        
        

    }
}
