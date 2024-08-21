using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    // Event ȣ�� 
    // �ݶ��̴��� �÷��̾ ����� �� ���� ����
    public UnityEvent onPlayerEntered;

    public GameObject canvas;

    // Ű �Է� boolean
    private bool playerInput;
    private bool playerEnter;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            // ��� �ٶ󺸰� �� Stay 
            transform.LookAt(other.transform);
            playerEnter = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerEnter = false;
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            npcTalk();
        }
    }

    private void npcTalk()
    {
        if (!playerInput && !playerEnter)
        {
            return;
        }
        
        // �ݶ��̴��� ���Դٸ� �ܺ��Լ� ���� �� ���� Invoke
        onPlayerEntered.Invoke();
       

        // ĵ������ null �ϰ�� ��Ÿ���� ���������� ����ó���� �߻���
        if (canvas == null)
        {
            return;
        }

        // SetActive�� ĵ������ �ڽ��� �гη� ã�ƾ� �����
        Transform transform = canvas.transform;
        GameObject panel = transform.Find("Panel").gameObject;

        if (panel == null)
        {
            return;
        }

        panel.SetActive(true);

    }

    
}
