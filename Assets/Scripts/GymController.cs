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

    // 키 입력 boolean
    private bool playerInput;
    private bool playerEnter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("플레이어 진입");
            playerEnter = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("플레이어 벗어남");
            playerEnter = false;

            // 벗어나면 운동하기 UI 감춤
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
        print("진행시켜!!");
        panel.SetActive(true);
    }

    public void trainingEnd()
    {
        print("운동 끝! 패널 닫는다");
        panel.SetActive(false);
    }
}
