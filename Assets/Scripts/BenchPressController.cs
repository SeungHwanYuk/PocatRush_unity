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
    public Text resultExpText;
    public Text getKgTextFromManager;

    public GameObject gameManager;
    public GameObject gymController;
    public UnityEvent onTrainingFinished;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // string타입의 텍스트를 받아 int로 전환
        string temp = getKgTextFromManager.text;
      
        kg = int.Parse(temp);
        exp = kg * 2;
        resultExpText.text = "[ " + kg.ToString() + " kg]만큼의 " + exp + " 경험치 획득가능 !";
    }

    public void isObject(GameObject obj)
    {
        gymController = obj;
    }

    public void startBenchPress()
    {
        // 운동량 0인 경우 UI추가 요망
        if(kg <= 0)
        {
            print("운동을 하시고 오셔야죠");
            return;
        }
        print("벤치 프레스 으쌰! , " + "경험치 : " + exp);
        gymController.GetComponent<GymController>().exp = exp;
        gymController.GetComponent<GymController>().trainingEnd();
        gameManager.GetComponent<DeviceController>().kgUpdate(0);
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        print("경험치 획득 완료");
        onTrainingFinished.Invoke();
#endif
    }



}
