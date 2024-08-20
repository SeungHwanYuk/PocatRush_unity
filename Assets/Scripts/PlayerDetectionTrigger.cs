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
            // ����ؼ� �÷��̾ �ٶ󺻴�
            transform.LookAt(other.transform);

            // TextMesh �����ֱ�
            GameObject textMesh = GameObject.FindWithTag("TextMesh");
            textMesh.GetComponent<MeshRenderer>().enabled = true;
        }
        
    }

    // �÷��̾�� �������� �� ����
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // TextMesh �����
            GameObject textMesh = GameObject.FindWithTag("TextMesh");
            textMesh.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
