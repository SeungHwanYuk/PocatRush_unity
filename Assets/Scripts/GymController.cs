using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GymController : MonoBehaviour
{
    // Event ȣ�� 
    // �ݶ��̴��� �÷��̾ ����� �� ���� ����
    public UnityEvent onPlayerEntered;


    // F��ư ���̱� �߰� �ʿ�
    public GameObject pressFButtonPanel;

    // ��ϱ� UI
    public GameObject panel;

    // Ű �Է� boolean
    private bool playerInput;
    private bool playerEnter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("�÷��̾� ����");
            playerEnter = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("�÷��̾� ���");
            playerEnter = false;

            // ����� ��ϱ� UI ����
            panel.SetActive(false);
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            askTraining();
        }
    }

    private void askTraining()
    {

        if (!playerInput && !playerEnter)
        {
            return;
        }
        onPlayerEntered.Invoke();

        if (panel == null)
        {
            return;
        }

        
    }

    public void trainingStart()
    {
        print("�������!!");
        panel.SetActive(true);
    }

    public void trainingEnd()
    {
        print("� ��! �г� �ݴ´�");
        panel.SetActive(false);
    }
}
