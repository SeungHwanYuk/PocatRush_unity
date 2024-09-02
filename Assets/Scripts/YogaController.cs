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
        // stringŸ���� �ؽ�Ʈ�� �޾� int�� ��ȯ
        string temp = getMinTextFromManager.text;

        min = int.Parse(temp);
        exp = min;
        resultExpText.text = "[ " + min.ToString() + " min]��ŭ�� " + exp + " ����ġ ȹ�� !";
    }

    public void startYoga()
    {
        // ��� 0�� ��� UI�߰� ���
        if (min <= 0)
        {
            print("��� �Ͻð� ���ž���");
            return;
        }
        print("�䰡 ���X!");
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        gameManager.GetComponent<DeviceController>().minUpdate(0);
        print("����ġ ȹ�� �Ϸ�");
        onTrainingFinished.Invoke();
#endif
    }



}


