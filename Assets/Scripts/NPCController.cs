using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    public UnityEvent onPlayerEntered;
    private bool playerOnkey;


    


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(other.transform);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            onPlayerEntered.Invoke();
            GameObject canvas = GameObject.FindWithTag("Canvas");

            if (canvas == null)
            {
                return;
            }


            Transform transform = canvas.transform;
            GameObject panel = transform.Find("Panel").gameObject;

            if (panel == null)
            {
                return;
            }

            panel.SetActive(true);
   
        };
    }
}
