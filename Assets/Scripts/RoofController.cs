using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofController : MonoBehaviour
{
    [SerializeField]
    private bool isHiddenWhenOn;
   

    // Start is called before the first frame update
    void Start()
    {
     isHiddenWhenOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHiddenWhenOn)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if(!isHiddenWhenOn)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        
        
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHiddenWhenOn = true;
            print("´ê¾Ò´Ù");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHiddenWhenOn = false;
            print("¶³¾î ºµû");
        }
    }




}
