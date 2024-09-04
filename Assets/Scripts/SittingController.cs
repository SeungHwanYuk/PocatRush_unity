using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingController : MonoBehaviour
{

    // 키 입력 boolean
    private bool playerInput;
    private bool playerEnter;

    public GameObject player;
   

    // 상호작용시 플레이어가 이동할 자리
    private Vector3 sitPosition;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        sitPosition = new Vector3(this.transform.position.x + 0.53f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerEnter && Input.GetKeyDown(KeyCode.F))
        {
            sit();
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
            playerEnter = false;
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }

    }

    public void sit()
    {
        print(" 앉아! ");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        player.GetComponent<Transform>().transform.SetPositionAndRotation(sitPosition, gameObject.transform.rotation);
        player.GetComponent<MyPlayer>().Invoke("playSittingAnime", 0.5f);
    }
}
