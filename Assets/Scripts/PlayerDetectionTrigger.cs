using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionTrigger : MonoBehaviour
{
    // 플레이어 범위 감지 전용 코드
    

    // 접촉을 유지한다면 실행 또한 유지 Stay
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            // 플레이어가 들어오면 계속해서 카메라를 바라본다
            transform.LookAt(Camera.main.transform);

            // TextMesh 보여주기
     GameObject textMesh = transform.Find("Fbutton").gameObject;
            textMesh.GetComponent<MeshRenderer>().enabled = true;
        }
        
    }

    // 플레이어와 떨어졌을 때 실행
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // TextMesh 숨기기
     GameObject textMesh = transform.Find("Fbutton").gameObject;
            textMesh.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
