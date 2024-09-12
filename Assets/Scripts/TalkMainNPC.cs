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
    public int count = 0;
    public GameObject itemPanel;
    public GameObject churuGet;

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
        if(count == 0)
        {

        dialogue = "������~";
        } else if( count == 1)
        {
            dialogue = "�򸣸԰� �ʹ�~";
        } else if(count == 2)
        {
            dialogue = "�ʵ� �� ������?";
        } else if(count == 3)
        {
            dialogue = "���� ����� �� �������� ������\nü���� ȸ���ȴٱ�!";
        }
        else if(count == 4)
        {
            dialogue = "���� � ������ �ϱ�\n���� �Ϸ� ���°� �??";
        }
        else if(count == 5)
        {
            dialogue = "������ϱ�\n�� ���� �����ٷ�?";
        } else if(count == 6)
        {
            dialogue = "����Ű�� ����ϱ�???";
        } else if(count == 7)
        {
            dialogue = "�׸��� !!!";
        } else if(count == 8)
        {
            dialogue = "���� ����!!!\n�� ���״ϱ� �������ФФ�";
            itemPanel.GetComponent<ItemController>().ChuruCount = itemPanel.GetComponent<ItemController>().ChuruCount + 1;
            churuGet.SetActive(true);
        } else if(count >= 9)
        {
            dialogue = "�ФФФФ�";
        }
       

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
        count++;
    }
}
