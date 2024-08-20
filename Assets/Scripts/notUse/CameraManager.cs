using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    

    // Player
    public Transform target;

    // 위치
    public float positionY = 4f;
    public float positionZ = 4f;

    // 각도
    public float angleX = 0.0f;
    public float angleY = 0.0f;
    public float angleZ = 0.0f;

    // 마우스 위치
    public float Yaxis;
    public float Xaxis;

    public float dis = 2f;//카메라와 플레이어사이의 거리
    private float rotSensitive = 3f;//카메라 회전 감도
    private float RotationMin = -10f;//카메라 회전각도 최소
    private float RotationMax = 80f;//카메라 회전각도 최대
    private float smoothTime = 0.12f;//카메라가 회전하는데 걸리는 시간
    //위 5개의 value는 개발자의 취향껏 알아서 설정해주자
    private Vector3 targetRotation;
    private Vector3 currentVel;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            
          
            {
                //플레이어의 위치와 연동
                transform.position = new Vector3(player.transform.position.x ,
                                                 player.transform.position.y + positionY, player.transform.position.z- positionZ);
  
            }
        }
    }

    void FixedUpdate()
    {
        
        /*transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);*/
    }

    void LateUpdate()//Player가 움직이고 그 후 카메라가 따라가야 하므로 LateUpdate
    {
        Yaxis = Yaxis + Input.GetAxis("Mouse X") * rotSensitive;//마우스 좌우움직임을 입력받아서 카메라의 Y축을 회전시킨다
        Xaxis = Xaxis - Input.GetAxis("Mouse Y") * rotSensitive;//마우스 상하움직임을 입력받아서 카메라의 X축을 회전시킨다
        //Xaxis는 마우스를 아래로 했을때(음수값이 입력 받아질때) 값이 더해져야 카메라가 아래로 회전한다 

        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);
        //X축회전이 한계치를 넘지않게 제한해준다.

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);
        this.transform.eulerAngles = targetRotation;

        transform.position = target.position - transform.forward * dis;
    }

    }
