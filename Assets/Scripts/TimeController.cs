using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Light mainLight;
    public GameObject poleLights;
    public Material daySky;
    public Material nightSky;
    public GameObject winky;

    // ¹Ù²ñ
    public Sprite daySprite;
    public Sprite nightSprite;
    public Sprite daySunny;
    public Sprite nightMooney;

    // ²¯´Ù Å´
    public GameObject dayClouds;
    public GameObject nightClouds;

    // ¿Å±è
    

    public GameObject sunUiObject;
    public GameObject moonUiObject;
    
    private Vector3 sunUiObjectPoint;
    private Vector3 moonUiObjectPoint;





    // Start is called before the first frame update
    void Start()
    {
        /*poleLights = GameObject.FindGameObjectWithTag("PoleLight");*/
        winky.SetActive(false);
        nightClouds.SetActive(false);
        moonUiObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
       
    }



    public void SetDayTime()
    {
        if(mainLight.enabled == true)
        {
            // UI

            gameObject.GetComponent<Image>().sprite = nightSprite;
           /* sunUiObject.GetComponent<RawImage>().texture = nightMooney.texture;*/
            nightClouds.SetActive(true);
            dayClouds.SetActive(false);
            sunUiObject.SetActive(false);
            moonUiObject.SetActive(true);





        mainLight.enabled = false;
            if (winky)
            {
            winky.SetActive(true);

            }
        poleLights.SetActive(true);
            RenderSettings.skybox = nightSky;
            RenderSettings.ambientLight = new Color32(109, 134, 213, 0);
            
        

        } else if (mainLight.enabled == false)
        {
            // UI
            gameObject.GetComponent<Image>().sprite = daySprite;
            /*sunUiObject.GetComponent<RawImage>().texture = daySunny.texture;*/
            nightClouds.SetActive(false);
            dayClouds.SetActive(true);
            sunUiObject.SetActive(true);
            moonUiObject.SetActive(false);

            mainLight.enabled = true;
            if (winky)
            {
                winky.SetActive(false);
            }
            poleLights.SetActive(false);
            RenderSettings.skybox = daySky;
            RenderSettings.ambientLight = new Color32(255, 255, 255, 0);
        }
    }
}
