using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingController : MonoBehaviour
{

    // 키 입력 boolean
    private bool playerInput;
    private bool playerEnter;

    public GameObject player;
    public GameObject thisObject;


    // 상호작용시 플레이어가 이동할 자리
    private Vector3 sitPosition;

    private bool sitIsActive;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        sitPosition = new Vector3(gameObject.transform.position.x + 0.53f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerEnter && Input.GetKeyDown(KeyCode.F))
        {
            sit();
        }
    }
    private void FixedUpdate()
    {
        if(sitIsActive == true)
        {
        player.transform.SetPositionAndRotation(
            Vector3.Lerp(player.transform.position, sitPosition, Time.deltaTime),
            Quaternion.Lerp(player.transform.rotation, gameObject.transform.rotation,Time.deltaTime *2));

            if (Input.anyKeyDown && !Input.GetMouseButtonDown(1))
            {
                player.GetComponent<MyPlayer>().playStandUpAnime();
                sitIsActive = false;
            }
        }
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
            gameObject.GetComponent<BoxCollider>().enabled = true;
            playerEnter = false;
        }

    }

    public void isObject(GameObject obj)
    {
        thisObject = obj;
    }

    public void sit()
    {
        print(" 앉아! ");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        sitIsActive = true;
        player.GetComponent<MyPlayer>().Invoke("playSittingAnime", 0.5f);
    }
}
