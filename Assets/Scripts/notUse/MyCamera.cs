using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public float Yaxis;
    public float Xaxis;
    public Transform target;//Player

    [SerializeField]
    private float rotSensitive = 3f;//ī�޶� ȸ�� ����

    
    

    [SerializeField]
    private float dis = 5f;//ī�޶�� �÷��̾������ �Ÿ�
    private float RotationMin = -2f;//ī�޶� ȸ������ �ּ�
    private float RotationMax = 80f;//ī�޶� ȸ������ �ִ�
    private float smoothTime = 0.12f;//ī�޶� ȸ���ϴµ� �ɸ��� �ð�

 

    private Vector3 targetRotation;
    private Vector3 currentVel;
   


    void LateUpdate()//Player�� �����̰� �� �� ī�޶� ���󰡾� �ϹǷ� LateUpdate
    {
        Yaxis = Yaxis + Input.GetAxis("Mouse X") * rotSensitive;//���콺 �¿�������� �Է¹޾Ƽ� ī�޶��� Y���� ȸ����Ų��
        Xaxis = Xaxis - Input.GetAxis("Mouse Y") * rotSensitive;//���콺 ���Ͽ������� �Է¹޾Ƽ� ī�޶��� X���� ȸ����Ų��
        //Xaxis�� ���콺�� �Ʒ��� ������(�������� �Է� �޾�����) ���� �������� ī�޶� �Ʒ��� ȸ���Ѵ� 

        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);
        //X��ȸ���� �Ѱ�ġ�� �����ʰ� �������ش�.

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);

            
        
        
            this.transform.eulerAngles = targetRotation;
            //SmoothDamp�� ���� �ε巯�� ī�޶� ȸ��

         

           
       
        transform.position = new Vector3( target.position.x, target.position.y +1, target.position.z) - transform.forward * dis;
        //ī�޶��� ��ġ�� �÷��̾�� ������ ����ŭ �������ְ� ��� ����ȴ�.
            
    }
}