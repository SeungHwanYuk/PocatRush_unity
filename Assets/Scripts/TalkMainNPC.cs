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

    // �ִϸ��̼� ȣ��
    public GameObject npc;
    Animator animator;

    public string stayAnime = "NPCStay";
    public string hiAnime = "NPCHi";

    

   
    public void StartDialog()
    {
        animator = npc.GetComponent<Animator>();
        dialogText.text = "";
        dialogue = "���� ������? \n\n�����\n\n\n ����?";
        
        // �ڷ�ƾ : ���ϴ� �ð���ŭ ������ ���� ����
        // yield �� �Բ� ����
        StartCoroutine(Typing(dialogue));

        

        animator.Play(hiAnime);


    }

    // ��ȭ ���� �Լ�
    public void FinishDialog()
    {
        animator.Play(stayAnime);
        gameObject.SetActive(false);
        StopAllCoroutines();
        
        onDialogFinished.Invoke();
        
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
