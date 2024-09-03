using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class RunningController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CharExpUpdateExtern(int exp);

    public int km;
    public int exp;
    public Text resultExpText;
    public Text getKmTextFromManager;

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
        string temp = getKmTextFromManager.text;
       
        km = int.Parse(temp);
        exp = km * 3;
        resultExpText.text = "[ " + km.ToString() + " km]만큼의 " + exp + " 경험치 획득 !";
    }

    public void startRunning()
    {
        // 운동량 0인 경우 UI추가 요망
        if (km <= 0)
        {
            print("운동을 하시고 오셔야죠");
            return;
        }

       
        print("러닝 으쌰!");
        gymController.GetComponent<GymController>().exp = exp;
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        gameManager.GetComponent<DeviceController>().kmUpdate(0);
        print("경험치 획득 완료");
        onTrainingFinished.Invoke();
#endif
    }



}

