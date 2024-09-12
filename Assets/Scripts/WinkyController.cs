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
        // "Roof" 레이어를 제외한 모든 레이어를 포함하는 마스크 생성
        layerMask = ~(1 << LayerMask.NameToLayer("Roof"));
        particle.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;

            // WebGL에서 마우스 Y 좌표 반전
            mousePos.y = Screen.height - mousePos.y;


            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 레이캐스트를 실행하여 오브젝트 감지
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
        print("윙키 찾았당!");
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
