using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    

    // Player
    public Transform target;

    // ��ġ
    public float positionY = 4f;
    public float positionZ = 4f;

    // ����
    public float angleX = 0.0f;
    public float angleY = 0.0f;
    public float angleZ = 0.0f;

    // ���콺 ��ġ
    public float Yaxis;
    public float Xaxis;

    public float dis = 2f;//ī�޶�� �÷��̾������ �Ÿ�
    private float rotSensitive = 3f;//ī�޶� ȸ�� ����
    private float RotationMin = -10f;//ī�޶� ȸ������ �ּ�
    private float RotationMax = 80f;//ī�޶� ȸ������ �ִ�
    private float smoothTime = 0.12f;//ī�޶� ȸ���ϴµ� �ɸ��� �ð�
    //�� 5���� value�� �������� ���ⲯ �˾Ƽ� ����������
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
                //�÷��̾��� ��ġ�� ����
                transform.position = new Vector3(player.transform.position.x ,
                                                 player.transform.position.y + positionY, player.transform.position.z- positionZ);
  
            }
        }
    }

    void FixedUpdate()
    {
        
        /*transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);*/
    }

    void LateUpdate()//Player�� �����̰� �� �� ī�޶� ���󰡾� �ϹǷ� LateUpdate
    {
        Yaxis = Yaxis + Input.GetAxis("Mouse X") * rotSensitive;//���콺 �¿�������� �Է¹޾Ƽ� ī�޶��� Y���� ȸ����Ų��
        Xaxis = Xaxis - Input.GetAxis("Mouse Y") * rotSensitive;//���콺 ���Ͽ������� �Է¹޾Ƽ� ī�޶��� X���� ȸ����Ų��
        //Xaxis�� ���콺�� �Ʒ��� ������(�������� �Է� �޾�����) ���� �������� ī�޶� �Ʒ��� ȸ���Ѵ� 

        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);
        //X��ȸ���� �Ѱ�ġ�� �����ʰ� �������ش�.

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);
        this.transform.eulerAngles = targetRotation;

        transform.position = target.position - transform.forward * dis;
    }

    }
