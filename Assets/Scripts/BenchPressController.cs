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

    public GameObject doTrainingPanel;
    public UnityEvent onTrainingFinished;


    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        // stringŸ���� �ؽ�Ʈ�� �޾� int�� ��ȯ
        string temp = getKgTextFromManager.text;
      
        kg = int.Parse(temp);
        exp = kg * 2;
        resultExpText.text = "[ " + kg.ToString() + " kg]��ŭ�� " + exp + " ����ġ ȹ�氡�� !";
    }

    public void isObject(GameObject obj)
    {
        gymController = obj;
    }
    public void doTrainingPanelClose()
    {
        doTrainingPanel.SetActive(false);
    }

    public void startBenchPress()
    {
        // ��� 0�� ��� UI�߰� ���
        if(kg <= 0)
        {
            
            doTrainingPanel.SetActive(true);
            Invoke("doTrainingPanelClose", 2.0f);
            return;
        }
        print("��ġ ������ ���X! , " + "����ġ : " + exp);

        if (gymController.tag == "BenchPress")
        {
        gymController.GetComponent<GymController>().benchPressAnimeStart();
        }
        gymController.GetComponent<GymController>().exp = exp;
        gymController.GetComponent<GymController>().trainingEnd();
        gameManager.GetComponent<DeviceController>().kgUpdate(0);
       
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        print("����ġ ȹ�� �Ϸ�");
#endif
        onTrainingFinished.Invoke();
    }



}
