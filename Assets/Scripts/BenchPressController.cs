using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class BenchPressController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CharExpUpdateExtern(int exp);

    public int kg;
    public int exp;
    public Text showKgText;
    public Text getKgText;

    public GameObject gameManager;
    public UnityEvent onTrainingFinished;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // string타입의 텍스트를 받아 int로 전환
        string temp = getKgText.text;
        print(temp);
        kg = int.Parse(temp);
        exp = kg * 2;
        showKgText.text = "[ " + kg.ToString() + " kg]만큼의 " + exp + " 경험치 획득 !";
    }
    
    public void startBenchPress()
    {
        print("벤치 프레스 으쌰!");
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        gameManager.GetComponent<DeviceController>().kgUpdate(0);
        print("경험치 획득 완료");
        onTrainingFinished.Invoke();
#endif
    }



}
