using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofController : MonoBehaviour
{
    [SerializeField]
    private bool isHiddenWhenOn;

    public GameObject lights;
   

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
            if(lights)
            {

            lights.SetActive(true);
            }
        }
        if(!isHiddenWhenOn)
        {
            gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            if(lights)
            {

            lights.SetActive(false);
            }
        }



    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHiddenWhenOn = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHiddenWhenOn = false;
            
        }
    }




}
