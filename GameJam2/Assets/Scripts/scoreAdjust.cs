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
            score = score + 5;
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "zombie")
        {
            score = score - 1;
            Destroy(coll.gameObject);
            
        }



    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "score: " + score.ToString();
        
        

    }
}
