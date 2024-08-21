using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class TalkMainNPC : MonoBehaviour
{
    // text ����
    public Text dialogText;
    public string dialogue;

    // Event ����� �ܺ� �Լ� ȣ��
    public UnityEvent onDialogFinished;
    // Start is called before the first frame update
    public void StartDialog()
    {
        
        dialogText.text = "";
        dialogue = "��ȣ�� ���ض�\n\n�����\n\n\n ����?";
        
        // �ڷ�ƾ : ���ϴ� �ð���ŭ ������ ���� ����
        // yield �� �Բ� ����
        StartCoroutine(Typing(dialogue));


    }

    // ��ȭ ���� �Լ�
    public void FinishDialog()
    {
        gameObject.SetActive(false);
        StopAllCoroutines();
        
        onDialogFinished.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Typing(string text)
    {
        foreach(char letter in text.ToCharArray())
        {
            // �ѱ��ھ� �߰��Ǹ� ������
            dialogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        // TODO 
        yield return new WaitForSeconds(1f);
        FinishDialog();

    }
}
