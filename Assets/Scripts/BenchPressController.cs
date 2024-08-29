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
        // stringŸ���� �ؽ�Ʈ�� �޾� int�� ��ȯ
        string temp = getKgText.text;
        print(temp);
        kg = int.Parse(temp);
        exp = kg * 2;
        showKgText.text = "[ " + kg.ToString() + " kg]��ŭ�� " + exp + " ����ġ ȹ�� !";
    }
    
    public void startBenchPress()
    {
        print("��ġ ������ ���X!");
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CharExpUpdateExtern(exp);
        gameManager.GetComponent<DeviceController>().kgUpdate(0);
        print("����ġ ȹ�� �Ϸ�");
        onTrainingFinished.Invoke();
#endif
    }



}
