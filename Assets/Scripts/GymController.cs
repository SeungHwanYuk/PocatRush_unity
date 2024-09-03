using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GymController : MonoBehaviour
{
    // Event 호출 
    // 콜라이더와 플레이어가 닿았을 시 변수 정의
    public UnityEvent onPlayerEntered;


    // F버튼 보이기 추가 필요
    public GameObject pressFButtonPanel;

    // 운동하기 UI
    public GameObject panel;
    public GameObject hpZeroPanel;

    // 운동완료 UI
    public GameObject expPanel;
    public int exp;

    public GameObject playerHp;
    private string playerHpText;



    // 키 입력 boolean
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

            // 벗어나면 운동하기 UI 감춤
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
        expPanel.GetComponentInChildren<Text>().text = exp.ToString() + "의 경험치 획득!";
        expPanel.SetActive(true);
    }
   
}
