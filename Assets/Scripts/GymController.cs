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
    public GameObject player;

    // F버튼 보이기 추가 필요
    public GameObject pressFButtonPanel;

    // 운동하기 UI
    public GameObject panel;
    public GameObject hpZeroPanel;

    // 운동완료 UI
    public GameObject expPanel;
    public Text expText;

    public int exp;
    public GameObject playerHp;
    private string playerHpText;

    // 상호작용 애니메이션 포인트위치
    private GameObject treadmill;
    private GameObject bicicle;
    private GameObject yogaMat;
    private Vector3 fastRunAnimePoint;
    private Vector3 bicicleAnimePoint;
    private Vector3 yogaAnimePoint;
    private Quaternion yogaAnimeRotation;

    // 러프(부드럽게 목표까지 이동)을 위한 온/오프 boolean
    private bool yogaIsActive;
    private bool treadMillIsActive;
    private bool bicicleIsActive;

    // 키 입력 boolean
    private bool playerInput;
    private bool playerEnter;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHp = GameObject.FindGameObjectWithTag("PlayerHp");
        panel.SetActive(false);
        expPanel.SetActive(false);
        hpZeroPanel.SetActive(false);
    }

       
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            playerEnter = true;
          
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           
            playerEnter = false;

            // 벗어나면 운동하기 UI 감춤
            panel.SetActive(false);
        }

    }
    private void Update()
    {
        playerHpText = playerHp.GetComponent<Text>().text;
        if (Input.GetKeyDown(KeyCode.F) && playerEnter)
        {
            if(int.Parse(playerHpText) <= 0)
            {
                hpZeroPanel.SetActive(true);
                return;
            } else
            {

            askTraining();

            if (gameObject.tag == "TreadMill")
            {
            treadmill = gameObject;
            fastRunAnimePoint = new Vector3(treadmill.transform.position.x - 0.45f, treadmill.transform.position.y + 0.6f, treadmill.transform.position.z+0.7f);
            } 
                else if (gameObject.tag == "Bicicle")
                {
                bicicle = gameObject;
                bicicleAnimePoint = new Vector3(bicicle.transform.position.x, bicicle.transform.position.y + 0.5f, bicicle.transform.position.z-0.3f);
                } 
                    else if(gameObject.tag == "YogaMat")
                    {
                    yogaMat = gameObject;
                    yogaAnimePoint =  new Vector3(yogaMat.transform.position.x +0.9f, yogaMat.transform.position.y + 0.5f, yogaMat.transform.position.z+0.5f);
                    yogaAnimeRotation = new Quaternion(yogaMat.transform.rotation.x, yogaMat.transform.rotation.y + -1, yogaMat.transform.rotation.z, yogaMat.transform.rotation.w);
                    }

            }
        }
    }

    private void FixedUpdate()
    {

        if(treadMillIsActive == true)
        {
        player.transform.SetPositionAndRotation(
            Vector3.Lerp(player.transform.position, fastRunAnimePoint, Time.deltaTime), 
            Quaternion.Lerp(player.transform.rotation, treadmill.transform.rotation, Time.deltaTime *2));

        } else if(bicicleIsActive == true)
        {

        player.transform.SetPositionAndRotation(
            bicicleAnimePoint, 
            Quaternion.Lerp(player.transform.rotation, bicicle.transform.rotation,Time.deltaTime *2));
        } else if(yogaIsActive == true)
        {
        player.transform.SetPositionAndRotation(
            Vector3.Lerp(player.transform.position, yogaAnimePoint, Time.deltaTime) ,
            Quaternion.Lerp(player.transform.rotation, yogaAnimeRotation,Time.deltaTime *2));
        }

        if(Input.anyKeyDown && !Input.GetMouseButtonDown(1))
        {
            treadMillIsActive = false;
            bicicleIsActive = false;
            yogaIsActive = false;
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
        
        panel.SetActive(true);
        panel.BroadcastMessage("isObject", gameObject);
    }
    public void trainingEnd()
    {
        
        panel.SetActive(false);
        expPanel.SetActive(true);
        expText =  expPanel.GetComponentInChildren<Text>();
        expText.text = exp.ToString() + "의 경험치 획득!";
    }
   

    // 애니메이션 처리 메소드
    public void fastRunAnimeStart()
    {
        player.GetComponent<MyPlayer>().playFastRunAnime();

        treadMillIsActive = true;
    }

    public void bicicleAnimeStart()
    {

        player.GetComponent<MyPlayer>().playJumpAnime();
        player.GetComponent<MyPlayer>().Invoke("playBicicleAnime", 1.0f);

        bicicleIsActive = true;
    }
    public void yogaAnimeStart()
    {

        player.GetComponent<MyPlayer>().Invoke("playYogaAnime", 1.0f);
        yogaIsActive = true;
 
    }
}
