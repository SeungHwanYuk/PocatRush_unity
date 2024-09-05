using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] //�ν����Ϳ����� ���� �����ϰ�
    private float smoothRotationTime = 0.2f; //target ������ ȸ���ϴµ� �ɸ��� �ð�
    [SerializeField]
    private float smoothMoveTime = 0.2f; //target �ӵ��� �ٲ�µ� �ɸ��� �ð�
    [SerializeField]
    private float moveSpeed = 4f; //�����̴� �ӵ�
    private float rotationVelocity;
    private float speedVelocity;
    private float currentSpeed;
    private float targetSpeed;

    private Transform cameraTransform;

    // �ִϸ��̼� ȣ��
    public GameObject player;
    public GameObject userPanel;  // ü�� Ȯ�ο�
    Animator animator;

    private string standingAnime1 = "PlayerStandingIdle";
    private string standingAnime2 = "PlayerStanding1";
    private string standingAnime3 = "PlayerStanding2";
    private string talkingAnime = "PlayerTalking";
    private string jumpAnime = "PlayerJump";
    private string runAnime = "PlayerRun";
    private string sittingAnime = "PlayerSitting";
    private string standUpAnime = "PlayerStandUp";
    private string fastRunAnime = "PlayerFastRun";
    private string bicicleAnime = "PlayerBicicle";
    private string yogaAnime1 = "PlayerYoga1";
    private string yogaAnime2 = "PlayerYoga2";
    private string drunkAnime = "PlayerDrunk";

    string nowAnime = "";
    string oldAnime = "";

    // ���� ����
    bool onGround = false;
    public LayerMask groundLayer;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        animator = player.GetComponent<Animator>();
    }


    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //GetAxisRaw("Horizontal") :������ ����Ű������ 1�� ��ȯ, �ƹ��͵� �ȴ����� 0, ���ʹ���Ű�� -1 ��ȯ
        //GetAxis("Horizontal"):-1�� 1 ������ �Ǽ����� ��ȯ
        //Vertical�� ���ʹ���Ű ������ 1,�ƹ��͵� �ȴ����� 0, �Ʒ��ʹ���Ű�� -1 ��ȯ

        Vector2 inputDir = input.normalized;
        //���� ����ȭ. ���� input=new Vector2(1,1) �̸� �������� �밢������ �����δ�.
        //������ ã���ش�


        if (inputDir != Vector2.zero)//�������� ������ �� �ٽ� ó�� ������ ���ư��°� ��������
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg+cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref rotationVelocity, smoothRotationTime);
            
        }
        //������ �����ִ� �ڵ�, �÷��̾ ������ �� �밢������ �����Ͻ� �� ������ �ٶ󺸰� ���ش�
        //Mathf.Atan2�� ������ return�ϱ⿡ �ٽ� ������ �ٲ��ִ� Mathf.Rad2Deg�� �����ش�
        //Vector.up�� y axis�� �ǹ��Ѵ�
        //SmoothDampAngle�� �̿��ؼ� �ε巴�� �÷��̾��� ������ �ٲ��ش�.

        targetSpeed = moveSpeed * inputDir.magnitude;

        
 
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, smoothMoveTime);
        //���罺�ǵ忡�� Ÿ�ٽ��ǵ���� smoothMoveTime ���� ���Ѵ�
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        onGround = Physics.Linecast(transform.position,
                                       transform.position - (transform.up * 0.7f),
                                       groundLayer);
        if (onGround)
        {
            if (currentSpeed < 1f)
            {
                
                nowAnime = standingAnime1;
               
            } else
            {
                if(int.Parse(userPanel.GetComponent<GameManager>().hpText.text) <= 3)
                {
                    moveSpeed = 2f;
                    nowAnime = drunkAnime;
                } else
                {

                nowAnime = runAnime;
                }
            }
        }
        else
        {
            nowAnime = jumpAnime;
        }
    }

    private void FixedUpdate()
    {

            if (nowAnime != oldAnime)
            {

                oldAnime = nowAnime;
                animator.Play(nowAnime);  // �ִϸ��̼� ���
                                          // �� �����Ӹ��� ���� �̹������� �����ָ� �ȵǹǷ�
                                          // �ִϸ��̼��� ���� �������� �����
            }
        
    }

    public void SetMoveSpeed(float speed)
    {
        // event �ܺ� ȣ�� ����
        
        moveSpeed = speed;
    }

    public void playTalkingAnime()
    {
        animator.Play(talkingAnime);
    }
    public void playSittingAnime()
    {   
        animator.Play(sittingAnime);
        moveSpeed = 0;
    }

    public void playStandUpAnime()
    {
        animator.Play(standUpAnime);
        Invoke("standUpDelayTime", 2.0f);
    }

    public void standUpDelayTime()
    {
        moveSpeed = 4;
    }

    public void playFastRunAnime()
    {
        animator.Play(fastRunAnime);
    }
    public void playBicicleAnime()
    {
        animator.Play(bicicleAnime);
    }
    public void playYogaAnime()
    {
        int random = Random.Range(0,2);
        print(random);
        if(random == 1)
        {
        animator.Play(yogaAnime1);

        } else
        {
        animator.Play(yogaAnime2);
        }
    }

}