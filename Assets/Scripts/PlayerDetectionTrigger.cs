using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionTrigger : MonoBehaviour
{
    // �÷��̾� ���� ���� ���� �ڵ�
    

    // ������ �����Ѵٸ� ���� ���� ���� Stay
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            // �÷��̾ ������ ����ؼ� ī�޶� �ٶ󺻴�
            transform.LookAt(Camera.main.transform);

            // TextMesh �����ֱ�
     GameObject textMesh = transform.Find("Fbutton").gameObject;
            textMesh.GetComponent<MeshRenderer>().enabled = true;
        }
        
    }

    // �÷��̾�� �������� �� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // TextMesh �����
     GameObject textMesh = transform.Find("Fbutton").gameObject;
            textMesh.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
