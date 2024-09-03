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
        // stringŸ���� �ؽ�Ʈ�� �޾� int�� ��ȯ
        string temp = getKmTextFromManager.text;
       
        km = int.Parse(temp);
        exp = km * 3;
        resultExpText.text = "[ " + km.ToString() + " km]��ŭ�� " + exp + " ����ġ ȹ�� !";
    }

    public void startRunning()
    {
        // ��� 0�� ��� UI�߰� ���
        if (km <= 0)
        {
            print("��� �Ͻð� ���ž���");
            return;
        }

       
        print("���� ���X!");
        gymController.GetComponent<GymController>().exp = exp;
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        gameManager.GetComponent<DeviceController>().kmUpdate(0);
        print("����ġ ȹ�� �Ϸ�");
        onTrainingFinished.Invoke();
#endif
    }



}

