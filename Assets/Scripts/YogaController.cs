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
        string temp = getMinTextFromManager.text;

        min = int.Parse(temp);
        exp = min;
        resultExpText.text = "[ " + min.ToString() + " min]��ŭ�� " + exp + " ����ġ ȹ�� !";
    }

    public void isObject(GameObject obj)
    {
        gymController = obj;
    }
    public void doTrainingPanelClose()
    {
        doTrainingPanel.SetActive(false);
    }

    public void startYoga()
    {
        // ��� 0�� ��� UI�߰� ���
        if (min <= 0)
        {
            
            doTrainingPanel.SetActive(true);
            Invoke("doTrainingPanelClose", 2.0f);
            return;
        }
        print("�䰡 ���X! , " + "����ġ : " + exp);

        
        gymController.GetComponent<GymController>().yogaAnimeStart();
        gymController.GetComponent<GymController>().exp = exp;
        gymController.GetComponent<GymController>().trainingEnd();
        gameManager.GetComponent<DeviceController>().minUpdate(0);
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        print("����ġ ȹ�� �Ϸ�");
#endif
        onTrainingFinished.Invoke();
    }



}


