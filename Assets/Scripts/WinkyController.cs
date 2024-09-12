using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class WinkyController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void WinkyFoundExtern();

    public Camera mainCamera;
    public LayerMask layerMask;
    private bool lightUp;

    public GameObject particle;
    public Light eventLight;
    

    public GameObject winkyPopUp;
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        // "Roof" ���̾ ������ ��� ���̾ �����ϴ� ����ũ ����
        layerMask = ~(1 << LayerMask.NameToLayer("Roof"));
        particle.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            // WebGL���� ���콺 Y ��ǥ ����
            mousePos.y = Screen.height - mousePos.y;


            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ����ĳ��Ʈ�� �����Ͽ� ������Ʈ ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {


               if(hit.transform.name == "Winky")
                {
                    Debug.Log("Hit object: " + hit.transform.name);
                    lightUp = true;
                    winkyFound();

                }
               
            }
            else
                {
                Debug.Log("No object hit or hit object is on the Roof layer");
            }
        }
        if(lightUp == true && eventLight.intensity <= 2f)
        {
            eventLight.intensity = eventLight.intensity + Time.deltaTime*0.5f;
        }
    }

    public void winkyFound()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        WinkyFoundExtern();
        print("��Ű ã�Ҵ�!");
#endif
        particle.SetActive(true);
        Invoke("DestroyWinky", 3.0f);
    }

    public void DestroyWinky()
    {
        winkyPopUp.SetActive(true);
        lightUp = false;
        Destroy(gameObject);
    }
}
