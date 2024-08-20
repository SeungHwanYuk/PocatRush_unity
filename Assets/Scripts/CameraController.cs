using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //Player
    private new Transform transform;

   
    [SerializeField]
    private float dis = 5f; //ī�޶�� �÷��̾������ �Ÿ�

    private float mouseX;
    private float mouseY;
    public float rotateSpeed = 5.0f;
    public float moveSpeed = 3.5f;
    public float limitAngleMin = 15f; // ī�޶� ���� ���� �ּ�
    public float limitAngleMax = 75f; // ī�޶� ���� ���� �ִ�

    private bool isRotate;



    private void Start()
    {
        transform = GetComponent<Transform>();

        mouseX = transform.rotation.eulerAngles.y;  //���콺 ����(x)�� ������(y) �� �߽�
        mouseY = -transform.rotation.eulerAngles.x; //���콺 ����(y)�� ������(-x) �� �߽�
       
    }

    private void Update()
    {
    }

    private void LateUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //ī�޶� �������� ��, ������ �̵�
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement = movement.normalized * (Time.deltaTime * moveSpeed);
        transform.position += movement;

        //���콺 ������ Ŭ�� �� ȸ����Ŵ
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }

        if (isRotate)
        {
            Rotation();
        }

        transform.position = new Vector3(target.position.x, target.position.y + 1, target.position.z) - transform.forward * dis;
        //ī�޶��� ��ġ�� �÷��̾�� ������ ����ŭ �������ְ� ��� ����ȴ�.
    }


    public void Rotation()
    {
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed; // AxisX = Mouse Y
        mouseY = Mathf.Clamp(mouseY + Input.GetAxis("Mouse Y") * rotateSpeed, -limitAngleMax, limitAngleMin);
        

        //mouseX (���� ������) �� Y�࿡ ������ ��
        //mouseY (���� ������) �� X�࿡ ������ ��
        transform.rotation = Quaternion.Euler(transform.rotation.x - mouseY, transform.rotation.y + mouseX, 0.0f);
    }
}