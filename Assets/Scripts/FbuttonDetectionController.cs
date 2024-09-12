using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbuttonDetectionController : MonoBehaviour
{
    public GameObject fButton;
    private Camera mainCamera;

    private bool inputF;


    private void Start()
    {
        fButton = gameObject.transform.Find("Fbutton").gameObject;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            inputF = true;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inputF = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
           /* Vector3 directionToCamera = mainCamera.transform.position - mainCamera.transform.position;
            fButton.transform.rotation = Quaternion.LookRotation(directionToCamera);*/

            // TextMesh �����ֱ�
            if (inputF)
            {
                fButton.GetComponent<MeshRenderer>().enabled = false;
            } else
            {
                fButton.GetComponent<MeshRenderer>().enabled = true;
            }
            
           /* fButton.transform.LookAt(Camera.main.transform);*/
        }

    }

    // �÷��̾�� �������� �� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // TextMesh �����
          
            fButton.GetComponent<MeshRenderer>().enabled = false;
            inputF = false;
        }
    }
}
