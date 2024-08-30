using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class DeviceController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void kmResetExtern(int km);
    [DllImport("__Internal")]
    private static extern void kgResetExtern(int kg);
    [DllImport("__Internal")]
    private static extern void minResetExtern(int min);


    public Text kmText;
    public Text kgText;
    public Text minText;

    public int inputKm;
    public int inputKg;
    public int inputMin;


    // 테스트 전용
    public int km;
    public int kg;
    public int min;

    // Start is called before the first frame update

    void Start()
    {
        // 디바이스에서 받았다고 가정

        inputKm = 0;
        inputKg = 0;
        inputMin = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        kmText.text =  inputKm.ToString();
        kgText.text = inputKg.ToString();
        minText.text = inputMin.ToString();
    }
    public void kmUpdate(int km)
    {
        inputKm = km;
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        kmResetExtern(km);
#endif

    }
    public void kgUpdate(int kg)
    {
        inputKg = kg;
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        kgResetExtern(kg);
#endif
    }
    public void minUpdate(int min)
    {
        inputMin = min;
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        minResetExtern(min);
#endif
    }

    public int getKg()
    {
        // ??
        return inputKg;
    }

    
}
