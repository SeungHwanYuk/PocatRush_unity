using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public Light mainLight;
    public GameObject poleLights;
    public Material daySky;
    public Material nightSky;

    

    // Start is called before the first frame update
    void Start()
    {
        /*poleLights = GameObject.FindGameObjectWithTag("PoleLight");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDayTime()
    {
        if(mainLight.enabled == true)
        {
        mainLight.enabled = false;
        poleLights.SetActive(true);
            RenderSettings.skybox = nightSky;
            RenderSettings.ambientLight = new Color32(109, 134, 213, 0);
            
        

        } else if (mainLight.enabled == false)
        {
            mainLight.enabled = true;
            poleLights.SetActive(false);
            RenderSettings.skybox = daySky;
            RenderSettings.ambientLight = new Color32(255, 255, 255, 0);
        }
    }
}
