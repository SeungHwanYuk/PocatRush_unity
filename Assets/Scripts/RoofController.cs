using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofController : MonoBehaviour
{
    [SerializeField]
    private bool isHiddenWhenOn;
   

    // Start is called before the first frame update
    void Start()
    {
     isHiddenWhenOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(isHiddenWhenOn)
        {
            // SetActive로 만들면 콜라이더도 함께 영향을 받으므로 재감지 불가능!
            gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        }
        if(!isHiddenWhenOn)
        {
            gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        }
        
        
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHiddenWhenOn = true;
            print("닿았다");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHiddenWhenOn = false;
            print("떨어졋따");
        }
    }




}
