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
            // SetActive�� ����� �ݶ��̴��� �Բ� ������ �����Ƿ� �簨�� �Ұ���!
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
            print("��Ҵ�");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isHiddenWhenOn = false;
            print("�����");
        }
    }




}
