using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    // Event 호출 
    // 콜라이더와 플레이어가 닿았을 시 변수 정의
    public UnityEvent onPlayerEntered;

    public GameObject canvas;

    // 키 입력 boolean
    private bool playerInput;
    private bool playerEnter;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            // 계속 바라보게 함 Stay 
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
        
        // 콜라이더에 들어왔다면 외부함수 정의 후 실행 Invoke
        onPlayerEntered.Invoke();
       

        // 캔버스는 null 일경우 런타임은 유지되지만 예외처리가 발생함
        if (canvas == null)
        {
            return;
        }

        // SetActive는 캔버스의 자식인 패널로 찾아야 적용됨
        Transform transform = canvas.transform;
        GameObject panel = transform.Find("Panel").gameObject;

        if (panel == null)
        {
            return;
        }

        panel.SetActive(true);

    }

    
}
