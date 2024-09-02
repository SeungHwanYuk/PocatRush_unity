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

    // ��Ϸ� UI
    public GameObject expPanel;
    public int exp;
    
    

    // Ű �Է� boolean
    private bool playerInput;
    private bool playerEnter;

    private void Start()
    {
         panel.SetActive(false);
         expPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            playerEnter = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           
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
        panel.SetActive(true);
    }

    public void trainingEnd()
    {
        
        panel.SetActive(false);
        expPanel.GetComponentInChildren<Text>().text = exp.ToString() + "�� ����ġ ȹ��!";
        expPanel.SetActive(true);
    }
   
}
