using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class YogaController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CharExpUpdateExtern(int exp);

    public int min;
    public int exp;
    public Text resultExpText;
    public Text getMinTextFromManager;

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
        string temp = getMinTextFromManager.text;

        min = int.Parse(temp);
        exp = min;
        resultExpText.text = "[ " + min.ToString() + " min]만큼의 " + exp + " 경험치 획득 !";
    }

    public void startYoga()
    {
        // 운동량 0인 경우 UI추가 요망
        if (min <= 0)
        {
            print("운동을 하시고 오셔야죠");
            return;
        }
        print("요가 으쌰!");
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        gameManager.GetComponent<DeviceController>().minUpdate(0);
        print("경험치 획득 완료");
        onTrainingFinished.Invoke();
#endif
    }



}


