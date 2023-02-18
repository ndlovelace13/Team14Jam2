using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    float throwForce = 1300;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject holder;
    public bool isHold = false;
    Vector3 startPosition;

    void Start()
    {
        startPosition = item.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, holder.transform.position);
        if(distance >= 5f)
        {
            isHold = false;
        }
        if(isHold == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            item.transform.SetParent(holder.transform);

            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(holder.transform.forward * throwForce);
                isHold = false;
            }

        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
        
    }

    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "floor")
        {
            Debug.Log("Dropping food on the floor is unsanitary.");
            item.transform.position = startPosition;
        }
    }


        void OnMouseDown()
    {
        if (distance <= 5f)
        {
            isHold = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

    void OnMouseUp()
    {
        isHold = false;
    }
}
