using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class WatchController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void WatchActiveExtern(bool isActive);

    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WatchActive() {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        if (isActive == false)
        {

            WatchActiveExtern(true);
            print("�ð� ���Ͷ�");
            isActive = true;


        } else if (isActive == true)
        {
            WatchActiveExtern(false);
            print("�ð� ���ܶ�");
            isActive = false;
        }
#endif
    }
}
