using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] //인스펙터에서만 참조 가능하게
    private float smoothRotationTime = 0.2f; //target 각도로 회전하는데 걸리는 시간
    [SerializeField]
    private float smoothMoveTime = 0.2f; //target 속도로 바뀌는데 걸리는 시간
    [SerializeField]
    private float moveSpeed = 4f; //움직이는 속도
    private float rotationVelocity;
    private float speedVelocity;
    private float currentSpeed;
    private float targetSpeed;

    private Transform cameraTransform;

    // 애니메이션 호출
    public GameObject player;
    public GameObject userPanel;  // 체력 확인용
    public GameObject animeBenchPressBarObject;  // 애니메이션에 포함된 오브젝트
    Animator animator;

    private string standingAnimeCase1 = "PlayerStandingIdle";
    private string standingAnimeCase2 = "PlayerStanding1";
    private string standingAnimeCase3 = "PlayerStanding2";
    private string standingAnime;
    private string talkingAnime = "PlayerTalking";
    private string jumpAnime = "PlayerJump";
    private string runAnime = "PlayerRun";
    private string sittingAnime = "PlayerSitting";
    private string standUpAnime = "PlayerStandUp";
    private string fastRunAnime = "PlayerFastRun";
    private string bicicleAnime = "PlayerBicicle";
    private string benchPressAnime = "PlayerBenchPress";
    private string yogaAnime1 = "PlayerYoga1";
    private string yogaAnime2 = "PlayerYoga2";
    private string drunkAnime = "PlayerDrunk";

    private float idleChangeTime = 0.0f;
    private bool playerBusy = false; 

    string nowAnime = "";
    string oldAnime = "";


    // 착지 판정
    bool onGround = false;
    public LayerMask groundLayer;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        animator = player.GetComponent<Animator>();
        animeBenchPressBarObject.SetActive(false);
    }


    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //GetAxisRaw("Horizontal") :오른쪽 방향키누르면 1을 반환, 아무것도 안누르면 0, 왼쪽방향키는 -1 반환
        //GetAxis("Horizontal"):-1과 1 사이의 실수값을 반환
        //Vertical은 위쪽방향키 누를시 1,아무것도 안누르면 0, 아래쪽방향키는 -1 반환

        Vector2 inputDir = input.normalized;
        //벡터 정규화. 만약 input=new Vector2(1,1) 이면 오른쪽위 대각선으로 움직인다.
        //방향을 찾아준다


        if (inputDir != Vector2.zero)//움직임을 멈췄을 때 다시 처음 각도로 돌아가는걸 막기위함
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg+cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref rotationVelocity, smoothRotationTime);
            
        }
        //각도를 구해주는 코드, 플레이어가 오른쪽 위 대각선으로 움직일시 그 방향을 바라보게 해준다
        //Mathf.Atan2는 라디안을 return하기에 다시 각도로 바꿔주는 Mathf.Rad2Deg를 곱해준다
        //Vector.up은 y axis를 의미한다
        //SmoothDampAngle을 이용해서 부드럽게 플레이어의 각도를 바꿔준다.

        targetSpeed = moveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedVelocity, smoothMoveTime);
        //현재스피드에서 타겟스피드까지 smoothMoveTime 동안 변한다
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        // 착지 판정
        onGround = Physics.Linecast(transform.position,
                                       transform.position - (transform.up * 0.7f),
                                       groundLayer);
      
        if (onGround)
        {
            if (currentSpeed < 1f)
            {
                
                if(idleChangeTime >= 7.0f && idleChangeTime >= 0.0f && playerBusy == false)
                {
                    standingAnime = standingAnimeCase1;
                    int random = Random.Range(0,2);
                    if(random == 0)
                    {

                        standingAnime = standingAnimeCase2;
                        idleChangeTime = -12.0f;
                    } else if(random == 1)
                    {

                        standingAnime = standingAnimeCase3;
                        idleChangeTime = -12.0f;
                    }

                }
                nowAnime = standingAnime;          
            } else
            {
                if(int.Parse(userPanel.GetComponent<GameManager>().hpText.text) <= 3)
                {
                    moveSpeed = 2f;
                    nowAnime = drunkAnime;
                } else
                {
                    moveSpeed = 4f;
                    nowAnime = runAnime;
                }
            }
        }
        else
        {
            nowAnime = jumpAnime;
        }

        // 가만히 있는 시간 계산
        if (nowAnime == standingAnime)
        {
            idleChangeTime = idleChangeTime + Time.deltaTime; 
        if (Input.GetMouseButtonDown(0))
        {
                playerBusy = true;
        }
        }
    }

    private void FixedUpdate()
    {
        if(currentSpeed > 0.1f)
        {
            idleChangeTime = 0.0f;
            standingAnime = "PlayerStandingIdle";
            playerBusy = false;
            animeBenchPressBarObject.SetActive(false);
        }
            if (nowAnime != oldAnime)
            {
            

                oldAnime = nowAnime;
                animator.Play(nowAnime);  // 애니메이션 재생
                                          // 매 프레임마다 시작 이미지부터 보여주면 안되므로
                                          // 애니메이션이 같지 않을때만 실행됨
            }
        
    }

    public void SetMoveSpeed(float speed)
    {
        // event 외부 호출 전용
        
        moveSpeed = speed;
    }

    public void playTalkingAnime()
    {
        animator.Play(talkingAnime);
        playerBusy = true;
    }
    public void playSittingAnime()
    {   
        animator.Play(sittingAnime);
        moveSpeed = 0;
        playerBusy = true;
    }

    public void playStandUpAnime()
    {
        animator.Play(standUpAnime);
        Invoke("standUpDelayTime", 2.0f);
        playerBusy = true;
    }

    public void standUpDelayTime()
    {
        moveSpeed = 4;
    }

    public void playFastRunAnime()
    {
        playerBusy = true;
        animator.Play(fastRunAnime);
    }
    public void playBicicleAnime()
    {
        playerBusy = true;
        animator.Play(bicicleAnime);
       
    }

    public void playBenchPressAnime()
    {
        playerBusy = true;
        animeBenchPressBarObject.SetActive(true);
        animator.Play(benchPressAnime);
    }

    public void playJumpAnime()
    {
        animator.Play(jumpAnime);
    }

    
    public void playYogaAnime()
    {
        playerBusy = true;
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