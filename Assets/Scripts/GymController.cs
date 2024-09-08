using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GymController : MonoBehaviour
{
    // Event ȣ�� 
    // �ݶ��̴��� �÷��̾ ����� �� ���� ����
    public UnityEvent onPlayerEntered;
    public GameObject player;

    // F��ư ���̱� �߰� �ʿ�
    public GameObject pressFButtonPanel;

    // ��ϱ� UI
    public GameObject panel;
    public GameObject hpZeroPanel;

    // ��Ϸ� UI
    public GameObject expPanel;
    public Text expText;

    public int exp;
    public GameObject playerHp;
    private string playerHpText;

    // ��ȣ�ۿ� �ִϸ��̼� ����Ʈ��ġ
    private GameObject treadmill;
    private GameObject bicicle;
    private GameObject yogaMat;
    private Vector3 fastRunAnimePoint;
    private Vector3 bicicleAnimePoint;
    private Vector3 yogaAnimePoint;
    private Quaternion yogaAnimeRotation;

    // ����(�ε巴�� ��ǥ���� �̵�)�� ���� ��/���� boolean
    private bool yogaIsActive;
    private bool treadMillIsActive;
    private bool bicicleIsActive;

    // Ű �Է� boolean
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

            // ����� ��ϱ� UI ����
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
        expText.text = exp.ToString() + "�� ����ġ ȹ��!";
    }
   

    // �ִϸ��̼� ó�� �޼ҵ�
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
