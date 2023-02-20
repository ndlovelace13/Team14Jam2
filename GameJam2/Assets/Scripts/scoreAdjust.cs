using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreAdjust : MonoBehaviour
{
    [SerializeField] public int score;
    bool fall = false;
    public TMP_Text txt;
    public TMP_Text soupType;
    public AudioSource splash;

    int sweet = 0;
    int spicy = 0;
    int savory = 0;

    int type = 0;
    string s = "Your soup needs more ingredients";



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

            if(coll.gameObject.name == "carrot")
            {
                savory += 30;
            }
            else if (coll.gameObject.name == "chilli pepper")
            {
                spicy += 15;
                
            }
            else if (coll.gameObject.name == "honey")
            {
                spicy -= 15;
                sweet += 40;
                savory -= 30;
            }
            else if (coll.gameObject.name == "jalepeno")
            {
                spicy += 15;
            }
            else if (coll.gameObject.name == "milk")
            {
                spicy -= 45;
                sweet += 20;
                savory += 10;
            }
            else if (coll.gameObject.name == "strawberry")
            {
                sweet += 30;
                savory -= 35;
            }
            else if (coll.gameObject.name == "steak")
            {
                spicy += 5;
                sweet -= 50;
                savory += 50;
            }
            else if (coll.gameObject.name == "tomato")
            {
                sweet += 10;
                savory += 15;

            }
            else if (coll.gameObject.name == "hotsauce")
            {
                spicy += 65;
                sweet -= 10;
            }



            if (savory > sweet && savory > spicy)
            {
                score = savory;
                type = 1; //savory soup
                s = "You are making a mostly savory soup. Good soup.";
            }
            else if (savory < sweet && sweet > spicy)
            {
                score = sweet;
                type = 2; //sweet soup
                s = "You are making a mostly sweet soup. You'll probably want to chill before serving.";
            }
            else if (spicy > sweet && savory < spicy)
            {
                score = spicy;
                type = 3; //spicy soup
                s = "You are making a mostly spicy soup. Careful, it's hot!";
            }
            else if (spicy > sweet && savory == spicy)
            {
                score = spicy;
                type = 5; //spicy savory soup
                s = "Your soup is savory and spicy. That sounds good!";
            }
            else if (savory == sweet && sweet > spicy)
            {
                score = sweet;
                type = 4; //sweet/savory soup soup
                s = "Your soup is sweet and savory... interesting";
            }
            else if (spicy == sweet && savory < spicy)
            {
                score = spicy;
                type = 6; //spicy sweet soup
                s = "Your soup is sweet and spicy. That's the best kind!";
            }
            else if (spicy == sweet && savory == spicy)
            {
                score = spicy;
                type = 6; //spicy sweet soup
                s = "Your soup is perfectly balanced, as all things should be";
            }


            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "zombie")
        {
            splash.Play();
            if ((score - 5) >= 0)
            {
                score = score - 5;
                savory -= 5;
                sweet -= 5;
                spicy -= 5;
            }
            else
            {
                score = 0;
                savory = 0;
                sweet = 0;
                spicy = 0;
            }
            Destroy(coll.gameObject);
            type = 8;
            s = "Why are there zombies in your soup?";
            
        }
       if (coll.gameObject.tag == "player")
        {
            splash.Play();
            if ((score - 5) >= 0)
            {
                score = score - 1;
                savory -= 1;
                sweet -= 1;
                spicy -= 1;
            }
            else
            {
                score = 0;
                savory = 0;
                sweet = 0;
                spicy = 0;
            }
            fall = true;
            type = 7;
            s = "You can't add yourself to the soup, silly.";

        }



    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Score: " + score.ToString();
        if(fall == true)
        {
            Debug.Log("You can't go in the soup, silly!");
            fall = false;
        }
        soupType.text = s;
        

    }
}
