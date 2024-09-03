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
    public GameObject hpZeroPanel;

    // ��Ϸ� UI
    public GameObject expPanel;
    public int exp;

    public GameObject playerHp;
    private string playerHpText;



    // Ű �Է� boolean
    private bool playerInput;
    private bool playerEnter;

    private void Start()
    {
       
        playerHp = GameObject.FindGameObjectWithTag("PlayerHp");
        panel.SetActive(false);
        expPanel.SetActive(false);
        hpZeroPanel.SetActive(false);
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
        playerHpText = playerHp.GetComponent<Text>().text;
        if (Input.GetKeyDown(KeyCode.F) && playerEnter)
        {
            if(int.Parse(playerHpText) <= 0)
            {
                hpZeroPanel.SetActive(true);
                return;
            } else
            {

            askTraining();
            }
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
