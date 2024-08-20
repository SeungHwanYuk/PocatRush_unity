using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionTrigger : MonoBehaviour
{
    
   

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(other.transform);
            GameObject TextMesh = GameObject.FindWithTag("TextMesh");
            TextMesh.GetComponent<MeshRenderer>().enabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject TextMesh = GameObject.FindWithTag("TextMesh");
            TextMesh.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
