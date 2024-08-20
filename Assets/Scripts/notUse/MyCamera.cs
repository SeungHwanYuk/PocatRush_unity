using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public Transform target;//Player

    [SerializeField]
    private float rotSensitive = 3f;//카메라 회전 감도

    
    

    [SerializeField]
    private float dis = 5f;//카메라와 플레이어사이의 거리
    private float RotationMin = -2f;//카메라 회전각도 최소
    private float RotationMax = 80f;//카메라 회전각도 최대
    private float smoothTime = 0.12f;//카메라가 회전하는데 걸리는 시간

 

    private Vector3 targetRotation;
    private Vector3 currentVel;
   


    void LateUpdate()//Player가 움직이고 그 후 카메라가 따라가야 하므로 LateUpdate
    {
        Yaxis = Yaxis + Input.GetAxis("Mouse X") * rotSensitive;//마우스 좌우움직임을 입력받아서 카메라의 Y축을 회전시킨다
        Xaxis = Xaxis - Input.GetAxis("Mouse Y") * rotSensitive;//마우스 상하움직임을 입력받아서 카메라의 X축을 회전시킨다
        //Xaxis는 마우스를 아래로 했을때(음수값이 입력 받아질때) 값이 더해져야 카메라가 아래로 회전한다 

        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);
        //X축회전이 한계치를 넘지않게 제한해준다.

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);

            
        
        
            this.transform.eulerAngles = targetRotation;
            //SmoothDamp를 통해 부드러운 카메라 회전

         

           
       
        transform.position = new Vector3( target.position.x, target.position.y +1, target.position.z) - transform.forward * dis;
        //카메라의 위치는 플레이어보다 설정한 값만큼 떨어져있게 계속 변경된다.
            
    }
}