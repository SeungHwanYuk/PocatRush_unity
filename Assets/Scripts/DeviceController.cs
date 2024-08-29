using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceController : MonoBehaviour
{
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
        inputKm = 10;
        inputKg = 5;
        inputMin = 60;
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
    }
    public void kgUpdate(int kg)
    {
        inputKg = kg;
    }
    public void minUpdate(int min)
    {
        inputMin = min;
    }

    public int getKg()
    {
        return inputKg;
    }
}
